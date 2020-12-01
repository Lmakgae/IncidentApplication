using System;

namespace IncidentApp
{
    public static class TechnicianFunctionality {
        public static Incident incident = Database.Instance.GetAssignedIncidentToTech();
        public static TaskDetail taskDetail = null;
        public static bool TechnicianMainMenu() {//Options where the user chooses which tab they want to go to
        
            if (incident != null) {
                taskDetail = Database.Instance.GetTaskDetail(incident.IncidentID, Authenticate.Instance.User.User_ID);
            }

            bool showMenu = true;
            int option = 1;
            while(showMenu) {
                Console.Clear();
                Console.WriteLine("Welcome to the GIJIMA Incident App, " + Authenticate.Instance.User.first_name + "\n");

                if (incident != null) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("*You have an incident assigned to you*\n");
                    Console.ResetColor();
                } else {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("*You have no incident assigned yet*\n");
                    Console.ResetColor();
                }
                
                Console.WriteLine("Use Up arrow and Down arrow to move, enter/spacebar to select");
                if(option == 1) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("View assigned incident\n");
                    Console.ResetColor();
                } else {
                    Console.Write("   ");
                    Console.Write("View assigned incident\n");
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
                                //The option to open the Incident Log Method
                                ViewAssignedIncidentMenu();
                                break;
                            case 2:
                                
                                Console.WriteLine("List of logged incidents ");

                                //The option to View the Incidents that the user has logged
                                //ViewStatus();
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

        public static void ViewAssignedIncidentMenu() {

            bool showMenu = true;
            int option = 1;
            while(showMenu) {
                Console.Clear();

                if (incident == null) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t*There isn't an incident that is assigned to you at the moment*");
                    Console.ResetColor();
                } else {
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
                    Console.WriteLine("Description : {0}", incident.Description);
                    Console.WriteLine();
                    Console.WriteLine("=================================================================");
                    Console.WriteLine("=================================================================");
                }
           
                Console.WriteLine("\nUse Up arrow and Down arrow to move, enter/spacebar to select");
                if(option == 1) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (incident == null) {
                        Console.Write("*  ");
                        Console.Write("\u21B5 Go back\n");
                    } else if ((incident != null) && (taskDetail == null)) {
                        Console.Write("*  ");
                        Console.Write("Accept\n");
                    } else if ((incident != null) && (taskDetail != null)) {
                        Console.Write("*  ");
                        Console.Write("Close incident\n");
                    }
                    Console.ResetColor();
                } else {
                    if (incident == null) {
                        Console.Write("   ");
                        Console.Write("\u21B5 Go back\n");
                    } else if ((incident != null) && (taskDetail == null)) {
                        Console.Write("   ");
                        Console.Write("Accept\n");
                    } else if ((incident != null) && (taskDetail != null)) {
                        Console.Write("   ");
                        Console.Write("Close incident\n");
                    }
                }
                if(option == 2) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if ((incident != null) && (taskDetail == null)) {
                        Console.Write("*  ");
                        Console.Write("Reject\n");
                    } else if ((incident != null) && (taskDetail != null)) {
                        Console.Write("*  ");
                        Console.Write("\u21B5 Go back\n");
                    }
                    Console.ResetColor();
                } else {
                    if ((incident != null) && (taskDetail == null)) {
                        Console.Write("   ");
                        Console.Write("Reject\n");
                    } else if ((incident != null) && (taskDetail != null)) {
                        Console.Write("   ");
                        Console.Write("\u21B5 Go back\n");
                    }
                }
                if(option == 3) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if ((incident != null) && (taskDetail == null)) {
                        Console.Write("*  ");
                        Console.Write("\u21B5 Go back\n");
                    }
                    Console.ResetColor();
                } else {
                    if ((incident != null) && (taskDetail == null)) {
                        Console.Write("   ");
                        Console.Write("\u21B5 Go back\n");
                    }
                }

