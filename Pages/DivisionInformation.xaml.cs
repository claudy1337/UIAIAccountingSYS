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

namespace WPFModernVerticalMenu.Pages
{
    /// <summary>
    /// Логика взаимодействия для DivisionInformation.xaml
    /// </summary>
    public partial class DivisionInformation : Page
    {
        public static Classes.Departament Departament;
        public static Classes.Client Client;
        public DivisionInformation(Classes.Client client, Classes.Departament departament)
        {
            Departament = departament;
            Client = client;
            InitializeComponent();
        }
    }
}
