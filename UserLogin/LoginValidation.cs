using System;
using System.Collections.Generic;
using System.Text;

namespace UserLogin
{
    public class LoginValidation
    {
        private readonly string username;
        private readonly string password;
        private string errorMessage;
        static public string CurrentUserUsername { get; private set; }
        static public string CurrentUserRole { get; private set; }
        public delegate void ActionOnError(string errorMsg);
        private ActionOnError actionOnError;

        public LoginValidation(string username, string password, ActionOnError actionOnError)
        {
            this.username = username;
            this.password = password;
            this.actionOnError = actionOnError;
        }

        public bool ValidateUserInput(ref User user)
        {
            Boolean emptyUsername = username.Equals(String.Empty);
            Boolean emptyPassword = password.Equals(String.Empty);
            Boolean tooShortUsername = username.Length < 5;
            Boolean tooShortPassword = password.Length < 5;
            Boolean result = false;

            if (emptyUsername)
            {
                errorMessage = "Не е посочено потребителско име";
            }
            else if (emptyPassword)
            {
                errorMessage = "Не е посочена парола";
            }
            else if (tooShortUsername)
            {
                errorMessage = "Потребителското име е по-малко от 5 символа.";
            }
            else if (tooShortPassword)
            {
                errorMessage = "Паролата е по-малка от 5 символа.";
            }
            else
            {
                result = true;
            }

            User newUser = null;
            if (result)
            {
                newUser = UserData.IsUserPassCorrect(password);
                if (newUser == null)
                {
                    errorMessage = String.Format("Потребител с парола: {1} не беше намерен.", password);
                    result = false;
                }
            }

            if (!result)
            {
                CurrentUserRole = UserRoles.ANONYMOUS;
                actionOnError(errorMessage);
            }
            else
            {
                user = newUser;
                CurrentUserRole = user.Role;
            }

            CurrentUserUsername = user.Username;
            CurrentUserRole = user.Role;
            Logger.LogActivity("Успешен Login");
            return result;
        }
    }
}
