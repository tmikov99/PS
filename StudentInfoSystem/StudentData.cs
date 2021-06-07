using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentInfoSystem
{
    static class StudentData
    {
        static private List<Student> _TestStudents;

        static public List<Student> GetTestStudents()
        {
            ResetStudentData();
            return _TestStudents;
        }

        static private void SetTestStudents(List<Student> value)
        {
            _TestStudents = value;
        }

        static private void ResetStudentData()
        {
            _TestStudents = new List<Student>();
            _TestStudents.Add(new Student("Тодор", "Мирославов", "Миков", "ФКСТ", "КСИ", DegreeType.BACHELOR, StudentStatus.CERTIFIED, "121218000", 4, 8, 31));
            _TestStudents.Add(new Student("Димитър", "Димитров", "Димитров", "ФКСТ", "ИТИ", DegreeType.BACHELOR, StudentStatus.CERTIFIED, "121218030", 3, 7, 57));
            _TestStudents.Add(new Student("Петър", "Петров", "Петров", "ФКСТ", "КСИ", DegreeType.PROFFESIONAL_BACHELOR, StudentStatus.CERTIFIED, "121218060", 2, 6, 30));
        }

        public static Student GetStudentByFaculty(string facultyNumber)
        {
            if (String.IsNullOrEmpty(facultyNumber))
            {
                throw new ArgumentException("Не е въведен факултетен номер!");
            }

            StudentInfoContext context = new StudentInfoContext();

            Student result =
                (from st in context.Students
                where st.FacultyNumber == facultyNumber
                select st).First();
                return result;
        }
    }
}
