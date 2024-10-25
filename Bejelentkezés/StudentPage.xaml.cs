using System;
using System.Collections.Generic;
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
using System.Xml.Linq;

namespace Login
{
    public partial class StudentPage : Page
    {
        public StudentPage()
        {
            InitializeComponent();
            Subjects();
        }

        public void Subjects()
        {
            var student = LoginPage.LoggedInStudent;

            if (student != null && student.Subjects.Any())
            {
                TargyPanel.Children.Clear();

                foreach (var subject in student.Subjects)
                {
                    Button subjectButton = new Button
                    {
                        Content = subject.Name,
                        Margin = new Thickness(5),
                        Padding = new Thickness(10),
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };

                    subjectButton.Click += (sender, e) =>
                    { 
                        StudentSubjectPage studentsubjectpage = new StudentSubjectPage();
                        Shared.NavigationService.Navigate(studentsubjectpage);
                    };

                    TargyPanel.Children.Add(subjectButton);
                }

                foreach (var grade in LoginPage.Student.TestGrades)
                {
                    int sum = 0;
                    sum += grade.SubjectGrade;
                    int gradecounter = LoginPage.Student.TestGrades.Where(x => x.SubjectGrade == grade.SubjectGrade).Count();
                    int average = sum / gradecounter;

                    Button averageButton = new Button
                    {
                        Content = average,
                        Margin = new Thickness(5),
                        Padding = new Thickness(10),
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };

                    averageButton.Click += (sender, e) =>
                    {
                        Console.WriteLine("asd");
                    };

                    AtlagPanel.Children.Add(averageButton);
                };
            }
        }

        private void ExitToLoginPageStudent(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            Shared.NavigationService.Navigate(loginPage);
        }
    }
}
