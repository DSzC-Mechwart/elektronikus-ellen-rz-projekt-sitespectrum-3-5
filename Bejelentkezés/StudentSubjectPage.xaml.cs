using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using static Login.LoginPage;

namespace Login
{
    public partial class StudentSubjectPage : Page
    {
        public StudentSubjectPage()
        {
            SubjectPage();
        }

        public void SubjectPage()
        {
        }

        private void ExitToStudentPage(object sender, RoutedEventArgs e)
        {
            StudentPage studentPage = new StudentPage();
            Shared.NavigationService.Navigate(studentPage);
        }

    }
}
