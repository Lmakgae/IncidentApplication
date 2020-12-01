using System;
using System.Security;

namespace IncidentApp {

    public sealed class Authenticate {
        private static readonly Authenticate instance = new Authenticate();
        private static User user = null;

        static Authenticate() {}

        private Authenticate() {}

        public static Authenticate Instance {
            get {
                return instance;
            }
        }

        public User User {
            get {
                return user;
            }
        }
        
        public Boolean Login() {
            Console.Clear();

            string email;
            string password;

            Console.Write("Enter your email: ");
            email = Console.ReadLine();

            while(!Validators.isValidEmail(email)) //Ensure that the user enters the username
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("*Email is invalid");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter your email: ");
                email = Console.ReadLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            passlogin:
            Console.Write("Enter your password: ");
            SecureString pass = passwordMasking();
            password = new System.Net.NetworkCredential(string.Empty, pass).Password;
            
            while(password.Length < 1) //Ensure that the user enters the password
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("*Password is required");
                Console.ForegroundColor = ConsoleColor.White;
                goto passlogin;

            }
            user = Database.Instance.Login(email, password);

            if (user != null) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("\nLogin Successful...");
                Console.WriteLine("\nPress any key to continue...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey(true);
                return true;
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nIncorrect Email or Password...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey(true);
                return false;
            }

        }

        public Boolean Registration() {
            string cNo;
            int role;
            string fname;
            string lname;
            string email;
            string password;
            string confirmPass;

            Console.WriteLine("Please Register Below...\n");
            Console.Write("Enter your first Name: ");
            fname = Console.ReadLine();
            while(!Validators.isValidString(fname)) //check if the user entered letters only
            {   
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter a valid name");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter your first Name: ");
                fname = Console.ReadLine();
            }

