using System;
using System.IO;
using System.Collections.Generic;

namespace IncidentApp
{
    public static class ManagerFunctionality {

        public static Boolean ManagerMainMenu() {
            
            bool showMenu = true;
            int option = 1;
            while (showMenu)
            {
                Console.Clear();
                //Console.WriteLine("Welcome to the GIJIMA Incident App, " + Authenticate.Instance.User.first_name + "\n");
                Console.WriteLine("Use Up arrow and Down arrow to move, enter/spacebar to select");
                if (option == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("View and Manage Incidents \n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("   ");
                    Console.Write("View and Manage Incidents\n");
                }
                if (option == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("View and Manage Users\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("   ");
                    Console.Write("View and Manage Users\n");
                }
                if (option == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.WriteLine("Exit\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("   ");
                    Console.WriteLine("Exit\n");
                }

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:

                        if (option != 1)
                        {
                            option--;
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.DownArrow:
                        if (option != 3)
                        {
                            option++;
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        Console.Clear();
                        switch (option)
                        {
                            case 1:
                                //IncidentServices.GetIncidents();
                                ManageIncidentsMenu();
                                break;
                            case 2:
                                //UserServices.getUsers();
                                ManageUsersMenu();
                                break;
                            case 3:
                                Console.WriteLine("\nExiting...");
                                showMenu = false;
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("\nInvalid key, use Up/Down arrow to move, enter/spacebar to select");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                }
            }
            return showMenu;
        }

        public static Boolean ManageIncidentsMenu() {
            bool showMenu = true;
            int option = 1;
            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine("Manage Incidents");
                Console.WriteLine("\nUse Up arrow and Down arrow to move, enter/spacebar to select");
                if (option == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Generate Report \n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("   ");
                    Console.Write("Generate Report \n");
                }
                if (option == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Filter Incidents \n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("   ");
                    Console.Write("Filter Incidents \n");
                }
                if (option == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Assign Technician to open Incident \n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("   ");
                    Console.Write("Assign Technician to open Incident \n");
                }
                if (option == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.WriteLine("\u21B5 Go back\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("   ");
                    Console.WriteLine("\u21B5 Go back\n");
                }

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:

                        if (option != 1)
                        {
                            option--;
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.DownArrow:
                        if (option != 4)
                        {
                            option++;
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        switch (option)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Reported incidents: ");
                                GeneralReport();
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Apply filters: ");
                                // IncidentServices.CreateFilteredReport();
                                Console.WriteLine();
                                Console.ReadKey(true);
                                break;
                            case 3:
                                AssignTechnician();
                                break;
                            case 4:
                                Console.WriteLine("\nGoing back...");
                                showMenu = false;
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("\nInvalid key, use Up/Down arrow to move, enter/spacebar to select");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                }
            }
            return true;
        }

        public static Boolean ManageUsersMenu() {
            bool showMenu = true;
            int option = 1;
            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine("Manage Users");
                Console.WriteLine("\nUse Up arrow and Down arrow to move, enter/spacebar to select");
                if (option == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Update a user's information \n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("   ");
                    Console.Write("Update a user's information \n");
                }
                if (option == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.WriteLine("\u21B5 Go back\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("   ");
                    Console.WriteLine("\u21B5 Go back\n");
                }

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:

                        if (option != 1)
                        {
                            option--;
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.DownArrow:
                        if (option != 2)
                        {
                            option++;
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        Console.Clear();
                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("Update user information: ");
                                updateUserProfile();
                                break;
                            case 2:
                                Console.WriteLine("\nGoing back...");
                                showMenu = false;
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("\nInvalid key, use Up/Down arrow to move, enter/spacebar to select");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                }
            }
            return true;
        }




        public static void AssignTechnician() {

            List<Incident> list = Database.Instance.GetOpenIncidents();

            bool showMenu = true;
            int pages = (list.Count/5);
            int last_page = list.Count%5;
            int option = 0;
            int current_page = 0;
            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine("Use Up arrow and Down arrow to move, Left and Right arrow to switch page, enter/spacebar to select, esc/escape to go back");
                if (current_page == pages) {
                    Console.WriteLine("\n\t \t \t \t \t All Incidents Reported");
                    Console.WriteLine();
                    Console.WriteLine("====================================================================================================================");
                    Console.WriteLine("{0,-4} {1,-4} {2,-30} {3,-30} {4,-20} {5,-10} {6,-8} {7,-8} ", "", "ID", "Location", "Description", "Date", "Status", "User", "Technician");
                    Console.WriteLine("====================================================================================================================");
                    for (int i = (current_page * 5); i < ((current_page * 5) + last_page); i++) {
                        displayIncident(list[i], option, i);
                    }
                } else {
                    Console.WriteLine("\n\t \t \t \t \t All Incidents Reported");
                    Console.WriteLine();
                    Console.WriteLine("====================================================================================================================");
                    Console.WriteLine("{0,-4} {1,-4} {2,-30} {3,-30} {4,-20} {5,-10} {6,-8} {7,-8} ", "", "ID", "Location", "Description", "Date", "Status", "User", "Technician");                    Console.WriteLine("====================================================================================================================");
                    for (int i = (current_page * 5); i < ((current_page * 5) + 5); i++) {
                        displayIncident(list[i], option, i);
                    }
                }
                
                Console.WriteLine("\nPage: " + (current_page + 1) + " of " + (pages + 1));
                
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:

                        if ((option > (current_page * 5))) {
                            option--;
                        }  
                        Console.Clear();
                        break;
                    case ConsoleKey.DownArrow:

                        if (current_page == pages) {
                            if ((option < (last_page - 1))) {
                                    option++;
                            }
                        } else {
                            if ((option < ((current_page * 5) + 4))) {
                                option++;
                            }
                        }

                        Console.Clear();
                        break;
                    case ConsoleKey.LeftArrow:
                        if (current_page != 0) {
                            current_page--;
                            option = (current_page * 5);
                        }    
                        break;
                    case ConsoleKey.RightArrow:
                        if (current_page != pages) {
                            current_page++;
                            option = (current_page * 5);
                        }    
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        selectTechnicianMenu(list[option]);
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        showMenu = false;
                        break;    
                    default:
                        Console.WriteLine("\nInvalid key, use Up/Down arrow to move, enter/spacebar to select");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                }
            }

        }

        public static void displayIncident(Incident incident, int option, int index) {
            
            string status = "";
            switch( incident.Status) {
                case (int)IncidentStatus.Open:
                    status = "Open";
                    break;
                case (int)IncidentStatus.Escalated:
                    status = "Escalated";
                    break;    
            }

            if (option == index) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0,-4} {1,-4} {2,-30} {3,-30} {4,-20} {5,-10} {6,-8} {7,-8} ", " * ",
                                                                                                incident.IncidentID,  
                                                                                                incident.Location,  
                                                                                                incident.Description,  
                                                                                                incident.Date_Logged,
                                                                                                status ,
                                                                                                incident.user.first_name + " " + incident.user.last_name, 
                                                                                                        "Not Assigned");
                Console.ResetColor();
            } else {
                Console.WriteLine("{0,-4} {1,-4} {2,-30} {3,-30} {4,-20} {5,-10} {6,-8} {7,-8} ","  ",
                                                                                        incident.IncidentID,  
                                                                                        incident.Location,  
                                                                                        incident.Description,  
                                                                                        incident.Date_Logged,
                                                                                        status ,
                                                                                        incident.user.first_name + " " + incident.user.last_name, 
                                                                                        "Not Assigned");
            }

            
        }

        public static void displayIncident(Incident incident) {
            
            string status = "";
            switch( incident.Status) {
                case (int)IncidentStatus.Open:
                    status = "Open";
                    break;
                case (int)IncidentStatus.Escalated:
                    status = "Escalated";
                    break;    
            }

            if (incident.Technician == null) {
                Console.WriteLine("{0,-4} {1,-30} {2,-30} {3,-20} {4,-10} {5,-8} {6,-8} ",
                                                                                        incident.IncidentID,  
                                                                                        incident.Location,  
                                                                                        incident.Description,  
                                                                                        incident.Date_Logged,
                                                                                        status ,
                                                                                        incident.user.first_name + " " + incident.user.last_name, 
                                                                                                "Not Assigned");
            } else {
                Console.WriteLine("{0,-4} {1,-30} {2,-30} {3,-20} {4,-10} {5,-8} {6,-8}  ",
                                                                                        incident.IncidentID,  
                                                                                        incident.Location,  
                                                                                        incident.Description,  
                                                                                        incident.Date_Logged,
                                                                                        status ,
                                                                                        incident.user.first_name + " " + incident.user.last_name, 
                                                                                        incident.Technician.first_name + " " + incident.Technician.last_name);
            }

            
        }

        public static void displayIncidentInDetail(Incident incident) {
            
            Console.WriteLine();
            Console.WriteLine("=================================================================");
            Console.WriteLine("=================================================================");
            Console.WriteLine("\t Incident Details");
            Console.WriteLine();
            Console.WriteLine("Incident ID : {0}", incident.IncidentID);
            Console.WriteLine("Date issued : {0}", incident.Date_Logged);
            Console.WriteLine("Location : {0}", incident.Location);

            string status = "";
            switch( incident.Status) {
                case (int)IncidentStatus.Open:
                    status = "Open";
                    break;
                case (int)IncidentStatus.Escalated:
                    status = "Escalated";
                    break;    
            }

            Console.WriteLine("Status : {0}", status);
            Console.WriteLine("Technician : Not assigned");
            Console.WriteLine("Description : {0}", incident.Description);
            Console.WriteLine();
            Console.WriteLine("=================================================================");
            Console.WriteLine("=================================================================");
            Console.WriteLine();


        }

        public static void selectTechnicianMenu(Incident incident) {
            List<User> list = Database.Instance.GetAvailableTechnicians();
            bool showMenu = true;
            int pages = (list.Count/5);
            int last_page = list.Count%5;
            int option = 0;
            int current_page = 0;
            while (showMenu)
            {
                Console.Clear();
                displayIncidentInDetail(incident);
                Console.WriteLine("\nUse Up arrow and Down arrow to move, Left and Right arrow to switch page, enter/spacebar to select, Esc/Escape to go back.");
                if (current_page == pages) {
                    Console.WriteLine("\n\t \t \t \t \t All Available Technicians");
                    Console.WriteLine();
                    Console.WriteLine("====================================================================================================================");
                    Console.WriteLine("{0,-4} {1,-4} {2,-30} {3,-30} {4,-20} {5,-10} ", "", "ID", "First Name", "Last Name", "Email", "Cellphone no");
                    Console.WriteLine("====================================================================================================================");
                    for (int i = (current_page * 5); i < ((current_page * 5) + last_page); i++) {
                        displayTechnician(list[i], option, i);
                    }
                    if (list.Count == 0) {
                        Console.WriteLine("\t \t \t \t \t No Available Technicians");
                    }
                } else {
                    Console.WriteLine("\n\t \t \t \t \t All Incidents Reported");
                    Console.WriteLine();
                    Console.WriteLine("====================================================================================================================");
                    Console.WriteLine("{0,-4} {1,-4} {2,-30} {3,-30} {4,-20} {5,-10} ", "", "ID", "First Name", "Last Name", "Email", "Cellphone no");                    
                    Console.WriteLine("====================================================================================================================");
                    for (int i = (current_page * 5); i < ((current_page * 5) + 5); i++) {
                        displayTechnician(list[i], option, i);
                    }
                    if (list.Count == 0) {
                        Console.WriteLine("\t \t \t \t \t No Available Technicians");
                    }
                }
                
                Console.WriteLine("\nPage: " + (current_page + 1) + " of " + (pages + 1));
                
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:

                        if ((option > (current_page * 5))) {
                            option--;
                        }  
                        Console.Clear();
                        break;
                    case ConsoleKey.DownArrow:

                        if (current_page == pages) {
                            if ((option < (last_page - 1))) {
                                    option++;
                            }
                        } else {
                            if ((option < ((current_page * 5) + 4))) {
                                option++;
                            }
                        }

                        Console.Clear();
                        break;
                    case ConsoleKey.LeftArrow:
                        if (current_page != 0) {
                            current_page--;
                            option = (current_page * 5);
                        }    
                        break;
                    case ConsoleKey.RightArrow:
                        if (current_page != pages) {
                            current_page++;
                            option = (current_page * 5);
                        }    
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (list.Count > 0) {
                            showMenu = technicianAssigned(incident, list[option]);
                        }
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        showMenu = false;
                        break;    
                    default:
                        Console.WriteLine("\nInvalid key, use Up/Down arrow to move, enter/spacebar to select");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                }
            }
            


        }

        public static void displayTechnician(User user, int option, int index) {

            if (option == index) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0,-4} {1,-4} {2,-30} {3,-30} {4,-20} {5,-10} " , " * ",
                                                                                    user.User_ID,  
                                                                                    user.first_name,  
                                                                                    user.last_name,  
                                                                                    user.email,
                                                                                    user.cellphone_number);
                Console.ResetColor();
            } else {
                Console.WriteLine("{0,-4} {1,-4} {2,-30} {3,-30} {4,-20} {5,-10} ","  ",
                                                                                    user.User_ID,  
                                                                                    user.first_name,  
                                                                                    user.last_name,  
                                                                                    user.email,
                                                                                    user.cellphone_number);
            }

            
        }
        
        public static Boolean technicianAssigned(Incident incident, User user) {
            Console.WriteLine();
            Console.WriteLine("=================================================================");
            Console.WriteLine("=================================================================");
            Console.WriteLine("\t Incident Details");
            Console.WriteLine();
            Console.WriteLine("Incident ID : {0}", incident.IncidentID);
            Console.WriteLine("Date issued : {0}", incident.Date_Logged);
            Console.WriteLine("Location : {0}", incident.Location);

            string status = "";
            switch( incident.Status) {
                case (int)IncidentStatus.Open:
                    status = "Open";
                    break;
                case (int)IncidentStatus.Escalated:
                    status = "Escalated";
                    break;    
            }

            Console.WriteLine("Status : {0}", status);
            Console.WriteLine("Technician : {0}", user.first_name + " " + user.last_name);
            Console.WriteLine("Description : {0}", incident.Description);
            Console.WriteLine();
            Console.WriteLine("=================================================================");
            Console.WriteLine("=================================================================");
            Console.WriteLine();

            if (Database.Instance.AssignTechnicianToIncident(incident.IncidentID, user.User_ID)) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nTechnician has been assigned to incident");
                Console.WriteLine("\nPress any key to continue");
                Console.ResetColor();
                Console.ReadKey(true);
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nTechnician could not be assigned to incident");
                Console.WriteLine("\nPress any key to continue");
                Console.ResetColor();
                Console.ReadKey(true);          
            }
            return true;
        }


        public static void GeneralReport()
        {
            List<Incident> list = Database.Instance.GetAllIncidents();
            DateTime fileDate = DateTime.Now;
            string date = fileDate.ToString("yyyy_MM_dd_HH_mm_ss");
            string dateCons = "General_report_" + date;

            string filePath = @"C:\Users\User\Documents\Incident App\Generated Reports\General Report - " + dateCons + ".txt";

            if(!Directory.Exists(filePath)) {
                Directory.CreateDirectory(@"C:\Users\User\Documents\Incident App\Generated Reports");
            }



            bool showMenu = true;
            int pages = (list.Count/5);
            int last_page = list.Count%5;
            int option = 1;
            int current_page = 0;
            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine("Use Up arrow and Down arrow to move, Left and Right arrow to switch page, enter/spacebar to select, esc/escape to go back");
                if (current_page == pages) {
                    Console.WriteLine("\n\t \t \t \t \t All Incidents Reported");
                    Console.WriteLine();
                    Console.WriteLine("====================================================================================================================");
                    Console.WriteLine("{0,-4} {1,-30} {2,-30} {3,-20} {4,-10} {5,-8} {6,-8} ", "ID", "Location", "Description", "Date", "Status", "User", "Technician");
                    Console.WriteLine("====================================================================================================================");
                    for (int i = (current_page * 5); i < ((current_page * 5) + last_page); i++) {
                        displayIncident(list[i]);
                    }
                } else {
                    Console.WriteLine("\n\t \t \t \t \t All Incidents Reported");
                    Console.WriteLine();
                    Console.WriteLine("====================================================================================================================");
                    Console.WriteLine("{0,-4} {1,-30} {2,-30} {3,-20} {4,-10} {5,-8} {6,-8} ", "ID", "Location", "Description", "Date", "Status", "User", "Technician");                    Console.WriteLine("====================================================================================================================");
                    for (int i = (current_page * 5); i < ((current_page * 5) + 5); i++) {
                        displayIncident(list[i]);
                    }
                }
                
                Console.WriteLine("\nPage: " + (current_page + 1) + " of " + (pages + 1));

                Console.WriteLine("\nSave a Report of all incidents as text file? ");
                Console.WriteLine("Use Up arrow and Down arrow to move, enter/spacebar to select");
                if(option == 1) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Yes\n");
                    Console.ResetColor();
                } else {
                    Console.Write("   ");
                    Console.Write("Yes\n");
                }
                if(option == 2) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("No\n");
                    Console.ResetColor();
                } else {
                    Console.Write("   ");
                    Console.Write("No\n");
                }

                
                switch (Console.ReadKey().Key)
                {
                     case ConsoleKey.UpArrow:
                    
                        if (option != 1) {
                            option--;
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.DownArrow:
                        if (option != 2) {
                            option++;
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.LeftArrow:
                        if (current_page != 0) {
                            current_page--;
                        }    
                        break;
                    case ConsoleKey.RightArrow:
                        if (current_page != pages) {
                            current_page++;
                        }    
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        Console.Clear();
                        switch(option) {
                            case 1:
                                if (!File.Exists(filePath))
                                {
                                    using (StreamWriter sw = File.CreateText(filePath))
                                    {
                                        sw.WriteLine("\t \t \t \t \t \t All Incidents Reported");
                                        sw.WriteLine();
                                        sw.WriteLine("====================================================================================================================");
                                        sw.WriteLine("{0,-4} {1,-30} {2,-30} {3,-20} {4,-10} {5,-8} {6,-8} ", "ID", "Location", "Description", "Date", "Status", "User", "Tech ID");
                                        sw.WriteLine("====================================================================================================================");
                                        foreach (Incident reportedIncident in list)
                                        {   
                                            string status = "";
                                            switch( reportedIncident.Status) {
                                                case (int)IncidentStatus.Open:
                                                    status = "Open";
                                                    break;
                                                case (int)IncidentStatus.Escalated:
                                                    status = "Escalated";
                                                    break;    
                                            }

                                            if (reportedIncident.Technician == null) {
                                                sw.WriteLine("{0,-4} {1,-30} {2,-30} {3,-20} {4,-10} {5,-8} {6,-8} ", 
                                                                                        reportedIncident.IncidentID, 
                                                                                        reportedIncident.Location, 
                                                                                        reportedIncident.Description, 
                                                                                        reportedIncident.Date_Logged, 
                                                                                        status, 
                                                                                        reportedIncident.user.first_name + " " + reportedIncident.user.last_name , 
                                                                                        "Not Assigned");
                                            } else {
                                                sw.WriteLine("{0,-4} {1,-30} {2,-30} {3,-20} {4,-10} {5,-8} {6,-8} ", 
                                                                                        reportedIncident.IncidentID, 
                                                                                        reportedIncident.Location, 
                                                                                        reportedIncident.Description, 
                                                                                        reportedIncident.Date_Logged, 
                                                                                        status, 
                                                                                        reportedIncident.user.first_name + " " + reportedIncident.user.last_name , 
                                                                                        reportedIncident.Technician.first_name + " " + reportedIncident.Technician.last_name);
                                            }
                                            

                                        }
                                        sw.WriteLine("====================================================================================================================");

                                        if (Database.Instance.reportGenerated(Authenticate.Instance.User.User_ID, dateCons)) {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Report Saved!");
                                            Console.WriteLine("\nPress any key to continue...");
                                            Console.ReadKey(true);
                                            Console.ResetColor();
                                            showMenu = false;
                                        } else {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Report could not be saved!");
                                            Console.WriteLine("\nPress any key to continue...");
                                            Console.ReadKey(true);
                                            Console.ResetColor();
                                            showMenu = false;
                                        }
                                    }
                                }
                                break;
                            case 2:
                                showMenu = false;
                                break;
                        }
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        showMenu = false;
                        break;    
                    default:
                        Console.WriteLine("\nInvalid key, use Up/Down arrow to move, enter/spacebar to select");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                }
            }



        }

        public static void updateUserProfile() {

            List<User> list = Database.Instance.GetAllUsers();

            bool showMenu = true;
            int pages = (list.Count/5);
            int last_page = list.Count%5;
            int option = 0;
            int current_page = 0;
            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine("Use Up arrow and Down arrow to move, Left and Right arrow to switch page, enter/spacebar to select, esc/escape to go back");
                if (current_page == pages) {
                    Console.WriteLine("\n\t \t \t \t \t All Users");
                    Console.WriteLine();
                    Console.WriteLine("====================================================================================================================");
                    Console.WriteLine("{0,-4} {1,-4} {2,-30} {3,-30} {4,-20} {5,-10} ", "", "ID", "First Name", "Last Name", "Email", "Cellphone no");
                    Console.WriteLine("====================================================================================================================");
                    for (int i = (current_page * 5); i < ((current_page * 5) + last_page); i++) {
                        displayTechnician(list[i], option, i);
                    }
                } else {
                    Console.WriteLine("\n\t \t \t \t \t All Users");
                    Console.WriteLine();
                    Console.WriteLine("====================================================================================================================");
                    Console.WriteLine("{0,-4} {1,-4} {2,-30} {3,-30} {4,-20} {5,-10} ", "", "ID", "First Name", "Last Name", "Email", "Cellphone no");                 
                    Console.WriteLine("====================================================================================================================");
                    for (int i = (current_page * 5); i < ((current_page * 5) + 5); i++) {
                        displayTechnician(list[i], option, i);
                    }
                }
                
                Console.WriteLine("\nPage: " + (current_page + 1) + " of " + (pages + 1));
                
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:

                        if ((option > (current_page * 5))) {
                            option--;
                        }  
                        Console.Clear();
                        break;
                    case ConsoleKey.DownArrow:

                        if (current_page == pages) {
                            if ((option < (last_page - 1))) {
                                    option++;
                            }
                        } else {
                            if ((option < ((current_page * 5) + 4))) {
                                option++;
                            }
                        }

                        Console.Clear();
                        break;
                    case ConsoleKey.LeftArrow:
                        if (current_page != 0) {
                            current_page--;
                            option = (current_page * 5);
                        }    
                        break;
                    case ConsoleKey.RightArrow:
                        if (current_page != pages) {
                            current_page++;
                            option = (current_page * 5);
                        }    
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        list[option] = selectUserMenu(list[option]);
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        showMenu = false;
                        break;    
                    default:
                        Console.WriteLine("\nInvalid key, use Up/Down arrow to move, enter/spacebar to select");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                }
            }

        }

        public static User selectUserMenu(User user)//A method that allow the user to update their inforomation
        {
            string firstName = "";
            string lastName = "";
            string email = "";
            string cell = "";
            
            bool showMenu = true;
            int option = 1;
            //This is a menu that shows what information the user wants to change, i.e. the First Name, Last Name, Email.
            while(showMenu) {
                Console.Clear();
                Console.WriteLine("You are updating the following user: ");
                Console.WriteLine("=================================================================");
                Console.WriteLine("\t User Details");
                Console.WriteLine();
                Console.WriteLine("ID : {0}", user.User_ID);
                Console.WriteLine("First Name : {0}", user.first_name);
                Console.WriteLine("Last Name : {0}", user.last_name);

                string role = "";
                switch( user.user_role) {
                    case (int)UserRole.User:
                        role = "User";
                        break;
                    case (int)UserRole.Manager:
                        role = "Manager";
                        break;  
                    case (int)UserRole.Technician:
                        role = "Technician";
                        break;     
                }

                Console.WriteLine("Email : {0}", user.email);
                Console.WriteLine("Cellphone no: {0}", user.cellphone_number);
                Console.WriteLine("Role : {0}", role);
                Console.WriteLine();
                Console.WriteLine("=================================================================");
                Console.WriteLine();
                Console.WriteLine("\nUse Up arrow and Down arrow to move, enter/spacebar to select");
                //The updating first name option
                if(option == 1) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Update first name\n");
                    Console.ResetColor();
                } else {
                    Console.Write("   ");
                    Console.Write("Update first name\n");
                }
                //The updating last name option
                if(option == 2) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Update last name\n");
                    Console.ResetColor();
                } else {
                    Console.Write("   ");
                    Console.Write("Update last name\n");
                }
                //The updating email option
                if(option == 3) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Update email\n");
                    Console.ResetColor();
                } else {
                    Console.Write("   ");
                    Console.Write("Update email\n");
                }
                //The updating cellphone number option
                if(option == 4) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Update cellphone number\n");
                    Console.ResetColor();
                } else {
                    Console.Write("   ");
                    Console.Write("Update cellphone number\n");
                }
                if(option == 5) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.WriteLine("Exit\n");
                    Console.ResetColor();
                } else {
                    Console.Write("   ");
                    Console.WriteLine("Exit\n");
                }

                switch(Console.ReadKey().Key) {
                    case ConsoleKey.UpArrow:
                    
                        if (option != 1) {
                            option--;
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.DownArrow:
                        if (option != 5) {
                            option++;
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        Console.Clear();
                        //The options which allow the user to change/update their information
                        switch(option)  
                        {
                            //Update their First Name
                            case 1:
                                Console.WriteLine("**********************************************");
                                Console.WriteLine("You are updating first name: " + user.first_name);
                                Console.WriteLine("\nPlease enter the first name you wish to replace it with");
                                firstName = Console.ReadLine();
                                while(string.IsNullOrEmpty(firstName) || string.IsNullOrWhiteSpace(firstName) || firstName == user.first_name ) 
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nFirst name already exists or input is invalid!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("\nPlease enter a valid first name: ");
                                    firstName = Console.ReadLine();
                                }
                                if (Database.Instance.updateProfileField(firstName, UpdateProfileField.FirstName, user.User_ID)) {
                                    user.first_name = firstName;
                                }
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nThe updated name is: " + firstName);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("**********************************************"); 
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey(true);
                                break;
                            //Updating the user Last Name
                            case 2:
                                Console.WriteLine("**********************************************");
                                Console.WriteLine("You are updating the last name: " + user.last_name);
                                Console.WriteLine("\nPlease enter the name you wish to replace it with");
                                lastName = Console.ReadLine();
                                while(string.IsNullOrEmpty(lastName) || string.IsNullOrWhiteSpace(lastName) || lastName == user.last_name ) 
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nLast name already exists or last name is invalid!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("\nPlease enter a valid last name: ");
                                    lastName = Console.ReadLine();
                        
                                }
                                
                                if (Database.Instance.updateProfileField(lastName, UpdateProfileField.LastName, user.User_ID)) {
                                    user.last_name = lastName;
                                }
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nThe updated last name is: " + lastName);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("**********************************************");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey(true);
                                break;
                            //Updating the email    
                            case 3: 
                                Console.WriteLine("**********************************************");
                                Console.WriteLine("You are updating an email: " + user.email);
                                Console.WriteLine("\nPlease enter the email you wish to replace it with");
                                email = Console.ReadLine();

                                while(string.IsNullOrEmpty(email) || 
                                        string.IsNullOrWhiteSpace(email) || 
                                        email == user.email ||
                                        Database.Instance.EmailExists(email) ||
                                        !Validators.isValidEmail(email)) 
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nEmail already exists or email is invalid!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("\nPlease enter a valid email: ");
                                    email = Console.ReadLine();
                        
                                }
                                
                                if (Database.Instance.updateProfileField(email, UpdateProfileField.Email, user.User_ID)) {
                                    user.email = email;
                                }
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYour updated email is: " + email);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("**********************************************");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey(true);
                                break;
                            //Updating the cellphone number    
                            case 4: 
                                Console.WriteLine("**********************************************");
                                Console.WriteLine("You are updating the cell phone number to: " + user.cellphone_number);
                                Console.WriteLine("\nPlease enter the cellphone number you wish to replace it with");
                                cell = Console.ReadLine();
                                while(Validators.isPhoneNumber(cell) != true)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nInvalid Contact Details");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("\nEnter Phone Number: ");
                                    cell = Console.ReadLine();
                                    
                                }
                                while(string.IsNullOrEmpty(cell) || 
                                    string.IsNullOrWhiteSpace(cell) || 
                                    cell == user.cellphone_number || 
                                    !Validators.isPhoneNumber(cell) ) 
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nCellphone number already exists or Cellphone number is invalid!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("\nPlease enter a valid Cellphone number: ");
                                    cell = Console.ReadLine();
                        
                                }
                                
                                Database.Instance.updateProfileField(cell, UpdateProfileField.ContactNo, user.User_ID);
                                if (Database.Instance.updateProfileField(cell, UpdateProfileField.ContactNo, user.User_ID)) {
                                    user.cellphone_number = cell;
                                }
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nThe updated cellphone number is: " + user.cellphone_number);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("**********************************************");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey(true);
                                break;                    
                            case 5: 
                                Console.WriteLine("\nExiting...");
                                showMenu = false;
                                break;            
                        }
                        //If the user wants to continue or proceed with other tasks
                        break; 
                    default:
                        Console.WriteLine("\nInvalid key, use Up/Down arrow to move, enter/spacebar to select");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        break;    
                }

            }

            return user;
        }



        // public static void CreateFilteredReport(int report_request = 102)
        // {
        //     DateTime fileDate = DateTime.Now;
        //     string date = fileDate.ToString("yyyy_MM_dd_HH_mm_ss");
        //     string dateCons = "Filtered_report_" + date; 
        //     string filePath = @"C:\Users\User\Desktop\Reports\" + dateCons + ".txt";
        //     int? TechID = null;
        //     int? userID = null;
        //     string year1;
        //     string year2;
        //     DateTime from;
        //     DateTime to;
        //     GetIncidents();
            
        //     List<Incident> FilteredIncidents = new List<Incident>();
        // //user input for incident status filter
        // statusInput:
        //     Console.ForegroundColor = ConsoleColor.Green;
        //     Console.Write("Enter incident status : ");
        //     Console.ResetColor();
        //     int id = 0;
        //     string incidentStatus = Console.ReadLine();
        //     if (statuses.Find(x => x.Description.ToLower() == incidentStatus.ToLower()) == null)
        //     {
        //         Console.WriteLine("Invalid input!");
        //         goto statusInput;
        //     }
        //     else
        //     {
        //         id = (statuses.Find(x => x.Description.ToLower() == incidentStatus.ToLower()).Id);
        //     }

        // //user input for Technician id filter
        // techIdInput:
        //     Console.ForegroundColor = ConsoleColor.Green;
        //     Console.Write("Enter TechnicianID or 0 to skip this filter : ");
        //     Console.ResetColor();
        //     string input2 = Console.ReadLine();
        //     if (input2 == "0")
        //     {
        //         TechID = null;
        //     }
        //     else
        //     {
        //         try
        //         {
        //             int inputTechID = Convert.ToInt32(input2);
        //             if(incidentList.Find(x => x.TechnicianID == inputTechID) == null)
        //             {
        //                 Console.WriteLine("Invalid Technician ID : ");
        //                 goto techIdInput;
        //             }
        //             else
        //             {
        //                 TechID = inputTechID;
        //             }
        //         }
        //         catch (Exception ex)
        //         {
        //             Console.WriteLine();
        //             Console.ForegroundColor = ConsoleColor.Red;
        //             Console.WriteLine("Error info: " + ex.Message + " Expecting a number");
        //             Console.ResetColor();
        //             Console.WriteLine();
        //             Console.WriteLine();
        //             goto techIdInput;
        //         }
        //     }

        // //user input for user ID filter
        // userIdInput:
        //     Console.ForegroundColor = ConsoleColor.Green;
        //     Console.Write("Enter User ID or 0 to skip this filter : ");
        //     Console.ResetColor();
        //     string input3 = Console.ReadLine();
        //     if (input3 == "0")
        //     {
        //         userID = null;
        //     }
        //     else
        //     {
        //         try
        //         {
        //             int inputUserID = Convert.ToInt32(input3);
        //             if (incidentList.Find(x => x.UserID == inputUserID) == null)
        //             {
        //                 Console.WriteLine("Invalid User ID : ");
        //                 goto userIdInput;
        //             }
        //             else
        //             {
        //                 userID = inputUserID;
        //             }
        //         }
        //         catch (Exception ex)
        //         {
        //             Console.WriteLine();
        //             Console.ForegroundColor = ConsoleColor.Red;
        //             Console.WriteLine("Error info: " + ex.Message + " Expecting a number");
        //             Console.ResetColor();
        //             Console.WriteLine();
        //             Console.WriteLine();
        //             goto userIdInput;
        //         }
        //     }

        // //user Date Filters
        // beginningData:
        //     Console.ForegroundColor = ConsoleColor.Green;
        //     Console.Write("From: Enter Year starting date range [format : YYYY/MM/dd] : ");
        //     Console.ResetColor();
        //     year1 = Console.ReadLine();
        //     try
        //     {
        //         from = Convert.ToDateTime(year1);
        //     }
        //     catch
        //     {
        //         Console.ForegroundColor = ConsoleColor.Red;
        //         Console.WriteLine("Date was in the wrong format");
        //         Console.ResetColor();
        //         goto beginningData;
        //     }
        // endingDate:
        //     Console.ForegroundColor = ConsoleColor.Green;
        //     Console.Write("To: Enter the ending date range [format : YYYY/MM/dd] : ");
        //     Console.ResetColor();
        //     year2 = Console.ReadLine();
        //     try
        //     {
        //         to = Convert.ToDateTime(year2);
        //     }
        //     catch
        //     {
        //         Console.ForegroundColor = ConsoleColor.Red;
        //         Console.WriteLine("Date was in the wrong format");
        //         Console.ResetColor();
        //         goto endingDate;
        //     }

        //     //appliying filters
        //     //filtering by date
        //     FilteredIncidents = GetIncidentsOnYearMonth(from, to);
        //     FilteredIncidents = FilteredIncidents.FindAll(x => x.Status == id);
            
        //     if (TechID.HasValue)
        //     {
        //         FilteredIncidents = FilteredIncidents.FindAll(x => x.TechnicianID == TechID);
        //     }
        //     //filtering by user id
        //     if (userID.HasValue)
        //     {
        //         FilteredIncidents = FilteredIncidents.FindAll(x => x.UserID == userID);
        //     }
            
        //     //Generate report
        //     Console.WriteLine();
        //     Console.WriteLine();

        //     if (FilteredIncidents == null)
        //     {
        //         Console.WriteLine("No Incidents found matching those filters!");
        //     }
        //     else
        //     {
        //         Console.WriteLine("====================================================================================================================");
        //         Console.WriteLine("\t \t \t \t \t \t Reported Incidents");
        //         Console.WriteLine("====================================================================================================================");

        //         foreach (Incident reportedIncident in FilteredIncidents)
        //         {
        //             Console.WriteLine("{0,-4} {1,-30} {2,-30} {3,-20} {4,-10} {5,-8} {6,-8} ", reportedIncident.IncidentID, reportedIncident.Location, reportedIncident.Description, reportedIncident.DateCreated, statuses.Find(x => x.Id == reportedIncident.Status).Description, reportedIncident.UserID, reportedIncident.TechnicianID);
        //         }
        //         Console.WriteLine("====================================================================================================================");

        //     }

        //     Console.WriteLine();
        //     Console.Write("Save Report as text file? [yes/no to stop] : ");
        //     string input = Console.ReadLine();
        //     while (!(input == "yes" || input == "no"))
        //     {
        //         Console.ForegroundColor = ConsoleColor.Red;
        //         Console.WriteLine("Invalid Input!");
        //         Console.ResetColor();
        //         Console.WriteLine();
        //         Console.Write("Save Report as text file? [yes/no to stop] : ");
        //         input = Console.ReadLine();
        //     }
        //     if (input == "yes")
        //     {
        //         if (!File.Exists(filePath))
        //         {
        //             using (StreamWriter sw = File.CreateText(filePath))
        //             {
        //                 sw.WriteLine("====================================================================================================================");
        //                 sw.WriteLine("\t \t \t \t \t \t Reported Incidents");
        //                 sw.WriteLine();
        //                 sw.WriteLine("====================================================================================================================");
        //                 sw.WriteLine("{0,-4} {1,-30} {2,-30} {3,-20} {4,-10} {5,-8} {6,-8} ", "ID", "Location", "Description", "Date", "Status", "User ID", "Tech ID");
        //                 sw.WriteLine("====================================================================================================================");

        //                 foreach (Incident reportedIncident in FilteredIncidents)
        //                 {
        //                     sw.WriteLine("{0,-4} {1,-30} {2,-30} {3,-20} {4,-10} {5,-8} {6,-8} ", reportedIncident.IncidentID, reportedIncident.Location, reportedIncident.Description, reportedIncident.DateCreated, statuses.Find(x => x.Id == reportedIncident.Status).Description, reportedIncident.UserID, reportedIncident.TechnicianID);

        //                 }
        //                 sw.WriteLine("====================================================================================================================");
        //             }
        //         }
        //         NpgsqlConnection connection = null;
        //         //instantiate the connection
        //         connection = new NpgsqlConnection(connectionString());
        //         //open connection
        //         connection.Open();
        //         //update report table
        //         NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO \"Reports\" (\"Report_Request\", \"Report_Description\") VALUES ('" + report_request + "', '" + dateCons + "' )", connection);
        //         cmd.ExecuteNonQuery();
        //         connection.Close();
        //         Console.ForegroundColor = ConsoleColor.Green;
        //         Console.WriteLine("Report Saved!");
        //         Console.WriteLine();
        //         Console.WriteLine("Thank you. Have a nice day!");
        //         Console.ResetColor();
        //         Console.WriteLine();
        //         Console.ReadKey();
        //     }
        //     else
        //     {

        //     }
        // }







        // public static List<Incident> GetIncidentsOnYearMonth(DateTime from, DateTime to)
        // {
        //     NpgsqlConnection connection = new NpgsqlConnection(connectionString());
        //     NpgsqlDataReader rdr = null;
        //     List<Incident> list = new List<Incident>();

        //     connection.Open();
        //     NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM \"Incidents\" WHERE \"Incident_Date_Logged\" BETWEEN \'" + from + "\' AND \'" + to + "\'", connection);
        //     rdr = command.ExecuteReader();

        //     while (rdr.Read())
        //     {
        //         Incident incident = new Incident();
        //         incident.IncidentID = (int)rdr[0];
        //         incident.Location = (string)rdr[1];
        //         incident.Description = (string)rdr[2];
        //         incident.DateCreated = (DateTime)rdr[3];
        //         incident.Status = (int)rdr[4];
        //         incident.UserID = (int)rdr[5];
        //         //incident.TechnicianID = (int)rdr[6];
        //         if (rdr[6] == DBNull.Value)
        //             incident.TechnicianID = null;
        //         else
        //             incident.TechnicianID = Convert.ToInt32(rdr[6]);
        //         list.Add(incident);
        //     }
        //     return list;
        // }




    }
    
    


}