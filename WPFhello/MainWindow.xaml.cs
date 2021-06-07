using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnHello_Click(object sender, RoutedEventArgs e)
        {
            string result = "";
            UIElementCollection elements = MainGrid.Children;
            foreach (var item in elements)
            {
                if (item is TextBox box)
                {
                    string text = box.Text;
                    if (!String.IsNullOrEmpty(text))
                    {
                        result += text;
                        result += '\n';
                    }
                }
            }

            string message = "Здравейте " + result + "!!!\nТова е вашата първа програма на Visual Studio 2019!";
            foreach (var item in elements)
            {
                if (item is TextBox textBox)
                {
                    if (textBox.Text.Length < 2)
                    {
                        message = "Въведете текст с поне 2 символа!";
                        break;
                    }
                }
            }

            MessageBox.Show(message);
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
             MessageBoxResult result = MessageBox.Show("Наистина ли искате да затворите прозореца?", "Внимание!!!", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is Windows Presentation Foundation!");
            textBlock1.Text = DateTime.Now.ToString();
        }
    }
}
