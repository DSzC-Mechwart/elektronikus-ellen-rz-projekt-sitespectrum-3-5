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
using static Login.LoginPage;

namespace Login
{
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            Subjects();
        }

        public void Subjects()
        {
            var student = LoginPage.LoggedInStudent;

            NevValaszto.Children.Clear();

            foreach (var student1 in LoginPage.students)
            {
                Button nameButton = new Button
                {
                    Content = student1.Name,
                    Margin = new Thickness(5),
                    Padding = new Thickness(10),
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };

                nameButton.Click += (sender, e) =>
                {
                    Nev.Text = $"Név: {student1.Name}";
                    TargyPanel.Children.Clear();

                    foreach (var subject in student1.Subjects)
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
                            AdminSubjectPage adminsubjectPage = new AdminSubjectPage();
                            Shared.NavigationService.Navigate(adminsubjectPage);
                            Console.WriteLine("asd");
                        };

                        TargyPanel.Children.Add (subjectButton);
                    };

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
                };
                NevValaszto.Children.Add(nameButton);
            }
        }

        private void SearchToName(object sender, RoutedEventArgs e)
        {
            NevValaszto.Children.Clear();

            foreach (var name in students)
            {
                if(Search.Text == name.Name)
                {
                    Button nameButton = new Button
                    {
                        Content = name.Name,
                        Margin = new Thickness(5),
                        Padding = new Thickness(10),
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };

                    nameButton.Click += (sender, e) =>
                    {
                        Nev.Text = $"Név: {name.Name}";
                        TargyPanel.Children.Clear();

                        foreach (var subject in name.Subjects)
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
                                AdminSubjectPage adminsubjectPage = new AdminSubjectPage();
                                Shared.NavigationService.Navigate(adminsubjectPage);
                                Console.WriteLine("asd");
                            };

                            TargyPanel.Children.Add(subjectButton);
                        };

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
                    };
                    NevValaszto.Children.Add(nameButton);
                }
            }
        }
        
        private void AddGrades(object sender, RoutedEventArgs e)
        {
            AddGrade addgrade = new AddGrade();
            Shared.NavigationService.Navigate(addgrade);
        }

        private void ExitToLoginPageAdmin(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            Shared.NavigationService.Navigate(loginPage);
        }
    }
}
