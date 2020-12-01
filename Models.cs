using System;

namespace IncidentApp
{
    /// <summary>
    /// A user model
    /// </summary>
    public class User{
        public int User_ID {get; set;}
        public string first_name {get; set;}
        public string last_name {get; set;}
        public string email {get; set;}
        public string password {get; set;}
        public string cellphone_number {get; set;}
        public int user_role {get; set;}
        
        public User(int User_ID, string first_name, string last_name, string email, string password, string cellphone_number, int user_role) {
            this.User_ID = User_ID;
            this.first_name = first_name;
            this.last_name = last_name;
            this.email = email;
            this.password = password;
            this.cellphone_number = cellphone_number;
            this.user_role = user_role;
        }

    }

    public enum UserRole
    {
        Manager = 0,
        User = 1,
        Technician = 2
    }

    /// <summary>
    /// An Incident model
    /// </summary>
    public class Incident {
        public int IncidentID {get;}
        public string Location {get;}
        public string Description {get;}
        public DateTime Date_Logged {get;}
        public int Status {get;}
        public User user {get;}
        public User Technician {get;}
        
        public Incident(int IncidentID, string Location, string Description, DateTime Date_Logged, int Status, User user, User Technician) {
            this.IncidentID = IncidentID;
            this.Location = Location;
            this.Description = Description;
            this.Date_Logged = Date_Logged;
            this.Status = Status;
            this.user = user;
            this.Technician = Technician;       
        }

    }

    public class TaskDetail {
        public int Task_ID {get;}
        public int Task_Status {get;}
        public string Task_Reason {get;}
        public Incident Incident {get;}
        public User Technician {get;}

        public TaskDetail(int Task_ID, int Task_Status, string Task_Reason, Incident Incident, User Technician) {
            this.Task_ID = Task_ID;
            this.Task_Status = Task_Status;
            this.Task_Reason = Task_Reason;
            this.Incident = Incident;
            this.Technician = Technician;       
        }
    }
    
}