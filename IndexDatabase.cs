using System;
using System.Collections.Generic;
using Npgsql;

namespace IncidentApp
{
    /// <summary>
    /// This singleton class represents the database and it is responsible for all database operations.
    /// </summary>
    public sealed class Database
    {
        private static readonly Database instance = new Database();

        static Database() {}

        private Database() {}

        public static Database Instance {
            get {
                return instance;
            }
        }

        /// <summary>
        /// This method formats the connection string for the database.
        /// </summary>
        /// <returns>A formatted connection string</returns>
        private string connectionString() {
            return string.Format("host={0};port={1};database={2};username={3}; password={4};", "localhost", "5432", "IncidentDb", "postgres", "mary19991011-");
        }

        public User Login(String email, String password) {
            User user = null;
            
            try
            {
                using(NpgsqlConnection connection = new NpgsqlConnection(connectionString())) {
                    NpgsqlDataReader rdr = null;

                    connection.Open();

                    // SQL Command object
                    String SQLquery = String.Format("SELECT * FROM \"" + DatabaseNames.TABLE_USERS + "\" WHERE \"" + DatabaseNames.USER_EMAIL + "\" = \'" + email +
                                                    "\' AND \"" + DatabaseNames.USER_PASSWORD + "\" = \'" + password + "\'");

                    NpgsqlCommand querryCommand = new NpgsqlCommand(SQLquery, connection);
                    rdr = querryCommand.ExecuteReader();

                    // If data exists, assign User details to global user variable
                    while (rdr.Read())
                    {
                        user = new User((int)rdr[0], (string)rdr[1], (string)rdr[2], (string)rdr[3], null, (string)rdr[5], (int)rdr[6]);
                    }

                    rdr.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving data: " + e);
            }

            return user;
        }

        public Boolean Register(User user) {
            bool success = false;

            try
            {
                using(NpgsqlConnection connection = new NpgsqlConnection(connectionString())) {
                    connection.Open();

                    String SQLinsert = "INSERT INTO public.\"" + DatabaseNames.TABLE_USERS +
                                        "\" ( \"" + DatabaseNames.USER_FIRST_NAME + 
                                        "\", \"" + DatabaseNames.USER_LAST_NAME + 
                                        "\", \""+ DatabaseNames.USER_EMAIL + 
                                        "\", \"" + DatabaseNames.USER_PASSWORD + 
                                        "\", \"" + DatabaseNames.USER_CELLPHONE_NO +
                                         "\", \"" + DatabaseNames.USER_ROLE_ID + "\") VALUES(" +
                                        "\'" + user.first_name + "\', " +
                                        "\'" + user.last_name + "\', " +
                                        "\'" + user.email + "\', " +
                                        "\'" + user.password + "\', " +
                                        "\'" + user.cellphone_number + "\', " +
                                        user.user_role + ")";

                    NpgsqlCommand insertCommand = new NpgsqlCommand(SQLinsert, connection);

                    if (insertCommand.ExecuteNonQuery() > 0 ) {
                        success = true;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving data: " + e);
            }

            return success;
        }

        public Boolean EmailExists(String email) {
            bool exists = false;

            try
            {
                using(NpgsqlConnection connection = new NpgsqlConnection(connectionString())) {
                    NpgsqlDataReader rdr = null;

                    connection.Open();

                    // SQL Command object
                    String SQLquery = "SELECT * FROM \"" + DatabaseNames.TABLE_USERS + "\" WHERE \"" + DatabaseNames.USER_EMAIL + "\" = " + "\'" + email + "\'";

                    NpgsqlCommand querryCommand = new NpgsqlCommand(SQLquery, connection);
                    rdr = querryCommand.ExecuteReader();

                    // If data exists, email exists
                    while (rdr.Read())
                    {
                        exists = true;
                    }

                    rdr.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving data: " + e);
            }            

            return exists;
        }
        
        public Boolean LogIncident(Incident incident) {

            try
            {
                using(NpgsqlConnection connection = new NpgsqlConnection(connectionString())) {

                    connection.Open();

                    // SQL Command object

                    String SQLinsert = "INSERT INTO public.\"" + DatabaseNames.TABLE_INCIDENTS +
                                        "\" ( \"" + DatabaseNames.INCIDENTS_LOCATION + 
                                        "\", \"" + DatabaseNames.INCIDENTS_DESCRIPTION + 
                                        "\", \""+ DatabaseNames.INCIDENTS_DATE_LOGGED + 
                                        "\", \"" + DatabaseNames.INCIDENTS_STATUS + 
                                        "\", \"" + DatabaseNames.INCIDENTS_USER_ID +
                                        "\") VALUES(" +
                                        "\'" + incident.Location + "\', " +
                                        "\'" + incident.Description + "\', " +
                                        "\'" + incident.Date_Logged + "\', " +
                                        + incident.Status + ", " +
                                        + incident.user.User_ID + ")";

                    NpgsqlCommand insertCommand = new NpgsqlCommand(SQLinsert, connection);

                    if (insertCommand.ExecuteNonQuery() > 0) {
                        return true;
                    } else {
                        return false;
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving data: " + e);
            }

            return false;
        }

        public Incident GetIncident(int incident_id) {
            Incident incident = null;
            try
            {
                using(NpgsqlConnection connection = new NpgsqlConnection(connectionString())) {
                    NpgsqlDataReader rdr = null;

                    connection.Open();

                    // SQL Command object
                    String SQLquery = "SELECT * FROM \"" + DatabaseNames.TABLE_INCIDENTS + "\" WHERE \"" + 
                                        DatabaseNames.INCIDENTS_ID + "\" = " + incident_id;

                    NpgsqlCommand querryCommand = new NpgsqlCommand(SQLquery, connection);
                    rdr = querryCommand.ExecuteReader();

                    // If data exists, email exists
                    while (rdr.Read())
                    {
                        if (rdr[6] == System.DBNull.Value) {
                            incident = new Incident((int)rdr[0], (string)rdr[1], (string)rdr[2], (DateTime)rdr[3], (int)rdr[4], Authenticate.Instance.User, null);
                        } else {

                            User technician = GetUserInfo((int)rdr[6]);
                            incident = new Incident((int)rdr[0], (string)rdr[1], (string)rdr[2], (DateTime)rdr[3], (int)rdr[4], Authenticate.Instance.User, technician);
                        }

                    }

                    rdr.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving data: " + e);
            }      

            return incident;
        }

        public int GetIncidentID(Incident incident) {

            try
            {
                using(NpgsqlConnection connection = new NpgsqlConnection(connectionString())) {
                    NpgsqlDataReader rdr = null;

                    connection.Open();

                    // SQL Command object
                    String SQLquery = "SELECT * FROM \"" + DatabaseNames.TABLE_INCIDENTS + "\" WHERE \"" + 
                                        DatabaseNames.INCIDENTS_DATE_LOGGED + "\" = \'" + 
                                        incident.Date_Logged.ToString("yyyy-MM-dd HH:mm:ss") + 
                                        "\' AND \"" + DatabaseNames.INCIDENTS_USER_ID + "\" = " + incident.user.User_ID;

                    NpgsqlCommand querryCommand = new NpgsqlCommand(SQLquery, connection);
                    rdr = querryCommand.ExecuteReader();

                    // If data exists, email exists
                    while (rdr.Read())
                    {
                        return (int)rdr[0];
                    }

                    rdr.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving data: " + e);
            }      

            return -1;
        } 
        
        /// <summary>
        /// This method retrieves all the incidents from the database.
        /// </summary>
        /// <returns>A list type of Incidents</returns>
        public List<Incident> GetIncidentsFromUser()
        {
            List<Incident> list = new List<Incident>();

            try
            {
                using(NpgsqlConnection connection = new NpgsqlConnection(connectionString())) {
                    NpgsqlDataReader rdr = null;

                    connection.Open();

                    String SQLquery = "SELECT * FROM \"" + DatabaseNames.TABLE_INCIDENTS + "\" WHERE \"" + 
                                        DatabaseNames.INCIDENTS_USER_ID + "\" = " + Authenticate.Instance.User.User_ID;

                    // Pass the connection to a command object
                    NpgsqlCommand command = new NpgsqlCommand(SQLquery, connection);
                    
                    rdr = command.ExecuteReader();


                    while (rdr.Read())
                    {
                        if (rdr[6] == System.DBNull.Value) {
                            list.Add(new Incident((int)rdr[0], (string)rdr[1], (string)rdr[2], (DateTime)rdr[3], (int)rdr[4], Authenticate.Instance.User, null));
                        } else {

                            User technician = GetUserInfo((int)rdr[6]);

                            list.Add(new Incident((int)rdr[0], (string)rdr[1], (string)rdr[2], (DateTime)rdr[3], (int)rdr[4], Authenticate.Instance.User, technician));
                        }

                    }

                    rdr.Close();
                }

            
            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving data: " + e);
            }

            return list;

        }

        public User GetUserInfo(int user_id) {
            User user = null;
            
            try
            {
                using(NpgsqlConnection connection = new NpgsqlConnection(connectionString())) {
                    NpgsqlDataReader rdr = null;

                    connection.Open();

                    // SQL Command object
                    String SQLquery = "SELECT * FROM \"" + DatabaseNames.TABLE_USERS + "\" WHERE \"" + DatabaseNames.USER_ID + "\" = " + user_id;

                    NpgsqlCommand querryCommand = new NpgsqlCommand(SQLquery, connection);
                    rdr = querryCommand.ExecuteReader();

                    // If data exists, assign User details to global user variable
                    while (rdr.Read())
                    {
                        user = new User((int)rdr[0], (string)rdr[1], (string)rdr[2], (string)rdr[3], null, (string)rdr[5], (int)rdr[6]);
                    }

                    rdr.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving data: " + e);
            }

            return user;
        }

        public bool updateProfileField(Object field, UpdateProfileField updatedField) {
            try {
                string updateSQL = "";
                switch(updatedField) {
                    case UpdateProfileField.FirstName: 
                        updateSQL = "UPDATE \"" + DatabaseNames.TABLE_USERS + "\" SET \"" + DatabaseNames.USER_FIRST_NAME + "\"  = '" + (string)field + "' WHERE \"" + DatabaseNames.USER_ID + "\" = " + Authenticate.Instance.User.User_ID;
                        break;
                    case UpdateProfileField.LastName: 
                        updateSQL = "UPDATE \"" + DatabaseNames.TABLE_USERS + "\" SET \"" + DatabaseNames.USER_LAST_NAME + "\" = '" + (string)field + "' WHERE \"" + DatabaseNames.USER_ID + "\" = " + Authenticate.Instance.User.User_ID;
                        break;
                    case UpdateProfileField.Email: 
                        updateSQL = "UPDATE \"" + DatabaseNames.TABLE_USERS + "\" SET \"" + DatabaseNames.USER_EMAIL + "\" = '" + (string)field + "' WHERE \"" + DatabaseNames.USER_ID + "\" = " + Authenticate.Instance.User.User_ID;
                        break;    
                    case UpdateProfileField.ContactNo: 
                        updateSQL = "UPDATE \"" + DatabaseNames.TABLE_USERS + "\" SET \"" + DatabaseNames.USER_CELLPHONE_NO + "\" = '" + (string)field + "' WHERE \"" + DatabaseNames.USER_ID + "\" = " + Authenticate.Instance.User.User_ID;
                        break;
                }
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString()))
                {
                    connection.Open();
                    var command = new NpgsqlCommand(updateSQL, connection);
                    command.ExecuteNonQuery();
                    Authenticate.Instance.updateUserInfo();
                }

                return true;
            } catch (Exception) {
                Console.WriteLine("Failed to update user info: " );
            }
            return false;
        }

        public bool updateProfileField(Object field, UpdateProfileField updatedField, int user_id) {
            try {
                string updateSQL = "";
                switch(updatedField) {
                    case UpdateProfileField.FirstName: 
                        updateSQL = "UPDATE \"" + DatabaseNames.TABLE_USERS + "\" SET \"" + DatabaseNames.USER_FIRST_NAME + "\"  = '" + (string)field + "' WHERE \"" + DatabaseNames.USER_ID + "\" = " + user_id;
                        break;
                    case UpdateProfileField.LastName: 
                        updateSQL = "UPDATE \"" + DatabaseNames.TABLE_USERS + "\" SET \"" + DatabaseNames.USER_LAST_NAME + "\" = '" + (string)field + "' WHERE \"" + DatabaseNames.USER_ID + "\" = " + user_id;
                        break;
                    case UpdateProfileField.Email: 
                        updateSQL = "UPDATE \"" + DatabaseNames.TABLE_USERS + "\" SET \"" + DatabaseNames.USER_EMAIL + "\" = '" + (string)field + "' WHERE \"" + DatabaseNames.USER_ID + "\" = " + user_id;
                        break;    
                    case UpdateProfileField.ContactNo: 
                        updateSQL = "UPDATE \"" + DatabaseNames.TABLE_USERS + "\" SET \"" + DatabaseNames.USER_CELLPHONE_NO + "\" = '" + (string)field + "' WHERE \"" + DatabaseNames.USER_ID + "\" = " + user_id;
                        break;
                }
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString()))
                {
                    connection.Open();
                    var command = new NpgsqlCommand(updateSQL, connection);
                    command.ExecuteNonQuery();
                    Authenticate.Instance.updateUserInfo();
                }

                return true;
            } catch (Exception ex) {
                Console.WriteLine("Failed to update user info: " + ex);
            }
            return false;
        }

        public Boolean updatePassword(String email, String number, String password) {
            try {
                String SQLquery = "SELECT * FROM \"" + DatabaseNames.TABLE_USERS + "\" WHERE \"" + 
                                    DatabaseNames.USER_EMAIL + "\" = \'" + email + "\' AND \"" + 
                                    DatabaseNames.USER_CELLPHONE_NO + "\" = \'" + number + "\'";

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString()))
                {   
                    NpgsqlDataReader rdr = null;
                    connection.Open();
                    var command = new NpgsqlCommand(SQLquery, connection);
                    rdr = command.ExecuteReader();

                    if (rdr.HasRows) {

                        int user_id = -1;

                        while(rdr.Read()) {
                            user_id = (int)rdr[0];
                        }

                        rdr.Close();

                        if (user_id != -1) {
                            string SQLupdate = "UPDATE \"" + DatabaseNames.TABLE_USERS + "\" SET \"" + DatabaseNames.USER_PASSWORD + "\"  = \'" + password + "\' WHERE \"" + DatabaseNames.USER_ID + "\" = " + user_id;
                            
                            var insertCommand = new NpgsqlCommand(SQLupdate, connection);

                            if (insertCommand.ExecuteNonQuery() > 0) {
                                return true;
                            } else {
                                return false;
                            }               
                        }

                    } else {
                        return false;
                    }

                }

                return true;
            } catch (Exception ex) {
                Console.WriteLine("Failed to update user info: " + ex);
            }
            return false;
        }
        
        /// <summary>
        /// This method queries the database for the incidents that where logged within a specified year and month
        /// </summary>
        /// <param name="year">The year that the incidents were logged</param>
        /// <param name="month">The month that the incidents were logged</param>
        /// <returns>A list of type Incident</returns>
        public List<Incident> GetIncidentsOnYearMonth(string year, string month) {
            List<Incident> list = new List<Incident>();

            try
            {
                using(NpgsqlConnection connection = new NpgsqlConnection(connectionString())) {
                    NpgsqlDataReader rdr = null;

                    connection.Open();

                    bool validDate = false;
                    int lastDay = 31;
                    DateTime dateTime;

                    while(!validDate) {
                        try
                        {
                            dateTime = new DateTime(int.Parse(year), int.Parse(month), lastDay);
                            validDate = true;
                        }
                        catch (Exception ex)
                        {
                            lastDay--;
                            Console.WriteLine(ex);
                        }
                    }
 
                    string from = year + "/" + month + "/" + "01";
                    string to = year + "/" + month + "/" + lastDay + " 23:59:59";

                    // Pass the connection to a command object
                    NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM \"Incidents\" WHERE date_logged BETWEEN \'" + from + "\' AND \'" + to + "\'", connection);

                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        if(rdr[4] == System.DBNull.Value) {
                            // list.Add(new Incident((int)rdr[0], (string)rdr[1],(string)rdr[2],(DateTime)rdr[3], -1, (string)rdr[5]));
                        } else {
                            // list.Add(new Incident((int)rdr[0], (string)rdr[1],(string)rdr[2],(DateTime)rdr[3],(int)rdr[4], (string)rdr[5]));
                        }
                        // Console.WriteLine("Line: " + rdr[3] +  rdr[4] + list[0].Technician);
                    }

                    rdr.Close();
                }

            
            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving data: " + e);
            }

            return list;
        }
       
        /// <summary>
        /// This method queries the database to check if the incident is required to be escalated. 
        /// If the incident status is still open after an hour or the incident status is rejected, the incident is escalated.
        /// </summary>
        /// <param name="incident_id">Incident ID for the queried incident</param>
        public void EscalateIncident(int incident_id)
        {
            
            try
            {
                using(NpgsqlConnection connection = new NpgsqlConnection(connectionString())) {
                    NpgsqlDataReader rdr = null;

                    connection.Open();

                    // SQL Command object
                    String SQLquery = String.Format("SELECT * FROM \"" + DatabaseNames.TABLE_INCIDENTS + "\" WHERE \"" + DatabaseNames.INCIDENTS_ID + "\" = " + incident_id);

                    NpgsqlCommand querryCommand = new NpgsqlCommand(SQLquery, connection);
                    rdr = querryCommand.ExecuteReader();

                    // Boolean to check if escalation is required
                    bool needEscalation = false;

                    while (rdr.Read())
                    {
                        // If incident status is open or rejected
                        if ((int)rdr[4] == (int) IncidentStatus.Open || (int)rdr[4] == (int) IncidentStatus.Rejected ) {
                            needEscalation = true;
                        }
                    }

                    rdr.Close();

                    // Update the incident status to rejected if escalation is required
                    if (needEscalation) {

                        String SQLupdate = "UPDATE \"" + DatabaseNames.TABLE_INCIDENTS + "\" SET \"" + DatabaseNames.INCIDENTS_STATUS +
                                            "\" = "+ (int)IncidentStatus.Escalated + " WHERE \"" + DatabaseNames.INCIDENTS_ID + "\" = " + incident_id;                            

                        NpgsqlCommand updateCommand = new NpgsqlCommand(SQLupdate, connection);
                        updateCommand.ExecuteNonQuery();
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving data: " + e);
            }

        }
    

        public List<Incident> GetOpenIncidents() {
            List<Incident> list = new List<Incident>();

            try
            {
                using(NpgsqlConnection connection = new NpgsqlConnection(connectionString())) {
                    NpgsqlDataReader rdr = null;

                    connection.Open();

                    String SQLquery = "SELECT * FROM \"" + DatabaseNames.TABLE_INCIDENTS + "\" WHERE \"" + 
                                        DatabaseNames.INCIDENTS_STATUS + "\" = " + (int)IncidentStatus.Open + " OR \"" +
                                        DatabaseNames.INCIDENTS_STATUS + "\" = " + (int)IncidentStatus.Escalated ;

                    // Pass the connection to a command object
                    NpgsqlCommand command = new NpgsqlCommand(SQLquery, connection);
                    
                    rdr = command.ExecuteReader();


                    while (rdr.Read())
                    {
                        if (rdr[6] == System.DBNull.Value) {
                            User user = GetUserInfo((int)rdr[5]);

                            list.Add(new Incident((int)rdr[0], (string)rdr[1], (string)rdr[2], (DateTime)rdr[3], (int)rdr[4], user, null));
                        } else {

                            User user = GetUserInfo((int)rdr[5]);
                            User technician = GetUserInfo((int)rdr[6]);

                            list.Add(new Incident((int)rdr[0], (string)rdr[1], (string)rdr[2], (DateTime)rdr[3], (int)rdr[4], user, technician));
                        }

                    }

                    rdr.Close();
                }

            
            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving data: " + e);
            }

            return list;
        }
    
        public List<User> GetAvailableTechnicians() {
            List<Incident> incidents = new List<Incident>();
            List<User> technicians = new List<User>();

            try
            {
                using(NpgsqlConnection connection = new NpgsqlConnection(connectionString())) {
                    NpgsqlDataReader rdr = null;

                    connection.Open();

                    String SQLquery = "SELECT * FROM \"" + DatabaseNames.TABLE_INCIDENTS + "\" WHERE (\"" + 
                                        DatabaseNames.INCIDENTS_STATUS + "\" = " + (int)IncidentStatus.Open + " AND \"" +
                                        DatabaseNames.INCIDENTS_TECHNICIAN_ID + "\" IS NOT NULL ) OR (\"" + 
                                        DatabaseNames.INCIDENTS_STATUS + "\" = " + (int)IncidentStatus.Escalated + " AND \"" +
                                        DatabaseNames.INCIDENTS_TECHNICIAN_ID + "\" IS NOT NULL)";

                    String SQLquery1 = "SELECT * FROM \"" + DatabaseNames.TABLE_USERS + "\" WHERE \"" + 
                                        DatabaseNames.USER_ROLE_ID + "\" = " + (int)UserRole.Technician;

                    NpgsqlCommand command = new NpgsqlCommand(SQLquery, connection);
                    
                    rdr = command.ExecuteReader();

                    Console.WriteLine("ddsds");

                    while (rdr.Read())
                    {
                        User user = GetUserInfo((int)rdr[5]);
                        User technician = GetUserInfo((int)rdr[6]);

                        incidents.Add(new Incident((int)rdr[0], (string)rdr[1], (string)rdr[2], (DateTime)rdr[3], (int)rdr[4], user, technician));

                    }

                    rdr.Close();

                    NpgsqlCommand command1 = new NpgsqlCommand(SQLquery1, connection);
                    
                    rdr = command1.ExecuteReader();

                    while (rdr.Read()) {
                        technicians.Add(new User((int)rdr[0], (string)rdr[1], (string)rdr[2], (string)rdr[3], null, (string)rdr[5], (int)rdr[6]));
                    }

                    rdr.Close();

                    foreach (var incident in incidents)
                    {
                        for (var i = 0; i < technicians.Count; i++)
                        {
                            if (incident.Technician.User_ID == technicians[i].User_ID) {
                                technicians.RemoveAt(i);
                                break;
                            }
                        }
                        
                    }

                }

            
            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving data: " + e);
            }

            return technicians;
        }

        public Boolean AssignTechnicianToIncident(int incident_id, int user_id) {
             try {
                string SQLupdate = "UPDATE \"" + DatabaseNames.TABLE_INCIDENTS + "\" SET \"" + DatabaseNames.INCIDENTS_TECHNICIAN_ID + "\"  = " + user_id + " WHERE \"" + DatabaseNames.INCIDENTS_ID + "\" = " + incident_id;

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString()))
                {   
                    connection.Open();
                    var command = new NpgsqlCommand(SQLupdate, connection);
                    if (command.ExecuteNonQuery() > 0) {
                        return true;
                    } else {
                        return false;
                    }

                }

            } catch (Exception ex) {
                Console.WriteLine("Failed to update user info: " + ex);

            }
            return false;
        }
    
        
        public List<Incident> GetAllIncidents()
        {
            List<Incident> list = new List<Incident>();

            try
            {
                using(NpgsqlConnection connection = new NpgsqlConnection(connectionString())) {
                    NpgsqlDataReader rdr = null;

                    connection.Open();

                    String SQLquery = "SELECT * FROM \"" + DatabaseNames.TABLE_INCIDENTS + "\"";

                    // Pass the connection to a command object
                    NpgsqlCommand command = new NpgsqlCommand(SQLquery, connection);
                    
                    rdr = command.ExecuteReader();


                    while (rdr.Read())
                    {
                        if (rdr[6] == System.DBNull.Value) {
                            User user = GetUserInfo((int)rdr[5]);

                            list.Add(new Incident((int)rdr[0], (string)rdr[1], (string)rdr[2], (DateTime)rdr[3], (int)rdr[4], user, null));
                        } else {
                            User user = GetUserInfo((int)rdr[5]);
                            User technician = GetUserInfo((int)rdr[6]);

                            list.Add(new Incident((int)rdr[0], (string)rdr[1], (string)rdr[2], (DateTime)rdr[3], (int)rdr[4], user, technician));
                        }

                    }

                    rdr.Close();
                }

            
            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving data: " + e);
            }

            return list;

        }

        public Boolean reportGenerated(int id, string dateCons) {
            try
            {
                using(NpgsqlConnection connection = new NpgsqlConnection(connectionString())) {
                    connection.Open();

                    String SQLinsert = "INSERT INTO \"Reports\" (\"Report_Request\", \"Report_Description\") VALUES ( '" + id + "' , '" + dateCons + "' )";

                    // Pass the connection to a command object
                    NpgsqlCommand command = new NpgsqlCommand(SQLinsert, connection);
                    
                    if (command.ExecuteNonQuery() > 0) {
                        return true;
                    } else {
                        return false;
                    }

                }

        
            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving data: " + e);
            }
            return false;
        }

        public List<User> GetAllUsers() {
            List<User> users = new List<User>();
            
            try
            {
                using(NpgsqlConnection connection = new NpgsqlConnection(connectionString())) {
                    NpgsqlDataReader rdr = null;

                    connection.Open();

                    // SQL Command object
                    String SQLquery = "SELECT * FROM \"" + DatabaseNames.TABLE_USERS + "\" WHERE \"" + DatabaseNames.USER_ID + "\" != 100";

                    NpgsqlCommand querryCommand = new NpgsqlCommand(SQLquery, connection);
                    rdr = querryCommand.ExecuteReader();

                    // If data exists, assign User details to global user variable

                    while (rdr.Read())
                    {
                        Console.WriteLine((int)rdr[0]);
                        users.Add(new User((int)rdr[0], (string)rdr[1], (string)rdr[2], (string)rdr[3], null, (string)rdr[5], (int)rdr[6]));
                    }

                    rdr.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving data: " + e);
            }

            return users;
        }

        public Incident GetAssignedIncidentToTech() {
            Incident incident = null;

            try
            {
                using(NpgsqlConnection connection = new NpgsqlConnection(connectionString())) {
                    NpgsqlDataReader rdr = null;

                    connection.Open();

                    String SQLquery = "SELECT * FROM \"" + DatabaseNames.TABLE_INCIDENTS + "\" WHERE (\"" + 
                                        DatabaseNames.INCIDENTS_STATUS + "\" = " + (int)IncidentStatus.Open + " AND \"" +
                                        DatabaseNames.INCIDENTS_TECHNICIAN_ID + "\" = " + Authenticate.Instance.User.User_ID + " ) OR (\"" + 
                                        DatabaseNames.INCIDENTS_STATUS + "\" = " + (int)IncidentStatus.Escalated + " AND \"" +
                                        DatabaseNames.INCIDENTS_TECHNICIAN_ID + "\" = " + Authenticate.Instance.User.User_ID + " )";                

                    // Pass the connection to a command object
                    NpgsqlCommand command = new NpgsqlCommand(SQLquery, connection);
                    
                    rdr = command.ExecuteReader();


                    while (rdr.Read())
                    {
                        User user = GetUserInfo((int)rdr[5]);
                        incident = new Incident((int)rdr[0], (string)rdr[1], (string)rdr[2], (DateTime)rdr[3], (int)rdr[4], user, null);
                    }

                    rdr.Close();
                }

            
            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving data: " + e);
            }

            return incident;
        }

        public TaskDetail GetTaskDetail(int incident_id, int technician_id) {
            TaskDetail taskDetail = null;

            try
            {
                using(NpgsqlConnection connection = new NpgsqlConnection(connectionString())) {
                    NpgsqlDataReader rdr = null;

                    connection.Open();

                    String SQLquery = "SELECT * FROM \"" + DatabaseNames.TABLE_TASK_DETAIL + "\" WHERE \"" + 
                                        DatabaseNames.TASK_DETAIL_INCIDENT_ID + "\" = " + incident_id + " AND \"" +
                                        DatabaseNames.TASK_DETAIL_TECHNICIAN_ID + "\" = " + technician_id;

                    // Pass the connection to a command object
                    NpgsqlCommand command = new NpgsqlCommand(SQLquery, connection);
                    
                    rdr = command.ExecuteReader();


                    while (rdr.Read())
                    {
                        string reason = "";
                            Incident incident = GetIncident((int)rdr[3]);
                            User technician = GetUserInfo((int)rdr[4]);

                            if (rdr[2] != System.DBNull.Value) {
                                reason = (string)rdr[2];
                            }

                            taskDetail = new TaskDetail((int)rdr[0], (int)rdr[1], reason, incident, technician);

                    }

                    rdr.Close();
                }

            
            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving data: " + e);
            }

            return taskDetail;
        }

        public Boolean AcceptRejectCloseATask(int task_status, string reason, int incident_id) {
            try
            {
                using(NpgsqlConnection connection = new NpgsqlConnection(connectionString())) {

                    connection.Open();

                    // SQL Command object

                    String SQLinsert = "INSERT INTO public.\"" + DatabaseNames.TABLE_TASK_DETAIL +
                                        "\" ( \"" + DatabaseNames.TASK_DETAIL_STATUS + 
                                        "\", \"" + DatabaseNames.TASK_DETAIL_REASON + 
                                        "\", \""+ DatabaseNames.TASK_DETAIL_INCIDENT_ID + 
                                        "\", \"" + DatabaseNames.TASK_DETAIL_TECHNICIAN_ID +
                                        "\") VALUES(" +
                                        " " + task_status + ", " +
                                        "\'" + reason + "\', " +
                                        + incident_id + ", " +
                                        + Authenticate.Instance.User.User_ID + ")";

                    NpgsqlCommand insertCommand = new NpgsqlCommand(SQLinsert, connection);

                    bool inserted = false;

                    if (insertCommand.ExecuteNonQuery() > 0) {
                        inserted = true;
                    }

                    Console.WriteLine(inserted);
                    if (task_status == (int)IncidentStatus.Rejected) {
                        if (inserted) {
                            string SQLupdate = "UPDATE \"" + DatabaseNames.TABLE_INCIDENTS + "\" SET \"" + DatabaseNames.INCIDENTS_STATUS + "\"  = " + (int)IncidentStatus.Escalated + ", \"" + DatabaseNames.INCIDENTS_TECHNICIAN_ID + "\" = NULL WHERE \"" + DatabaseNames.INCIDENTS_ID + "\" = " + incident_id;

                            NpgsqlCommand updateCommand = new NpgsqlCommand(SQLupdate, connection);

                            if (updateCommand.ExecuteNonQuery() > 0) {
                                return true;
                            }
                        } 
                    } else if ((task_status == (int)IncidentStatus.Closed)) {
                        if (inserted) {
                            string SQLupdate = "UPDATE \"" + DatabaseNames.TABLE_INCIDENTS + "\" SET \"" + DatabaseNames.INCIDENTS_STATUS + "\"  = " + (int)IncidentStatus.Closed + " WHERE \"" + DatabaseNames.INCIDENTS_ID + "\" = " + incident_id;

                            NpgsqlCommand updateCommand = new NpgsqlCommand(SQLupdate, connection);

                            if (updateCommand.ExecuteNonQuery() > 0) {
                                return true;
                            }
                        } 
                    } else {
                        return true;
                    }
                    

                    
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving data: " + e);
            }

            return false;
        }
    
        /// <summary>
        /// This method queries the database to check if the incident is required to be escalated. 
        /// If the incident status is still open after an hour or the incident status is rejected, the incident is escalated.
        /// </summary>
        /// <param name="incident_id">Incident ID for the queried incident</param>
        public List<Incident> GetIncidentsOnYearMonth(DateTime from, DateTime to)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString());
            NpgsqlDataReader rdr = null;
            List<Incident> list = new List<Incident>();

            connection.Open();
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM \"Incidents\" WHERE \"Incident_Date_Logged\" BETWEEN \'" + from + "\' AND \'" + to + "\'", connection);
                rdr = command.ExecuteReader();


                while (rdr.Read())
                {
                    if (rdr[6] == System.DBNull.Value)
                    {
                        User user = GetUserInfo((int)rdr[5]);

                        list.Add(new Incident((int)rdr[0], (string)rdr[1], (string)rdr[2], (DateTime)rdr[3], (int)rdr[4], user, null));
                    }
                    else
                    {

                        User user = GetUserInfo((int)rdr[5]);
                        User technician = GetUserInfo((int)rdr[6]);

                        list.Add(new Incident((int)rdr[0], (string)rdr[1], (string)rdr[2], (DateTime)rdr[3], (int)rdr[4], user, technician));
                    }
                }

                rdr.Close();
            }
            
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving data: " + e);
            }

