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
    /// Логика взаимодействия для ProductInformation.xaml
    /// </summary>
    public partial class ProductInformation : Page
    {
        public static Classes.Product Product;
        public ProductInformation(Classes.Product product)
        {
            Product = product;
            InitializeComponent();
            txtProductName.Text = Product.Name;
            var searchRoom = Classes.Model.BD_Connection.bd.Room.Where(r=>r.idRoom == Product.IdRoom).FirstOrDefault();
            imgRoom.Source = new BitmapImage(new Uri(searchRoom.Image, UriKind.RelativeOrAbsolute));
            
            txtDepName.Text = searchRoom.Departament.Name;
            txtRoomName.Text = searchRoom.Name;
            txtDateBuy.Text = Product.Date.ToString();
            txtCount.Text = Product.Count.ToString();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
