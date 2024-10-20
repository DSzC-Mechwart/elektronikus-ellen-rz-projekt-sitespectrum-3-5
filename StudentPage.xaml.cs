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
    public partial class StudentPage : Page
    {
        public StudentPage()
        {
            InitializeComponent();
            //Subjects();
        }

        /*
        public void Subjects()
        {
            LoginPage loginPage = new LoginPage();
            var student = loginPage.students.Where(x => x.Name == loginPage.Name.Text);

            foreach(var subject in student.Subjects)
            {
                Targy.Text += $"{subject.Name}\n";
            }
        }
        */
    }
}