            Console.Clear();
            Console.Write("Enter your Last Name: ");
            lname = Console.ReadLine();
            while(!Validators.isValidString(lname))  //check if the user entered letters only
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter a valid last name");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter your first Name: ");
                lname = Console.ReadLine();
            }

            Console.Clear();
            Console.Write("Enter your Email Address: ");
            email = Console.ReadLine();

            bool emailInvalid = true;

            do {
                bool valid = Validators.isValidEmail(email);
                if (valid) {
                    if (Database.Instance.EmailExists(email)) {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The email "+ email + " already Exists");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Enter your Email Address: ");
                        email = Console.ReadLine();
                    } else {
                        emailInvalid = false;
                    }
                } else {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid email address.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Enter your Email Address: ");
                    email = Console.ReadLine();
                }
                
            } while(emailInvalid);

            Console.Clear();
            Console.Write("Enter your Phone Number: ");
            cNo = Console.ReadLine();
            while(!Validators.isPhoneNumber(cNo))  //validate if the user enters a valid contact details
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Contact Details");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter your Phone Number: ");
                cNo = Console.ReadLine();
            }

            role = chooseUserRoleMenu();

            if (role == -1) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Registration cancelled\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                return false;
            }

            Console.Clear();
            password:
            Console.Write("Enter Password: "); 
            SecureString pass = passwordMasking();
            password = new System.Net.NetworkCredential(string.Empty, pass).Password; 

            while(!Validators.passwordMeetsCriteria(password))  //check if the user enters a valid password with correct characters
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Password must at least:\n* Be 8 characters long\n* Contain an uppercase and lowercase\n* Contain a number\n* Contain a symbol/special character\n");
                Console.ForegroundColor = ConsoleColor.White;
                goto password;
            }

            Console.Clear();
            Console.Write("Confirm Password: ");
            SecureString conPass = passwordMasking();
            confirmPass = new System.Net.NetworkCredential(string.Empty, conPass).Password; 

            //check if the password matches with the confirm password
            while(password != confirmPass)   
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nPassword does not match\n");
                Console.ForegroundColor = ConsoleColor.White;
                goto password;
            }

            User registrationUser = new User(0, fname, lname, email, password, cNo, role);
            
            if (registerOrCancelMenu(registrationUser) > 0) {
                if(Database.Instance.Register(registrationUser)) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Account has been created Successfully\n");
                    Console.ForegroundColor = ConsoleColor.White;

                }
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Registration cancelled\n");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            return true;
        }

        public Boolean ForgotPassword() {
            string generatedOtp = "8976";
            string confirmNewPass;
            string password;
            string email;
            string cNo;

            Console.Write("Please enter your email address: ");
            email = Console.ReadLine();
            while(!Validators.isValidEmail(email)) //Checking if the user Entered a valid email
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter a valid email address.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nEnter your Email Address: ");
                email = Console.ReadLine();
            }

            Console.Write("Please enter your contact details: ");
            cNo = Console.ReadLine();
            while(!Validators.isPhoneNumber(cNo))   //Validate if the user entered valid phone number
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Contact Details");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nEnter your Phone Number: ");
                cNo = Console.ReadLine();
            }

            Console.Clear();
            Console.Write("Please enter an OTP sent to your phone: ");
            string Userotp = Console.ReadLine();

            while(Userotp != generatedOtp) {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Invalid OTP!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPlease enter an OTP sent to your phone: ");
                string response = Console.ReadLine();
            }

            Console.Clear();
            forgotPassword:
            Console.Write("Enter a new password: ");
            SecureString pass = passwordMasking();
            password = new System.Net.NetworkCredential(string.Empty, pass).Password; //Store the entered password into the variable password

            while(!Validators.passwordMeetsCriteria(password))   
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Password must at least:\n* Be 8 characters long\n* Contain an uppercase and lowercase\n* Contain a number\n* Contain a symbol/special character\n");
                Console.ForegroundColor = ConsoleColor.White;
                goto forgotPassword;
            }

            Console.Clear();
            Console.Write("Confirm Password: ");
            SecureString passCon = passwordMasking();
            confirmNewPass = new System.Net.NetworkCredential(string.Empty, passCon).Password;
        
            while(password != confirmNewPass)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nPassword does not match");
                Console.ForegroundColor = ConsoleColor.White;
                goto forgotPassword;        
            }

            if (Database.Instance.updatePassword(email, cNo, confirmNewPass)) {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Password has been changed successfully!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey(true);
                
            } else {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Password failed to be changed...\nTry again or contact manager");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey(true);
            }
                  
            return true;
        }

        private SecureString passwordMasking()
        {
            ConsoleKeyInfo keyInfo;
            SecureString pass = new SecureString();
            do
            {
                keyInfo = Console.ReadKey(true);
                if (!char.IsControl(keyInfo.KeyChar))
                {
                    pass.AppendChar(keyInfo.KeyChar);
                    Console.Write("*");
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && pass.Length > 0 )
                {
                    pass.RemoveAt(pass.Length - 1);
                    Console.Write("\b \b");
                }
            }
            while (keyInfo.Key != ConsoleKey.Enter);
            {
                return pass;
            }
        }

        private int chooseUserRoleMenu() {

            Console.Clear();
            bool showMenu = true;
            int option = 1;
            while(showMenu) {
                Console.WriteLine("Choose role from the following options: ");
                Console.WriteLine("Use Up arrow and Down arrow to move, enter/spacebar to select");
                if(option == 1) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Manager\n");
                    Console.ResetColor();
                } else {
                    Console.Write("   ");
                    Console.Write("Manager\n");
                }
                if(option == 2) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("User\n");
                    Console.ResetColor();
                } else {
                    Console.Write("   ");
                    Console.Write("User\n");
                }
                if(option == 3) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Technician\n");
                    Console.ResetColor();
                } else {
                    Console.Write("   ");
                    Console.Write("Technician\n");
                }
                if(option == 4) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.WriteLine("Cancel Registration\n");
                    Console.ResetColor();
                } else {
                    Console.Write("   ");
                    Console.WriteLine("Cancel Registration\n");
                }

                switch(Console.ReadKey().Key) {
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
                                return 0;
                            case 2:
                                return 1;
                            case 3: 
                                return 2;
                            case 4: 
                                showMenu = false;
                                return -1;            
                        }
                        break;
                    default:
                        Console.WriteLine("\nInvalid key, use Up/Down arrow to move, enter/spacebar to select");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        break;    
                }

            }
            return -1;
        }
    
        private int registerOrCancelMenu(User user) {
            Console.Clear();
            bool showMenu = true;
            int option = 1;
            while(showMenu) {
                Console.WriteLine("Confirm registration details:\n");
                Console.WriteLine("First name: " + user.first_name);
                Console.WriteLine("Last name: " + user.last_name);
                Console.WriteLine("Email address: " + user.email);
                Console.Write("Role: ");
                switch(user.user_role) {
                    case 0:
                        Console.Write(UserRole.Manager);
                        break;
                    case 1:
                        Console.Write(UserRole.User);
                        break;
                    case 2:
                        Console.Write(UserRole.Technician);
                        break;    
                }

                Console.WriteLine();
                Console.Write("Password: ");
                displayMaskedPassword(user.password);
                Console.Write("\n");

                Console.WriteLine("\nUse Up arrow and Down arrow to move, enter/spacebar to select");
                if(option == 1) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Confirm registration\n");
                    Console.ResetColor();
                } else {
                    Console.Write("   ");
                    Console.Write("Confirm registration\n");
                }
                if(option == 2) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*  ");
                    Console.Write("Cancel registration\n");
                    Console.ResetColor();
                } else {
                    Console.Write("   ");
                    Console.Write("Cancel registration\n");
                }
                
                switch(Console.ReadKey().Key) {
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
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        Console.Clear();
                        switch(option) {
                            case 1:
                                return 1;
                            case 2: 
                                showMenu = false;
                                return -1;            
                        }
                        break;
                    default:
                        Console.WriteLine("\nInvalid key, use Up/Down arrow to move, enter/spacebar to select");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        break;    
                }

            }
            return -1;
        }

        private void displayMaskedPassword(string password) {
            for(int i = 0; i < password.Length; i++) {
                Console.Write("*");
            }
        }
        
        public void updateUserInfo() {
            user = Database.Instance.GetUserInfo(user.User_ID);
        }
    }


}