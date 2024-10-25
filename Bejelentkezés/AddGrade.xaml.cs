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
using System.IO;
using System.Text.Json;

namespace Login
{
    public partial class AddGrade : Page
    {
        public AddGrade()
        {
            InitializeComponent();
        }
        
        public static void SaveStudents()
        {
            string json = JsonSerializer.Serialize(LoginPage.students);
            File.WriteAllText("students.json", json);
        }
        
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(subject.Text) ||
                string.IsNullOrWhiteSpace(topic.Text) ||
                string.IsNullOrWhiteSpace(type.Text) ||
                string.IsNullOrWhiteSpace(grade.Text))
            {
                MessageBox.Show("Minden mezőt ki kell tölteni!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
        
        private void ClearInputFields()
        {
            subject.Clear();
            topic.Clear();
            type.SelectedIndex = -1;
            grade.SelectedIndex = -1;
            date.Clear();
        }
        
        private void AddGradeBtn(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                var testgrade = new LoginPage.Grades
                {
                    Subject = subject.Text,
                    TestDate = DateTime.Parse(date.Text),
                    Testtopic = topic.Text,
                    Testtype = ((ComboBoxItem)type.SelectedItem).Content.ToString(),
                    SubjectGrade = int.Parse(((ComboBoxItem)grade.SelectedItem).Content.ToString()),
                };
                
                LoginPage.Student.TestGrades.Add(testgrade);
                SaveStudents();

                ClearInputFields();
                MessageBox.Show("Tanuló adatai sikeresen mentve!", "Mentés", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ExitToAdminPageGrade(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            Shared.NavigationService.Navigate(adminPage);
        }
    }
}