            return list;
        }

        public List<User> GetAllTechnicians()
        {
            List<Incident> incidents = new List<Incident>();
            List<User> technicians = new List<User>();

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString()))
                {
                    NpgsqlDataReader rdr = null;

                    connection.Open();

                    String SQLquery1 = "SELECT * FROM \"" + DatabaseNames.TABLE_USERS + "\" WHERE \"" +
                                        DatabaseNames.USER_ROLE_ID + "\" = " + (int)UserRole.Technician;

                    NpgsqlCommand command1 = new NpgsqlCommand(SQLquery1, connection);

                    rdr = command1.ExecuteReader();

                    while (rdr.Read())
                    {
                        technicians.Add(new User((int)rdr[0], (string)rdr[1], (string)rdr[2], (string)rdr[3], null, (string)rdr[5], (int)rdr[6]));
                    }

                    rdr.Close();

                    foreach (var incident in incidents)
                    {
                        for (var i = 0; i < technicians.Count; i++)
                        {
                            if (incident.Technician.User_ID == technicians[i].User_ID)
                            {
                                technicians.RemoveAt(i);
                                break;
                            }
                        }

                    }

                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving data: " + e);
            }

            return technicians;
        }
        
        public void InsertIntoReportsTable(int report_request, string dateCons)
        {
            NpgsqlConnection connection = null;
            //instantiate the connection
            connection = new NpgsqlConnection(Database.Instance.connectionString());
            //open connection
            connection.Open();
            //update report table
            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO \"Reports\" (\"Report_Request\", \"Report_Description\") VALUES ('" + report_request + "', '" + dateCons + "' )", connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Report Saved!");
            Console.WriteLine();
            Console.WriteLine("Thank you. Have a nice day!");
            Console.ResetColor();
            Console.WriteLine();
            Console.ReadKey();
        }
    }   

    /// <summary>
    /// An enum representation of incident statuses
    /// </summary>
    public enum IncidentStatus
    {
        Open = 0,
        Accepted = 1,
        Rejected = 2,
        Escalated = 3,
        Closed = 4
    }

    public enum UpdateProfileField
    {
        FirstName,
        LastName,
        Email,
        ContactNo
    }

    public static class DatabaseNames {

        /// Database Table Names
        public static readonly string TABLE_USERS = "Users";
        public static readonly string TABLE_INCIDENTS = "Incidents";
        public static readonly string TABLE_INCIDENT_STATUS = "Incident_Status";
        public static readonly string TABLE_REPORTS = "Reports";
        public static readonly string TABLE_TASK_DETAIL = "Task_Detail";
        public static readonly string TABLE_USER_ROLES = "User_Roles";

        /// Database Field Names
        /// User Field Names
        public static readonly string USER_ID = "User_ID";
        public static readonly string USER_FIRST_NAME = "User_first_name";
        public static readonly string USER_LAST_NAME = "User_last_name";
        public static readonly string USER_EMAIL = "User_email";
        public static readonly string USER_PASSWORD = "User_password";
        public static readonly string USER_CELLPHONE_NO = "User_cellphone_no";
        public static readonly string USER_ROLE_ID = "User_role_id";

        /// User Roles Field Names
        public static readonly string USER_ROLES_ID = "User_Role_ID";
        public static readonly string USER_ROLES_DESCRIPTION = "User_Role_Description";

        /// Incidents Field Names
        public static readonly string INCIDENTS_ID = "Incident_ID";
        public static readonly string INCIDENTS_LOCATION = "Incident_Location";
        public static readonly string INCIDENTS_DESCRIPTION = "Incident_Description";
        public static readonly string INCIDENTS_DATE_LOGGED = "Incident_Date_Logged";
        public static readonly string INCIDENTS_STATUS = "Incident_Status";
        public static readonly string INCIDENTS_USER_ID = "Incident_User_ID";
        public static readonly string INCIDENTS_TECHNICIAN_ID = "Incident_Technician_ID";

        /// Incident Status Field Names
        public static readonly string INCIDENT_STATUS_ID = "Status_ID";
        public static readonly string INCIDENT_STATUS_DESCRIPTION = "Status_Description";

        /// Task Detail Field Names
        public static readonly string TASK_DETAIL_ID = "Task_ID";
        public static readonly string TASK_DETAIL_STATUS = "Task_Status";
        public static readonly string TASK_DETAIL_REASON = "Task_Reason";
        public static readonly string TASK_DETAIL_INCIDENT_ID = "Incident_ID";
        public static readonly string TASK_DETAIL_TECHNICIAN_ID = "Technician_ID";

        /// Reports Field Names
        public static readonly string REPORTS_ID = "Report_ID";
        public static readonly string REPORTS_REQUEST = "Report_Request";
        public static readonly string REPORTS_DESCRIPTION = "Report_Description";

    }
}