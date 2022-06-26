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
    /// Логика взаимодействия для RequestTransfer.xaml
    /// </summary>
    public partial class RequestTransfer : Page
    {
        public static Classes.Client Client;
        public RequestTransfer(Classes.Client client)
        {
            Client = client;
            InitializeComponent();
            ListReqest.ItemsSource = Classes.Model.BD_Connection.bd.Request.ToList();
        }

        private void ListReqest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectReqest = ListReqest.SelectedItem as Classes.Model.Request;
            
        }
    }
}
