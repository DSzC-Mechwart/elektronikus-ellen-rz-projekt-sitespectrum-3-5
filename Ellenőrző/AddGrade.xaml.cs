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

namespace Login
{
    public partial class AddGrade : Page
    {
        public AddGrade()
        {
            InitializeComponent();
        }
        
        private void AddGradeBtn(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("asd");
        }

        private void ExitToAdminPageGrade(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            Shared.NavigationService.Navigate(adminPage);
        }
    }
}