                switch(Console.ReadKey().Key) {
                    case ConsoleKey.UpArrow:
                        if (option != 1) {
                            option--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (incident == null) {

                        } else if ((incident != null) && (taskDetail == null)) {
                            if (option != 3) {
                                option++;
                            }
                        } else if ((incident != null) && (taskDetail != null)) {
                            if (option != 2) {
                                option++;
                            }
                        }
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        Console.Clear();
                        switch(option) {
                            case 1:
                                if (incident == null) {
                                    showMenu = false;
                                } else if ((incident != null) && (taskDetail == null)) {
                                    //Accepting a task
                                    if (Database.Instance.AcceptRejectCloseATask((int)IncidentStatus.Accepted, "", incident.IncidentID)) {
                                        incident = Database.Instance.GetAssignedIncidentToTech();
                                        taskDetail = Database.Instance.GetTaskDetail(incident.IncidentID, Authenticate.Instance.User.User_ID);
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("\nTask has been accepted successfully...");
                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ResetColor();
                                        Console.ReadKey(true);
                                    } else {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\nTask failed to be accepted, try again later");
                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ResetColor();
                                        Console.ReadKey(true);
                                    }
                                } else if ((incident != null) && (taskDetail != null)) {
                                    //Closing a task
                                    if (Database.Instance.AcceptRejectCloseATask((int)IncidentStatus.Closed, "", incident.IncidentID)) {
                                        incident = Database.Instance.GetAssignedIncidentToTech();
                                        if (incident == null) {
                                            taskDetail = null;
                                        }
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("\nTask has been closed successfully...");
                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ResetColor();
                                        Console.ReadKey(true);
                                    } else {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\nTask failed to close, try again later");
                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ResetColor();
                                        Console.ReadKey(true);
                                    }
                                }
                                
                                break;
                            case 2:
                                if ((incident != null) && (taskDetail == null)) {
                                    //Reject a task
                                    Console.Clear();
                                    Console.WriteLine("Please enter your reason for rejecting the task: ");
                                    string reason = Console.ReadLine();
                                    while(String.IsNullOrEmpty(reason) || String.IsNullOrWhiteSpace(reason)) {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid reason. Reason can not be empty\n");
                                        Console.ResetColor();
                                        Console.WriteLine("Please enter your reason for rejecting the task: ");
                                        reason = Console.ReadLine();
                                    }
                                    
                                    if (Database.Instance.AcceptRejectCloseATask((int)IncidentStatus.Rejected, reason, incident.IncidentID)) {
                                        incident = Database.Instance.GetAssignedIncidentToTech();
                                        if (incident == null) {
                                            taskDetail = null;
                                        }
                                        Console.ReadKey(true);
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("\nTask has been rejected successfully...");
                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ResetColor();
                                        Console.ReadKey(true);
                                    } else {
                                        Console.ReadKey(true);
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\nTask failed to be accepted, try again later");
                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ResetColor();
                                        Console.ReadKey(true);
                                    }
                                    showMenu = false;
                                } else if ((incident != null) && (taskDetail != null)) {
                                    showMenu = false;
                                }
                                break;
                            case 3: 
                                //The option to exit the tab
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
                                while(string.IsNullOrEmpty(firstName) || string.IsNullOrWhiteSpace(firstName) || firstName == Authenticate.Instance.User.first_name ) 
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nFirst name already exists or input is invalid!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("\nPlease enter a valid first name: ");
                                    firstName = Console.ReadLine();
                                }
                                Database.Instance.updateProfileField(firstName, UpdateProfileField.FirstName);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYour updated name is: " + firstName);
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
                                while(string.IsNullOrEmpty(lastName) || string.IsNullOrWhiteSpace(lastName) || lastName == Authenticate.Instance.User.last_name ) 
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nLast name already exists or last name is invalid!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("\nPlease enter a valid last name: ");
                                    lastName = Console.ReadLine();
                        
                                }
                                
                                Database.Instance.updateProfileField(lastName, UpdateProfileField.LastName);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYour updated last name is: " + lastName);
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
                                        email == Authenticate.Instance.User.email ||
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
                                
                                Database.Instance.updateProfileField(email, UpdateProfileField.Email);
                            
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYour updated last email is: " + email);
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
                                while(Validators.isPhoneNumber(cell) != true)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nInvalid Contact Details");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("\nEnter your Phone Number: ");
                                    cell = Console.ReadLine();
                                    
                                }
                                while(string.IsNullOrEmpty(cell) || 
                                    string.IsNullOrWhiteSpace(cell) || 
                                    cell == Authenticate.Instance.User.cellphone_number || 
                                    !Validators.isPhoneNumber(cell) ) 
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nCellphone number already exists or Cellphone number is invalid!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("\nPlease enter a valid Cellphone number: ");
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