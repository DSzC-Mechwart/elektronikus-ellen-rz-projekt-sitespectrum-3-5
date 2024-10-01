using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using static ellenorzo.MainWindow;

namespace ellenorzo
{
    public partial class MainWindow : Window
    {
        public static List<Student> students = new List<Student>();

        public MainWindow()
        {
            InitializeComponent();
            LoadStudents();
        }

        //Student class
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
            public List<Subjects.Subject> Subjects { get; set; } = new List<Subjects.Subject>();
        }

        //Save student's data
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                var student = new Student
                {
                    Name = txtName.Text,
                    BirthPlace = txtBirthPlace.Text,
                    BirthDate = dpBirthDate.SelectedDate.Value,
                    MotherName = txtMotherName.Text,
                    Address = txtAddress.Text,
                    EnrollmentDate = dpEnrollmentDate.SelectedDate.Value,
                    Major = txtMajor.Text,
                    Class = txtClass.Text,
                    IsBoarder = chkIsBoarder.IsChecked ?? false,
                    Dormitory = chkIsBoarder.IsChecked == true ? txtDormitory.Text : "Nem kolis",
                };

                GenerateLogAndRegistrationNumber(student);

                students.Add(student);
                SaveStudents();

                ClearInputFields();
                MessageBox.Show("Tanuló adatai sikeresen mentve!", "Mentés", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        //Save to JSON
        public static void SaveStudents()
        {
            string json = JsonSerializer.Serialize(students);
            File.WriteAllText("students.json", json);
        }

        public static void LoadStudents()
        {
            if (File.Exists("students.json"))
            {
                string json = File.ReadAllText("students.json");
                students = JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
            }
        }

        private void GenerateLogAndRegistrationNumber(Student student)
        {
            var sameClassStudents = students.Where(x => x.Class == student.Class).OrderBy(x => x.Name).ToList();
            int logNumber = sameClassStudents.Count(x => x.EnrollmentDate.Year == student.EnrollmentDate.Year) + 1;
            student.LogNumber = $"{logNumber}";

            student.RegistrationNumber = $"{logNumber}/{student.EnrollmentDate.Year}";
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtBirthPlace.Text) ||
                dpBirthDate.SelectedDate == null ||
                string.IsNullOrWhiteSpace(txtMotherName.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                dpEnrollmentDate.SelectedDate == null ||
                string.IsNullOrWhiteSpace(txtMajor.Text) ||
                string.IsNullOrWhiteSpace(txtClass.Text))
            {
                MessageBox.Show("Minden mezőt ki kell tölteni!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void ClearInputFields()
        {
            txtName.Clear();
            txtBirthPlace.Clear();
            dpBirthDate.SelectedDate = null;
            txtMotherName.Clear();
            txtAddress.Clear();
            dpEnrollmentDate.SelectedDate = null;
            txtMajor.Clear();
            txtClass.Clear();
            chkIsBoarder.IsChecked = false;
            txtDormitory.Clear();
        }

        //Administration
        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            var admin = new Administration();
            admin.Show();
        }

        private void btnSubjects_Click(object sender, RoutedEventArgs e)
        {
            var subjects = new Subjects();
            subjects.Show();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}