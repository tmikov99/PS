using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Expenselt
{
    /// <summary>
    /// Interaction logic for ExpenseltHome.xaml
    /// </summary>
    public partial class ExpenseltHome : Window, INotifyPropertyChanged
    {
        public string MainCaptionText { get; set; }
        public List<Person> ExpenseDataSource { get; set; }
        private DateTime lastChecked;
        public DateTime LastChecked 
        {
            get { return lastChecked; }
            set {
                lastChecked = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("LastChecked"));
                }
            } 
        }
        public ObservableCollection<string> PersonChecked { get; set; }

        public ExpenseltHome()
        {
            InitializeComponent();
            this.DataContext = this;
            MainCaptionText = "View Expense Report :";
            LastChecked = DateTime.Now;
            PersonChecked = new ObservableCollection<string>();
            ExpenseDataSource = new List<Person>()
            {
                new Person()
                {
                    Name="Mike",
                    Department ="Legal",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Lunch", ExpenseAmount =50 },
                        new Expense() { ExpenseType="Transportation", ExpenseAmount=50 }
                    }
                },
                new Person()
                {
                    Name ="Lisa",
                    Department ="Marketing",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Document printing", ExpenseAmount=50 },
                        new Expense() { ExpenseType="Gift", ExpenseAmount=125 }
                    }
                },
                new Person()
                {
                    Name="John",
                    Department ="Engineering",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Magazine subscription", ExpenseAmount=50 },
                        new Expense() { ExpenseType="New machine", ExpenseAmount=600 },
                        new Expense() { ExpenseType="Software", ExpenseAmount=500 }
                    }
                },
                new Person()
                {
                    Name="Mary",
                    Department ="Finance",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Dinner", ExpenseAmount=100 }
                    }
                },
                new Person()
                {
                    Name="Theo",
                    Department ="Marketing",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Dinner", ExpenseAmount=100 }
                    }
                },
                new Person()
                {
                    Name = "James",
                    Department = "Finance",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Dinner", ExpenseAmount=100 },
                        new Expense() { ExpenseType="Calculator", ExpenseAmount=10 }
                    }
                },
                new Person()
                {
                    Name = "David",
                    Department = "Engineering",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="New machine", ExpenseAmount=600 },
                        new Expense() { ExpenseType="Software", ExpenseAmount=500 },
                        new Expense() { ExpenseType="Peripherals", ExpenseAmount=200 }
                    }
                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void View_OnClick(object sender, RoutedEventArgs e)
        {
            var myValue = ((Button)sender).Tag;
            Person selected = (Person)myValue;
            ExpenseReport expenseReportWindow = new ExpenseReport(selected);
            expenseReportWindow.Width = this.Width;
            expenseReportWindow.Height = this.Height;
            expenseReportWindow.ShowDialog();
        }

        private void PeopleListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            LastChecked = DateTime.Now;
            PersonChecked.Add((peopleListBox.SelectedItem as Expenselt.Person).Name);
        }
    }
}
