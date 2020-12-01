using System;
using IncidentApp;

namespace Incident_Application
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            LauncherMenu();

            if (Authenticate.Instance.User != null) {
                MainMenu();
            }

            
        }

        static void LauncherMenu() {

            MainMenu:
            Console.Clear();
            bool showMenu = true;
            int option = 1;
            while(showMenu) {
                Console.WriteLine("Welcome to the GIJIMA Incident App\n");
                Console.WriteLine("Use Up arrow and Down arrow to move, enter/spacebar to select\n");
                if(option == 1) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Register\n");
                    Console.ResetColor();
                } else {
                    Console.Write("   ");
                    Console.Write("Register\n");
                }
                if(option == 2) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Login\n");
                    Console.ResetColor();
                } else {
                    Console.Write("   ");
                    Console.Write("Login\n");
                }

                if(option == 3) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Forgot Password\n");
                    Console.ResetColor();
                } else {
                    Console.Write("   ");
                    Console.Write("Forgot Password\n");
                }

                if(option == 4) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Exit\n");
                    Console.ResetColor();
                } else {
                    Console.Write("   ");
                    Console.Write("Exit\n");
                }
                
                switch(Console.ReadKey(true).Key) {
                    case ConsoleKey.UpArrow:
                    
                        if (option != 1) {
                            option--;
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.DownArrow:
                        if (option != 4) {
                            option++;
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        Console.Clear();
                        switch(option) {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                                showMenu = false;
                                break;
           
                        }
                        break;
                    default:
                        Console.WriteLine("\nInvalid key, use Up/Down arrow to move, enter/spacebar to select");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        Console.Clear();
                        break;    
                }

            }

            switch(option) {
                case 1:
                    if (Authenticate.Instance.Registration()) {
                        goto MainMenu;
                    }
                    break;
                case 2:
                    if (!Authenticate.Instance.Login()) {
                        goto MainMenu;
                    }
                    break;
                case 3:
                    if (Authenticate.Instance.ForgotPassword()) {
                        goto MainMenu;
                    }
                    break;
                case 4:
                    Console.WriteLine("Exiting Application");
                    break;            

            }

        }

        static void MainMenu() {
            Console.Clear();
            bool showMenu = true;
            while(showMenu) {
                switch(Authenticate.Instance.User.user_role) {
                    case (int)UserRole.Manager:
                        showMenu = ManagerFunctionality.ManagerMainMenu();
                        break;
                    case (int)UserRole.User:
                        showMenu = UserFunctionality.UserMainMenu();
                        break;
                    case (int)UserRole.Technician:
                        showMenu = TechnicianFunctionality.TechnicianMainMenu();
                        break;
                    default:
                        break;            
                }
            }
        }
    
    }

}
