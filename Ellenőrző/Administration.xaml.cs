using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using static ellenorzo.MainWindow;

namespace ellenorzo
{
    public partial class Administration : Window
    {
        public Administration()
        {
            InitializeComponent();
            AdminPanel();
        }

        private void AdminPanel()
        {
            if (File.Exists("students.json"))
            {
                string json = File.ReadAllText("students.json");
                students = JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
            }

            dgStudents.ItemsSource = null;
            dgStudents.ItemsSource = students;

            var boarderCount = students.Count(x => x.IsBoarder);
            var debrecenCount = students.Count(x => x.Address.Contains("Debrecen"));
            var commuterCount = students.Count(x => !x.IsBoarder);
            var majorStat = students.GroupBy(x => x.Major)
                                           .Select(x => new { Major = x.Key, StudentCount = x.Count() })
                                           .ToList();

            string stats = $"Kollégisták száma: {boarderCount}\nBejárósok száma: {commuterCount}\nDebreceni tanulók száma: {debrecenCount}\n\nSzakok szerinti statisztika:\n";

            foreach (var stat in majorStat)
            {
                stats += $"{stat.Major}: {stat.StudentCount} tanuló\n";
            }

            MessageBox.Show(stats, "Statisztika", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var student = button?.Tag as Student;

            if (student != null)
            {
                var result = MessageBox.Show($"Biztosan törölni szeretnéd {student.Name} adatait?", "Megerősítés", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    students.Remove(student);
                    SaveStudents();

                    dgStudents.ItemsSource = null;
                    dgStudents.ItemsSource = students;

                    MessageBox.Show($"{student.Name} sikeresen törölve lett!", "Törlés", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
