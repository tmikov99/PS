using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Въведете потребителско име:");
            string username = Console.ReadLine();
            Console.WriteLine("Въведете парола:");
            string password = Console.ReadLine();

            LoginValidation loginValidation = new LoginValidation(username, password, PrintMessage);
            User user = null;
            if (loginValidation.ValidateUserInput(ref user))
            {
                Console.WriteLine("Потребител с\n Потребителско име: {0}\n Парола: {1}\n Роля: {2}\n", user.Username, user.Password, user.Role);
                Console.WriteLine(LoginValidation.CurrentUserRole);
            }
        }

        static private void PrintAdminMenu()
        {
            Console.WriteLine("Изберете опция:\n" +
                "0: Изход\n" +
                "1: Промяна на роля на потребител\n" +
                "2: Промяна на активност на потребител\n" +
                "3: Списък на потребители\n" +
                "4: Преглед на лог на активност\n" +
                "5: Преглед на текуща активност\n");
        }

        private static void AdminOperations()
        {
            PrintAdminMenu();
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    Console.WriteLine("Въведете id на потребител за смяна на ролята: ");
                    int userId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Моля въведете новата роля на потребителя: ");
                    string role = Console.ReadLine();
                    UserData.AssignUserRole(userId, role);
                    break;
                case 2:
                    Console.WriteLine("Въведете име на потребител за смяна на датата на активност: ");
                    string usernameToChangeActiveDate = Console.ReadLine();
                    Console.WriteLine("Въведете дата на активност във формат \"дд.мм.гггг\": ");
                    string inputedDate = Console.ReadLine();
                    string dateFormat = "dd.MM.yyyy";
                    DateTime аctiveToDate;
                    if (DateTime.TryParseExact(inputedDate, dateFormat, null, DateTimeStyles.None, out аctiveToDate))
                    {
                        UserData.SetUserActiveTo(usernameToChangeActiveDate, аctiveToDate);
                    }
                    else
                    {
                        Console.WriteLine("Неправилен формат!");
                    }
                    break;
                case 3:
                    Console.WriteLine(UserData.GetAllUsersAsText());
                    break;
                case 4:
                    Console.WriteLine(Logger.GetLog());
                    break;
                case 5:
                    Console.WriteLine("Въведете филтър");
                    string filter = Console.ReadLine();
                    Console.WriteLine(
                        GetSessionActivitiesAsString(Logger.GetCurrentSessionActivities(filter))
                        );
                    break;
            }
        }

        static void PrintMessage(string message)
        {
            Console.WriteLine("!!!" + message + "!!!");
        }

        private static string GetSessionActivitiesAsString(IEnumerable<string> activities)
        {
            StringBuilder output = new StringBuilder();

            foreach (string activity in activities)
            {
                output.AppendLine(activity);
            }

            return output.ToString();
        }
    }
}
