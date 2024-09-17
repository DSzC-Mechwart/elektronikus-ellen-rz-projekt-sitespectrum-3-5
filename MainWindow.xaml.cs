using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace ellenorzo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
        }

    }
}