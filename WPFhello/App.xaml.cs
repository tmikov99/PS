using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Calculate_Startup(object sender, StartupEventArgs e)
        {
            CalculateWindow calculateWindow = new CalculateWindow();
            calculateWindow.Top = 100;
            calculateWindow.Left = 400;
            calculateWindow.Show();
        }
    }
}
