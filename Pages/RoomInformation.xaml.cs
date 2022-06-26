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
    /// Логика взаимодействия для RoomInformation.xaml
    /// </summary>
    public partial class RoomInformation : Page
    {
        public static Classes.Client Client;
        public RoomInformation(Classes.Client client)
        {
            Client = client;
            InitializeComponent();
            ListRoom.ItemsSource = Classes.Model.BD_Connection.bd.Room.ToList();
            ListProduct.ItemsSource = Classes.Model.BD_Connection.bd.Product.ToList();
            
            
        }

        private void ListRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectRoom = ListRoom.SelectedItem as Classes.Model.Room;
            txtRoomName.Text = selectRoom.Name;
            txtDepRoom.Text = selectRoom.Departament.Name;
            txtCountProd.Text = Classes.Model.BD_Connection.bd.Product.Where(p=>p.idRoom == selectRoom.idRoom).Count().ToString();
            ListProduct.ItemsSource = Classes.Model.BD_Connection.bd.Product.Where(p => p.idRoom == selectRoom.idRoom).ToList();
        }

        private void ListProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectProd = ListProduct.SelectedItem as Classes.Model.Product;
            Classes.Product product = new Classes.Product(selectProd.Name, Convert.ToInt32(selectProd.Count), selectProd.Image, Convert.ToDateTime(selectProd.Date), Convert.ToInt32(selectProd.idRoom));
            NavigationService.Navigate(new Pages.ProductInformation(product));
        }
    }
}
