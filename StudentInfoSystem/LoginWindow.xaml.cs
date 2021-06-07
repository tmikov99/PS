using System;
using System.Windows;
using UserLogin;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void OnClick_Login(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string password = boxPassword.Password;

                AssertValidUserCredentials(username, password);

                StudentInfoContext context = new StudentInfoContext();

                User user = DatabaseUtils.GetUserByUsername(username);
                
                if (UserRoles.ADMIN.Equals(user.Role))
                {
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                } 
                else
                {
                    LoginUser();
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(String.Format("Потребител с име: {0} не беше намерен.", txtUsername.Text));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void AssertValidUserCredentials(string username, string password)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Не са въведени потребителско име или парола!");
            }
        }

        private void LoginUser()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
