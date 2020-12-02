using System;
using System.IO;
using System.Collections.Generic;

namespace IncidentApp
{
    public sealed class IncidentSystem
    {
        private static readonly IncidentSystem instance = new IncidentSystem();
        private System.Timers.Timer timer = null;

        static IncidentSystem() {}

        private IncidentSystem() {}

        public static IncidentSystem Instance {
            get {
                return instance;
            }
        }

        /// <summary>
        /// This method sets a timer for 60 seconds to check if an escalation for an incident is required 
        /// after 60 seconds has elapsed.
        /// </summary>
        /// <seealso cref="EscalationTimerFired"/>
        /// <param name="incident_id">Incident ID to be queried</param>
        public void setTimerForEscalation(int incident_id, bool runImmediately) {

            if (runImmediately) {
                EscalationTimerFired(incident_id);
            } else {
                try
                {
                    // Set timer to 60 minutes
                    timer = new System.Timers.Timer(1000 * 60 * 60); // 60 minutes/ 1 hour interval
                    timer.Enabled = true;
                    // Execute the "EscalationTimerFired" on another thread
                    timer.Elapsed += delegate { EscalationTimerFired(incident_id); };
                    // Set to only run once
                    timer.AutoReset = false;

                    // Start the timer
                    timer.Start();
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                }
            }

            
        }

        /// <summary>
        /// This method is fired when the 60 seconds has elapsed. It calls the EscalateIncident function from
        /// the database.
        /// </summary>
        /// <seealso cref="Database.EscalateIncident(int)"/>
        /// <param name="incident_id">Incident ID to be queried</param>
        private void EscalationTimerFired(int incident_id) {
            Database.Instance.EscalateIncident(incident_id);
        }

        /// <summary>
        /// This method generates a monthly auto report based on the year and month provided and writes it to file.
        /// </summary>
        /// <seealso cref="Database.GetIncidentsOnYearMonth(string, string)"/>
        /// <param name="year">The year of the report</param>
        /// <param name="month">The month of year of the report</param>
        public void GenerateMonthlyAutoReport(String year, String month) {
            List<Incident> list = Database.Instance.GetIncidentsOnYearMonth(year, month);
            DateTime fileDate = DateTime.Now;
            string dateCons = fileDate.ToString("MMMM");
            string filePath = @"C:\Users\User\Documents\Incident App\Generated Reports\General Report - " + dateCons + ".txt";

            if(!Directory.Exists(filePath)) {
                Directory.CreateDirectory(@"C:\Users\User\Documents\Incident App\Generated Reports");
            }

            if(!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine("\t \t \t \t \t \t All Incidents Reported");
                    sw.WriteLine();
                    sw.WriteLine("==========================================================================================================");
                    foreach (Incident reportedIncident in list)
                    {
                        sw.WriteLine("{0,-5} {1,-30} {2,-30} {3,-20} {4,-5} {5,-9} {6,-5} ", reportedIncident.IncidentID, reportedIncident.Description, reportedIncident.Location, reportedIncident.Date_Logged, 1, "Status", reportedIncident.Technician);

                    }
                    sw.WriteLine("==========================================================================================================");
                }
            }
            Console.WriteLine("Report Saved!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
        }
    

    }
}