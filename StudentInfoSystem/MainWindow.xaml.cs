using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<String> Degrees { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void OnClick_Clear(object sender, RoutedEventArgs e)
        {
            foreach (var item in studentInfoGrid.Children)
            {
                if (item is TextBox box)
                {
                    box.Text = "";
                }
            }
        }

        private void OnClick_Show(object sender, RoutedEventArgs e)
        {
            try
            {
                string facultyNumber = txtSearchByNumber.Text;
                Student student = StudentData.GetStudentByFaculty(facultyNumber);
                txtName.Text = student.Name;
                txtSurname.Text = student.Surname;
                txtLastName.Text = student.LastName;
                txtFaculty.Text = student.Faculty;
                txtSpecialty.Text = student.Specialty;
                txtDegree.Text = student.Degree;
                txtFacultyNumber.Text = student.FacultyNumber;
                txtCourse.Text = student.Course.ToString();
                txtFlow.Text = student.Flow.ToString();
                txtGroup.Text = student.Group.ToString();
                txtStatus.Text = student.Status;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnClick_Inactivate(object sender, RoutedEventArgs e)
        {
            foreach (var item in studentInfoGrid.Children)
            {
                if (item is TextBox box)
                {
                    box.IsEnabled = false;
                }
            }
        }

        private void OnClick_Active(object sender, RoutedEventArgs e)
        {
            foreach (var item in studentInfoGrid.Children)
            {
                if (item is TextBox box)
                {
                    box.IsEnabled = true;
                }
            }
        }


        /*public void Test_OnClick(object sender, RoutedEventArgs e)
        {
            if (IsUsersTableEmpty() && IsStudentsTableEmpty())
            {
                SaveTestUsers();
                SaveTestStudents();
            }
        } 

        private bool IsStudentsTableEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();

            return countStudents == 0;
        }

        private void SaveTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
                context.Students.Add(new Student("Todor", "Miroslavov", "Mikov", "FKST", "KSI", DegreeType.BACHELOR, StudentStatus.CERTIFIED, "121218000", 5, 10, 37));
            context.SaveChanges();
        }

        private bool IsUsersTableEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<User> queryUsers = context.Users;
            int countUsers = queryUsers.Count();

            return countUsers == 0;
        }
        private void SaveTestUsers()
        {
            StudentInfoContext context = new StudentInfoContext();

            context.Users.Add(new User("user1", "1234", UserRoles.ADMIN, DateTime.Now, DateTime.MaxValue));
            context.SaveChanges();
        }

        private static List<Student> GetRegions()
        {
            StudentInfoContext context = new StudentInfoContext();
            List<Student> students = context.Students.ToList();
            return students;
        }

        private void DeleteEntity(String facNum)
        {
            StudentInfoContext context = new StudentInfoContext();
            Student delObj =
            (from st in context.Students
             where st.FacultyNumber == facNum
             select st).First();
            context.Students.Remove(delObj);
            context.SaveChanges();
        } */
    }
}
