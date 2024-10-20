using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace Login
{
    public partial class LoginPage : UserControl
    {
        public List<Student> students = new List<Student>();
        public LoginPage()
        {
            InitializeComponent();
            LoadStudents();
        }

        public class Student
        {
            public string Name { get; set; }
            public string BirthPlace { get; set; }
            public DateTime BirthDate { get; set; }
            public string MotherName { get; set; }
            public string Address { get; set; }
            public DateTime EnrollmentDate { get; set; }
            public string Major { get; set; }
            public string Class { get; set; }
            public bool IsBoarder { get; set; }
            public string Dormitory { get; set; }
            public string LogNumber { get; set; }
            public string RegistrationNumber { get; set; }
            public List<Subject> Subjects { get; set; } = new List<Subject>();
        }

        public class Subject
        {
            public string Name { get; set; }
            public int Grade { get; set; }
            public string Type { get; set; }
            public int HourPerWeek { get; set; }
            public int HourPerYear { get; set; }
        }

        public void LoadStudents()
        {
            if (File.Exists("students.json"))
            {
                string json = File.ReadAllText("students.json");
                students = JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var student in students)
            {
                var StudentList = students.Where(x => x.Name == Name.Text);
                foreach (var Student in StudentList)
                {
                    if (Student.Name == Name.Text && Student.Address == Password.Password)
                    {
                        StudentPage studentPage = new StudentPage();
                        Shared.NavigationService.Navigate(studentPage);
                    }
                }

                if (Name.Text == "admin" && Password.Password == "admin")
                {
                    AdminPage adminPage = new AdminPage();
                    Shared.NavigationService.Navigate(adminPage);
                }
            }
        }
    }
}
