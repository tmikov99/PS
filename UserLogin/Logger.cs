using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UserLogin
{
    public static class Logger
    {
        private static readonly List<string> currentSessionActivities = new List<string>();

        public static void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";" +
                LoginValidation.CurrentUserUsername + ";" +
                LoginValidation.CurrentUserRole + ";" +
                activity + "\n";

            currentSessionActivities.Add(activityLine);
            
            File.AppendAllText("logs.txt", activityLine);
        }

        public static IEnumerable<string> GetLog()
        {
            StreamReader reader = new StreamReader("logs.txt");
            List<string> list = new List<string>();

            string line = reader.ReadLine();
            while (line != null)
            {
                list.Add(line);
                line = reader.ReadLine();
            }

            reader.Close();
            return list;
        }

        public static IEnumerable<string> GetCurrentSessionActivities(string filter)
        {
            return currentSessionActivities.Where(activity => activity.Contains(filter)).ToList();
        }
    }
}
