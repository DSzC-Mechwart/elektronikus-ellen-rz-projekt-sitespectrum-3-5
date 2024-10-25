using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Login.MainWindow;
using System.IO;

namespace Login
{
    public partial class MainWindow : NavigationWindow
    {
        public MainWindow()
        {
            Shared.NavigationService = NavigationService;
            InitializeComponent();
        }

    }
}