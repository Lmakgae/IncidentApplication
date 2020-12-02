using System;
using System.Collections.Generic;

namespace IncidentApp
{
    public static class UserFunctionality {

        public static bool UserMainMenu() {//Options where the user chooses which tab they want to go to
        
            bool showMenu = true;
            int option = 1;
            while(showMenu) {
                Console.Clear();
                Console.WriteLine("Welcome to the GIJIMA Incident App, " + Authenticate.Instance.User.first_name + "\n");
                Console.WriteLine("Use Up arrow and Down arrow to move, enter/spacebar to select");
                if(option == 1) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Report an Incident\n");
                    Console.ResetColor();
                } else {
                    Console.Write("   ");
                    Console.Write("Report an Incident\n");
                }
                if(option == 2) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("View Incidents Logged\n");
                    Console.ResetColor();
                } else {
                    Console.Write("   ");
                    Console.Write("View Incidents Logged\n");
                }
                if(option == 3) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Manage profile\n");
                    Console.ResetColor();
                } else {
                    Console.Write("   ");
                    Console.Write("Manage profile\n");
                }
                if(option == 4) {
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
                        break;
                    case ConsoleKey.DownArrow:
                        if (option != 4) {
                            option++;
                        }
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        Console.Clear();
                        switch(option) {
                            case 1:
                                Console.WriteLine("\nReport an Incident: " +"\n");

                                //The option to open the Incident Log Method
                                LogIncident();
                                break;
                            case 2:
                                
                                Console.WriteLine("List of logged incidents ");

                                //The option to View the Incidents that the user has logged
                                ViewStatus();
                                break;
                            case 3: 
                                //The option to Manage the user's Profile
                                ManageProfile();
                                break;
                            case 4: 
                                //The option to exit the tab
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

        public static void LogIncident()//A method that allows the user to Report their incidents 
        {   
            
            //The user is prompted to log the incident which requires them to enter the decrtion and the location of the incident
            Console.WriteLine("**********************************************\n");
            Console.WriteLine("Enter incident description: ");
            string incidentDescription = Console.ReadLine();
            while(string.IsNullOrEmpty(incidentDescription) || string.IsNullOrWhiteSpace(incidentDescription) || !Validators.isValidInputString(incidentDescription)) {
                Console.WriteLine("Invalid! Please enter valid description: ");
                incidentDescription = Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine("Enter incident location: ");
            Console.WriteLine("i.e. Gijima Midrand, Gazelle Close, Floor 2, room: Siyabonga");
            string incidentLocation = Console.ReadLine();
            while(string.IsNullOrEmpty(incidentLocation) || string.IsNullOrWhiteSpace(incidentLocation)|| !Validators.isValidInputLocString(incidentDescription)) {
                Console.WriteLine("Invalid! Please enter valid location: ");
                Console.WriteLine("i.e. Gijima Midrand, Gazelle Close, Floor 2, room: Siyabonga");
                incidentLocation = Console.ReadLine();
            }
            DateTime date = DateTime.Now;

            //The input that will be saved in the database
            Incident incident = new Incident(0, incidentLocation, incidentDescription, date, 0, Authenticate.Instance.User, null);

            Console.Clear();
            if (Database.Instance.LogIncident(incident)) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Incident Successfully logged!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ForegroundColor = ConsoleColor.White;

                /// Set timer for escalation
                IncidentSystem.Instance.setTimerForEscalation(Database.Instance.GetIncidentID(incident), false);
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An error has occured! Please contact administrator");
                Console.WriteLine("\nPress any key to continue...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.ReadKey(true);
        }

        public static void ViewStatus()//A method that allows the user to view all te incidents they logged
        {
            //This is a list of the incidents that the user has logged. It only shows the Incident ID, Description, Date and status
            List<Incident> incidents = Database.Instance.GetIncidentsFromUser();
            Console.WriteLine("\nIncident ID \t Description \t\t Staus \t\t\t Technician");
            Console.WriteLine("********************************************************************************************");
            foreach (var incident in incidents)
            {
                string status = "";
                switch(incident.Status) {
                    case (int)IncidentStatus.Open:
                        status = "Open";
                        break;
                    case (int)IncidentStatus.Accepted:
                        status = "Accepted";
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
                if (incident.Technician == null) {
                    Console.WriteLine(incident.IncidentID+ "\t\t " + incident.Description + "\t\t "+ status + "\t\t " + "Not Assigned");
                } else {
                    Console.WriteLine(incident.IncidentID+ "\t\t " + incident.Description + "\t\t "+ status + "\t\t " + incident.Technician.first_name + " " + incident.Technician.last_name);
                }
            }
            Console.WriteLine("********************************************************************************************");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }

        public static void ManageProfile()//A method that allow the user to update their inforomation
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
                Console.WriteLine("Choose from the following options: ");
                Console.WriteLine("Use Up arrow and Down arrow to move, enter/spacebar to select");
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
                                Console.WriteLine("You are updating your first name: " + Authenticate.Instance.User.first_name);
                                Console.WriteLine("\nPlease enter the first name you wish to replace it with");
                                firstName = Console.ReadLine();
                                while(string.IsNullOrEmpty(firstName) || string.IsNullOrWhiteSpace(firstName) || !Validators.isValidString(firstName)) 
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n Firs name is invalid!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("\nPlease enter a valid first name: ");
                                    firstName = Console.ReadLine();
                                }
                                //Checks if the first name of the user is the same as in the database
                                while( firstName == Authenticate.Instance.User.first_name )
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nFirst name is already saved ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("\nPlease enter a different first name: ");
                                    firstName = Console.ReadLine();
                                }
                                Database.Instance.updateProfileField(firstName, UpdateProfileField.FirstName);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYour updated name is: " + Authenticate.Instance.User.first_name);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("**********************************************"); 
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey(true);
                                break;
                            //Updating the user Last Name
                            case 2:
                                Console.WriteLine("**********************************************");
                                Console.WriteLine("You are updating your last name: " + Authenticate.Instance.User.last_name);
                                Console.WriteLine("\nPlease enter the name you wish to replace it with");
                                lastName = Console.ReadLine();
                                while(string.IsNullOrEmpty(lastName) || string.IsNullOrWhiteSpace(lastName)  || !Validators.isValidString(firstName)  ) 
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nLast name is invalid!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("\nPlease enter a valid last name: ");
                                    lastName = Console.ReadLine();
                        
                                }
                                //Checks if the last name of the user is the same as in the database
                                while(lastName == Authenticate.Instance.User.last_name)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nLast name is already saved ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("\nPlease enter a different last name: ");
                                    lastName = Console.ReadLine();
                                }
                                
                                Database.Instance.updateProfileField(lastName, UpdateProfileField.LastName);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYour updated last name is: " + Authenticate.Instance.User.last_name);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("**********************************************");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey(true);
                                break;
                            //Updating the email    
                            case 3: 
                                Console.WriteLine("**********************************************");
                                Console.WriteLine("You are updating your email: " + Authenticate.Instance.User.email);
                                Console.WriteLine("\nPlease enter the email you wish to replace it with");
                                email = Console.ReadLine();

                                while(string.IsNullOrEmpty(email) || 
                                        string.IsNullOrWhiteSpace(email) || 
                                        !Validators.isValidEmail(email)) 
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nEmail is invalid!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("\nPlease enter a valid email: ");
                                    email = Console.ReadLine();
                        
                                }
                                while( Database.Instance.EmailExists(email))
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nEmail is already saved");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("\nPlease enter a different email: ");
                                    email = Console.ReadLine();
                                }
                                Database.Instance.updateProfileField(email, UpdateProfileField.Email);
                            
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYour updated last email is: " + Authenticate.Instance.User.email);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("**********************************************");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey(true);
                                break;
                            //Updating the cellphone number    
                            case 4: 
                                Console.WriteLine("**********************************************");
                                Console.WriteLine("You are updating your cell phone number to: " + Authenticate.Instance.User.cellphone_number);
                                Console.WriteLine("\nPlease enter the cellphone number you wish to replace it with");
                                cell = Console.ReadLine();
                                while(Validators.isPhoneNumber(cell) != true|| string.IsNullOrEmpty(cell) || 
                                    string.IsNullOrWhiteSpace(cell) || !Validators.isPhoneNumber(cell) )
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nInvalid Contact Details");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("\nEnter your Phone Number: ");
                                    cell = Console.ReadLine();
                                    
                                }
                                while( cell == Authenticate.Instance.User.cellphone_number) 
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nCellphone number already exists");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("\nPlease enter a different Cellphone number: ");
                                    cell = Console.ReadLine();
                        
                                }
                                
                                Database.Instance.updateProfileField(cell, UpdateProfileField.ContactNo);
                                
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYour updated last cellphone number is: " + Authenticate.Instance.User.cellphone_number);
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
        
        }

    }
}