using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for CalculateWindow.xaml
    /// </summary>
    public partial class CalculateWindow : Window
    {
        public CalculateWindow()
        {
            InitializeComponent();
        }

        private void RadBtnPower_Checked(object sender, RoutedEventArgs e)
        {
            radBtnPower.Foreground = Brushes.Black;
            radBtnPower.Background = Brushes.White;
        }

        private void RadBtnFactorial_Checked(object sender, RoutedEventArgs e)
        {
            radBtnFactorial.Foreground = Brushes.Black;
            radBtnFactorial.Background = Brushes.White;
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string nAsText = txtN.Text;
            if (nAsText.Equals(""))
            {
                MessageBox.Show("Въведете число за N!");
                return;
            }

            int nValue = int.Parse(nAsText);
            double result = 1;
            if (radBtnPower.IsChecked == true)
            {
                string yAsText = txtY.Text;

                if (yAsText.Equals(""))
                {
                    MessageBox.Show("Въведете число за Y!");
                    return;
                }

                int yValue = int.Parse(yAsText);
                result = Math.Pow(nValue, yValue);
            }
            else if (radBtnFactorial.IsChecked == true)
            {
                for (int currentNumber = nValue; currentNumber > 1; currentNumber--)
                {
                    result *= currentNumber;
                }
            }
            else
            {
                MessageBox.Show("Изберете изчисляване на степен или факториел!");
                return;
            }

            MessageBox.Show("Резултатът е: " + result);
        }
    }
}
