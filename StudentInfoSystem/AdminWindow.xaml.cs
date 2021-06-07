using System.Windows;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void OnClick_ShowStudentInfo(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
        }

        private void OnClick_ShowAll(object sender, RoutedEventArgs e)
        {
            AllStudentsWIndow window = new AllStudentsWIndow();
            window.Show();
        }
    }
}
