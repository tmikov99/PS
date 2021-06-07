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
using System.Linq;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for AllStudentsWIndow.xaml
    /// </summary>
    public partial class AllStudentsWIndow : Window
    {
        private List<string> filterDegree = new List<string>();
        private List<string> filterStatus = new List<string>();
        private List<int> filterCourse = new List<int>();

        public AllStudentsWIndow()
        {
            using StudentInfoContext context = new StudentInfoContext();
            List<Student> StudentsList = context.Students.ToList();
            InitializeComponent();
            StudentsList.ForEach(s => itemGrid.Items.Add(s));
        }

        private void FilterByDegree(string degree, bool flag)
        {
            if (flag)
            {
                if(!filterDegree.Contains(degree))
                {
                    filterDegree.Add(degree);
                }
            } else
            {
                filterDegree.Remove(degree);
            }
        }
        private void FilterByStatus(string status, bool flag)
        {
            if (flag)
            {
                if(!filterStatus.Contains(status))
                {
                    filterStatus.Add(status);
                }
            } else
            {
                filterStatus.Remove(status);
            }
        }
        private void FilterByCourse(int course, bool flag)
        {
            if (flag)
            {
                if(!filterCourse.Contains(course))
                {
                    filterCourse.Add(course);
                }
            } else
            {
                filterCourse.Remove(course);
            }
        }

        private void FilterAll()
        {
            FilterByDegree(DegreeType.BACHELOR, DegreeButton1.IsChecked == true);
            FilterByDegree(DegreeType.PROFFESIONAL_BACHELOR, DegreeButton2.IsChecked == true);
            FilterByDegree(DegreeType.MASTER, DegreeButton3.IsChecked == true);
            FilterByDegree(DegreeType.DOCTOR, DegreeButton4.IsChecked == true);

            FilterByStatus(StudentStatus.CERTIFIED, StatusButton1.IsChecked == true);
            FilterByStatus(StudentStatus.GRADUATED, StatusButton2.IsChecked == true);
            FilterByStatus(StudentStatus.INTERUPTED, StatusButton3.IsChecked == true);

            FilterByCourse(1, CourseButton1.IsChecked == true);
            FilterByCourse(2, CourseButton2.IsChecked == true);
            FilterByCourse(3, CourseButton3.IsChecked == true);
            FilterByCourse(4, CourseButton4.IsChecked == true);
            FilterByCourse(5, CourseButton5.IsChecked == true);
        }

        private void refreshAll_Click(object sender, RoutedEventArgs e)
        {
            itemGrid.Items.Clear();

            FilterAll();

            using StudentInfoContext context = new StudentInfoContext();
            List<Student> StudentsList = context.Students.ToList();
            StudentsList.ForEach(s => {
                if(filterDegree.Contains(s.Degree) && filterStatus.Contains(s.Status) && filterCourse.Contains(s.Course))
                {
                    itemGrid.Items.Add(s);
                }
            });

        }
    }
}
