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
                                filterIncidentsMenu();
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
                        showMenu = false;
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

        public static void displayIncidents(List<Incident> incidents)
        {
            if(incidents.Count != 0)
            {
                Console.WriteLine("================================================================================================================================================");
                Console.WriteLine("\t \t \t \t \t \t Reported Incidents");
                Console.WriteLine("===========================================================================================================================================");
                Console.WriteLine("{0,-4} {1,-30} {2,-30} {3,-20} {4,-10} {5,-20} {6,-20} ", "ID", "Location", "Description", "Date", "Status", "User", "Technician");
                Console.WriteLine("===========================================================================================================================================");
                string status = "";

                foreach (Incident incident in incidents)
                {
                    switch (incident.Status)
                    {
                        case (int)IncidentStatus.Open:
                            status = "Open";
                            break;
                        case (int)IncidentStatus.Accepted:
                            status = "Accepoted";
                            break;
                        case (int)IncidentStatus.Rejected:
                            status = "Rejected";
                            break;
                        case (int)IncidentStatus.Escalated:
                            status = "Escalated";
                            break;
                        case (int)IncidentStatus.Closed:
                            status = "Closed";
                            break;
                    }
                    if (incident.Technician == null)
                    {
                        Console.WriteLine("{0,-4} {1,-30} {2,-30} {3,-20} {4,-10} {5,-20} {6,-20} ", incident.IncidentID,
                            incident.Location,
                            incident.Description,
                            incident.Date_Logged,
                            status,
                            incident.user.first_name + " " + incident.user.last_name,
                            "Not Assigned");
                    }
                    else
                    {
                        Console.WriteLine("{0,-4} {1,-30} {2,-30} {3,-20} {4,-10} {5,-20} {6,-20} ",
                                                                                                    incident.IncidentID,
                                                                                                    incident.Location,
                                                                                                    incident.Description,
                                                                                                    incident.Date_Logged,
                                                                                                    status,
                                                                                                    incident.user.first_name + " " + incident.user.last_name,
                                                                                                    incident.Technician.first_name + " " + incident.Technician.last_name);
                    }
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("No Incidents Match those filters");
                Console.WriteLine();
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

        public static void displayUsers(List<User> users)
        {
            foreach(var user in users)
            {
                Console.WriteLine("{0, -8} {1,-15} {2,-15} {3,-20} {4,-13}", user.User_ID, user.first_name, user.last_name, user.email, user.cellphone_number);

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
                        showMenu = false;
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

        public static User  selectTechnicianMenu(List<Incident> incidents)
        {
            List<User> list = Database.Instance.GetAllTechnicians();
            bool showMenu = true;
            int pages = (list.Count / 5);
            int last_page = list.Count % 5;
            int option = 0;
            int current_page = 0;
            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine("\n\t \t \t \t \t Incidents");
                Console.WriteLine();

                displayIncidents(incidents);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\nUse Up arrow and Down arrow to move, Left and Right arrow to switch page, enter/spacebar to select, Esc/Escape to go back.");
                if (current_page == pages)
                {
                    Console.WriteLine("\n\t \t \t \t \t All Available Technicians");
                    Console.WriteLine();
                    Console.WriteLine("====================================================================================================================");
                    Console.WriteLine("{0,-4} {1,-4} {2,-30} {3,-30} {4,-20} {5,-10} ", "", "ID", "First Name", "Last Name", "Email", "Cellphone no");
                    Console.WriteLine("====================================================================================================================");
                    for (int i = (current_page * 5); i < ((current_page * 5) + last_page); i++)
                    {
                        displayTechnician(list[i], option, i);
                    }
                    if (list.Count == 0)
                    {
                        Console.WriteLine("\t \t \t \t \t No Available Technicians");
                    }
                }
                else
                {
                    Console.WriteLine("\n\t \t \t \t \t All Incidents Reported");
                    Console.WriteLine();
                    Console.WriteLine("====================================================================================================================");
                    Console.WriteLine("{0,-4} {1,-4} {2,-30} {3,-30} {4,-20} {5,-10} ", "", "ID", "First Name", "Last Name", "Email", "Cellphone no");
                    Console.WriteLine("====================================================================================================================");
                    for (int i = (current_page * 5); i < ((current_page * 5) + 5); i++)
                    {
                        displayTechnician(list[i], option, i);
                    }
                    if (list.Count == 0)
                    {
                        Console.WriteLine("\t \t \t \t \t No Available Technicians");
                    }
                }

                Console.WriteLine("\nPage: " + (current_page + 1) + " of " + (pages + 1));

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:

                        if ((option > (current_page * 5)))
                        {
                            option--;
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.DownArrow:

                        if (current_page == pages)
                        {
                            if ((option < (last_page - 1)))
                            {
                                option++;
                            }
                        }
                        else
                        {
                            if ((option < ((current_page * 5) + 4)))
                            {
                                option++;
                            }
                        }

                        Console.Clear();
                        break;
                    case ConsoleKey.LeftArrow:
                        if (current_page != 0)
                        {
                            current_page--;
                            option = (current_page * 5);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (current_page != pages)
                        {
                            current_page++;
                            option = (current_page * 5);
                        }
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (list.Count > 0)
                        {
                            //showMenu = technicianAssigned(incident, list[option]);
                            return list[option];
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

            return list[option];

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

            string filePath = @"C:\Users\User\Documents\Incident App\Generated Reports\" + dateCons + ".txt";

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
                                        sw.WriteLine("\t \t \t \t \t \t Filtered Incidents");
                                        sw.WriteLine();
                                        sw.WriteLine("================================================================================================================================================");
                                        sw.WriteLine("{0,-4} {1,-30} {2,-30} {3,-20} {4,-10} {5,-20} {6,-20} ", "ID", "Location", "Description", "Date", "Status", "User ID", "Tech ID");
                                        sw.WriteLine("================================================================================================================================================");
                                        string status = "";
                                        foreach (Incident reportedIncident in list)
                                        {
                                            switch (reportedIncident.Status)
                                            {
                                                case (int)IncidentStatus.Open:
                                                    status = "Open";
                                                    break;
                                                case (int)IncidentStatus.Accepted:
                                                    status = "Accepoted";
                                                    break;
                                                case (int)IncidentStatus.Rejected:
                                                    status = "Rejected";
                                                    break;
                                                case (int)IncidentStatus.Escalated:
                                                    status = "Escalated";
                                                    break;
                                                case (int)IncidentStatus.Closed:
                                                    status = "Closed";
                                                    break;
                                            }
                                            if (reportedIncident.Technician == null)
                                            {
                                                sw.WriteLine("{0,-4} {1,-30} {2,-30} {3,-20} {4,-10} {5,-20} {6,-20} ", reportedIncident.IncidentID, reportedIncident.Location, reportedIncident.Description, reportedIncident.Date_Logged, status, reportedIncident.user.first_name + " " + reportedIncident.user.last_name, "Not Assigned");
                                            }
                                            else
                                            {
                                                sw.WriteLine("{0,-4} {1,-30} {2,-30} {3,-20} {4,-10} {5,-20} {6,-20} ", reportedIncident.IncidentID, reportedIncident.Location, reportedIncident.Description, reportedIncident.Date_Logged, status, reportedIncident.user.first_name + " " + reportedIncident.user.last_name, reportedIncident.Technician.first_name + " " + reportedIncident.Technician.last_name);
                                            }
                                        }
                                        sw.WriteLine("================================================================================================================================================");
                                    }
                                }
                                try
                                {
                                    Database.Instance.reportGenerated(Authenticate.Instance.User.User_ID, dateCons);

                                    Console.WriteLine();
                                    Console.WriteLine("Report Saved!");
                                    Console.WriteLine();
                                    Console.WriteLine("Thank you. Have a nice day!");
                                    Console.WriteLine();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Error retrieving data: " + e);
                                }
                                Console.WriteLine("**********************************************");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey(true);
                                showMenu = false;
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

        public static User selectUser(List<Incident> incidentList)
        {
            List<User> list = Database.Instance.GetAllUsers();
            bool showMenu = true;
            int pages = (list.Count / 5);
            int last_page = list.Count % 5;
            int option = 0;
            int current_page = 0;
            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine("\n\t \t \t \t \t Incidents");
                displayIncidents(incidentList);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Use Up arrow and Down arrow to move, Left and Right arrow to switch page, enter/spacebar to select, esc/escape to go back");
                if (current_page == pages)
                {
                    Console.WriteLine("\n\t \t \t \t \t All Users");
                    Console.WriteLine();
                    Console.WriteLine("====================================================================================================================");
                    Console.WriteLine("{0,-4} {1,-4} {2,-30} {3,-30} {4,-20} {5,-10} ", "", "ID", "First Name", "Last Name", "Email", "Cellphone no");
                    Console.WriteLine("====================================================================================================================");
                    for (int i = (current_page * 5); i < ((current_page * 5) + last_page); i++)
                    {
                        displayTechnician(list[i], option, i);
                    }
                }
                else
                {
                    Console.WriteLine("\n\t \t \t \t \t All Users");
                    Console.WriteLine();
                    Console.WriteLine("====================================================================================================================");
                    Console.WriteLine("{0,-4} {1,-4} {2,-30} {3,-30} {4,-20} {5,-10} ", "", "ID", "First Name", "Last Name", "Email", "Cellphone no");
                    Console.WriteLine("====================================================================================================================");
                    for (int i = (current_page * 5); i < ((current_page * 5) + 5); i++)
                    {
                        displayTechnician(list[i], option, i);
                    }
                }

                Console.WriteLine("\nPage: " + (current_page + 1) + " of " + (pages + 1));

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:

                        if ((option > (current_page * 5)))
                        {
                            option--;
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.DownArrow:

                        if (current_page == pages)
                        {
                            if ((option < (last_page - 1)))
                            {
                                option++;
                            }
                        }
                        else
                        {
                            if ((option < ((current_page * 5) + 4)))
                            {
                                option++;
                            }
                        }

                        Console.Clear();
                        break;
                    case ConsoleKey.LeftArrow:
                        if (current_page != 0)
                        {
                            current_page--;
                            option = (current_page * 5);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (current_page != pages)
                        {
                            current_page++;
                            option = (current_page * 5);
                        }
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        return list[option];
                        Console.WriteLine("**********************************************");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
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
            return list[option];
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

        public static void filterIncidentsMenu()//A method that allow the user to update their inforomation
        {
            DateTime fileDate = DateTime.Now;
            string date = fileDate.ToString("yyyy_MM_dd_HH_mm_ss");
            string dateCons = "General_report_" + date;

            string filePath = @"C:\Users\User\Documents\Incident App\Generated Reports\" + dateCons + ".txt";

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(@"C:\Users\User\Documents\Incident App\Generated Reports");
            }
            string year1;
            string year2;
            DateTime from;
            DateTime to;
            List<Incident> FilteredIncidents = Database.Instance.GetAllIncidents();
            bool showMenu = true;
            int option = 1;
            //This is a menu that shows what information the user wants to change, i.e. the First Name, Last Name, Email.
            while (showMenu)
            {
                if(FilteredIncidents.Count == 0)
                {

                    Console.WriteLine();
                    Console.WriteLine("No Incidents");
                    Console.WriteLine("Reseting List");
                    FilteredIncidents = Database.Instance.GetAllIncidents();
                }
                else
                {
                    displayIncidents(FilteredIncidents);
                }
                
                Console.WriteLine();
                Console.WriteLine();
                //Filter by Date
                if (option == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Filter by Date\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("   ");
                    Console.Write("Filter by Date\n");
                }
                //Filter by Technician
                if (option == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Filter by Technician\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("   ");
                    Console.Write("Filter by Technician\n");
                }
                //Filter by User
                //Filter by Status
                if (option == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Filter by Status\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("   ");
                    Console.Write("Filter by Status\n");
                }
                if (option == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Filter by User\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("   ");
                    Console.Write("Filter by User\n");
                }
                if (option == 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.WriteLine("Generate and Save Report\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("   ");
                    Console.WriteLine("Generate and Save Report\n");
                }
                if (option == 6)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.WriteLine("Top menu\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("   ");
                    Console.WriteLine("Top menu\n");
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
                        if (option != 7)
                        {
                            option++;
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        Console.Clear();
                        //The options which allow the user to change/update their information
                        switch (option)
                        {
                            //Update their First Name
                            case 1:
                               
                                if(FilteredIncidents.Count != 0)
                                {
                                    displayIncidents(FilteredIncidents);
                                beginningDate:
                                    Console.WriteLine();

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("From: Enter Year starting date range [format : YYYY/MM/dd] : ");
                                    Console.ResetColor();
                                    year1 = Console.ReadLine();
                                    try
                                    {
                                        from = Convert.ToDateTime(year1);
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Date was in the wrong format");
                                        Console.ResetColor();
                                        goto beginningDate;
                                    }
                                endingDate:
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("To: Enter the ending date range [format : YYYY/MM/dd] : ");
                                    Console.ResetColor();
                                    year2 = Console.ReadLine();
                                    try
                                    {
                                        to = Convert.ToDateTime(year2);
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Date was in the wrong format");
                                        Console.ResetColor();
                                        goto endingDate;
                                    }
                                    FilteredIncidents = Database.Instance.GetIncidentsOnYearMonth(from, to);
                                    Console.Clear();

                                }
                                else
                                {
                                    Console.WriteLine("No incidents found matching those filters");
                                }
                                Console.WriteLine("**********************************************");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey(true);
                                break;
                            case 2:
                                
                                displayIncidents(FilteredIncidents);
                                Console.WriteLine();
                                if(FilteredIncidents.Count != 0)
                                {
                                    List<Incident> dummie = new List<Incident>();
                                    foreach (Incident incident in FilteredIncidents)
                                    {
                                        if (incident.Technician != null)
                                        {
                                            dummie.Add(incident);
                                        }
                                    }
                                    int tech = selectTechnicianMenu(FilteredIncidents).User_ID;
                                    FilteredIncidents = dummie.FindAll(x => x.Technician.User_ID == tech);
                                }
                                else
                                {
                                    Console.WriteLine("No incidents found matching those filters");
                                }
                                Console.Clear();
                                Console.WriteLine("**********************************************");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey(true);
                                break;
                            case 3:
                                Console.WriteLine();
                                int statusFilter = selectStatus(FilteredIncidents);
                                if (FilteredIncidents.Count != 0)
                                {
                                    FilteredIncidents = FilteredIncidents.FindAll(x => x.Status == statusFilter);
                                }
                                else
                                {
                                    Console.WriteLine("No incidents found matching those filters");
                                }
                                Console.Clear();
                                Console.WriteLine("**********************************************");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey(true);
                                break;
                            //Updating the cellphone number    
                            case 4:
                                displayIncidents(FilteredIncidents);

                                Console.WriteLine();
                                if (FilteredIncidents.Count != 0)
                                {
                                    int user = selectUser(FilteredIncidents).User_ID;
                                    FilteredIncidents = FilteredIncidents.FindAll(x => x.user.User_ID == user);
                                }
                                else
                                {
                                    Console.WriteLine("No incidents found matching those filters");
                                }
                                Console.Clear();
                                Console.WriteLine("**********************************************");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey(true);
                                break;
                            case 5:
                                if (!File.Exists(filePath))
                                {
                                    using (StreamWriter sw = File.CreateText(filePath))
                                    {
                                        sw.WriteLine("\t \t \t \t \t \t Filtered Incidents");
                                        sw.WriteLine();
                                        sw.WriteLine("================================================================================================================================================");
                                        sw.WriteLine("{0,-4} {1,-30} {2,-30} {3,-20} {4,-10} {5,-20} {6,-20} ", "ID", "Location", "Description", "Date", "Status", "User ID", "Tech ID");
                                        sw.WriteLine("================================================================================================================================================");
                                        string status = "";
                                        foreach (Incident reportedIncident in FilteredIncidents)
                                        {
                                            switch (reportedIncident.Status)
                                            {
                                                case (int)IncidentStatus.Open:
                                                    status = "Open";
                                                    break;
                                                case (int)IncidentStatus.Accepted:
                                                    status = "Accepoted";
                                                    break;
                                                case (int)IncidentStatus.Rejected:
                                                    status = "Rejected";
                                                    break;
                                                case (int)IncidentStatus.Escalated:
                                                    status = "Escalated";
                                                    break;
                                                case (int)IncidentStatus.Closed:
                                                    status = "Closed";
                                                    break;
                                            }
                                            if(reportedIncident.Technician == null)
                                            {
                                                sw.WriteLine("{0,-4} {1,-30} {2,-30} {3,-20} {4,-10} {5,-20} {6,-20} ", reportedIncident.IncidentID, reportedIncident.Location, reportedIncident.Description, reportedIncident.Date_Logged, status, reportedIncident.user.first_name + " " + reportedIncident.user.last_name, "Not Assigned");
                                            }
                                            else
                                            {
                                                sw.WriteLine("{0,-4} {1,-30} {2,-30} {3,-20} {4,-10} {5,-20} {6,-20} ", reportedIncident.IncidentID, reportedIncident.Location, reportedIncident.Description, reportedIncident.Date_Logged, status, reportedIncident.user.first_name + " " + reportedIncident.user.last_name, reportedIncident.Technician.first_name + " " + reportedIncident.Technician.last_name);
                                            }
                                        }
                                        sw.WriteLine("================================================================================================================================================");
                                    }
                                }
                                try
                                {
                                    Database.Instance.reportGenerated(Authenticate.Instance.User.User_ID, dateCons);

                                    Console.WriteLine();
                                    Console.WriteLine("Report Saved!");
                                    Console.WriteLine();
                                    Console.WriteLine("Thank you. Have a nice day!");
                                    Console.WriteLine();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Error retrieving data: " + e);
                                }
                                Console.WriteLine("**********************************************");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey(true);
                                showMenu = false;
                                break;
                            case 6:
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

        }
        public static int selectStatus(List<Incident> incidents)
        {
            int statusId = 0;
            bool showMenu = true;
            int option = 1;
            while (showMenu)
            {
                if (incidents.Count == 0)
                {

                    Console.WriteLine();
                    Console.WriteLine("No Incidents");
                    Console.WriteLine("Reseting List");
                }
                else
                {
                    displayIncidents(incidents);
                }

                Console.WriteLine();
                Console.WriteLine();
                //Filter by Date
                if (option == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Open\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("   ");
                    Console.Write("Open\n");
                }
                //Filter by Technician
                if (option == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Accepted\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("   ");
                    Console.Write("Accepted\n");
                }
                if(option == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Rejected\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("   ");
                    Console.Write("Rejected\n");
                }
                //Filter by User
                if (option == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Escalated\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("   ");
                    Console.Write("Escalated\n");
                }
                if (option == 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Closed\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("   ");
                    Console.Write("Closed\n");
                }
                if (option == 6)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Top menu\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("   ");
                    Console.Write("Top menu\n");
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
                        if (option != 7)
                        {
                            option++;
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        Console.Clear();
                        //The options which allow the user to change/update their information
                        switch (option)
                        {
                            //Update their First Name
                            case 1:
                                statusId = 0;
                                showMenu = false;
                                break;
                            case 2:
                                statusId = 1;
                                showMenu = false;
                                break;
                            case 3:
                                statusId = 2;
                                showMenu = false;
                                break;
                            //Updating the cellphone number    
                            case 4:
                                statusId = 3;
                                showMenu = false;
                                break;
                            case 5:
                                statusId = 4;
                                showMenu = false;
                                break;
                            case 6:
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
            return statusId;
        }
    }

}