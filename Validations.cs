using System;
using System.Text.RegularExpressions;

namespace IncidentApp
{
    public static class Validators {

        public static bool isValidString(string word)  //Check if user enters a valid string
        {
            var input = new Regex(@"^[a-zA-Z]{3,100}$");
            try{
                 return input.IsMatch(word);
            }catch
            {
                return false;
            }
            
        }

        public static bool isValidInputString(string word)  //Check if user enters a valid string
        {
            var input = new Regex(@"^[a-zA-Z\s]{3,250}$");
            try{
                 return input.IsMatch(word);
            }catch
            {
                return false;
            }
            
        }
        public static bool isValidInputLocString(string word)  //Check if user enters a valid string
        {
            var input = new Regex(@"^[a-zA-Z0-9_\s]{3,255}$");
            try{
                 return input.IsMatch(word);
            }catch
            {
                return false;
            }
            
        }
        public static bool isValidEmail(string email) //Fuction that will check if users enteres a valid email address
        {
            try{
                return new System.Net.Mail.MailAddress(email).Address == email;
            }catch{
                return false;
            }
        }
        public static bool isPhoneNumber(string number)  //Fuction that will check if users enters a valid 10 digits phone number
        {
            try{
                return new System.Text.RegularExpressions.Regex(@"^[0-9]{10}$").IsMatch(number);
            }catch{
                return false;
            }  
        }
        public static bool passwordMeetsCriteria(string password)  //Function that will check if the users enters a valid password that matches all characters required by a password
        {
            try{
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasMinimum8Chars = new Regex(@".{8,}");
                return hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password);
            }catch{
                return false;
            }
        }

    }
}