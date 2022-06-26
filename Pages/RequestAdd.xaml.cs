using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RequestAdd.xaml
    /// </summary>
    public partial class RequestAdd : Page
    {
        public static Classes.Client Client;
        public RequestAdd(Classes.Client client)
        {
            Client = client;
            InitializeComponent();
            if (Client.Role == 3)
            {
                CBProduct.ItemsSource = Classes.Model.BD_Connection.bd.Product.ToList();
            } 
            else
            {   
                Classes.Model.Room room = Classes.Model.BD_Connection.bd.Room.FirstOrDefault(r=>r.Departament.Name == Client.Departament.Name && r.Departament.FullName == Client.Departament.FullName);
                CBProduct.ItemsSource = Classes.Model.BD_Connection.bd.Product.Where(p => p.idRoom != room.idRoom).ToList();
            }
            
        }

        private void count(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnSendRequest_Click(object sender, RoutedEventArgs e)
        {
            var selectProd = CBProduct.SelectedItem as Classes.Model.Product;
            Classes.Model.Client client = Classes.Model.BD_Connection.bd.Client.FirstOrDefault(c=>c.Login == Client.Login && c.Departament.Name == Client.Departament.Name);
            if (countProd < Convert.ToInt32(txtCount.Text))
            {
                MessageBox.Show("big");
            }
            else if (client != null)
            {
                Classes.Model.Request request = new Classes.Model.Request
                {
                    Date = DateTime.Now.ToString(),
                    idClient = client.idClient,
                    Status = false,
                    Count = Convert.ToInt32(txtCount.Text),
                    idProduct = selectProd.idProduct
                };
                Classes.Model.History history = new Classes.Model.History
                {
                    idClient = client.idClient,
                    idProduct = selectProd.idProduct,
                    Date = DateTime.Now.ToString(),
                    Type = "request send"
                };
                Classes.Model.BD_Connection.bd.Request.Add(request);
                Classes.Model.BD_Connection.bd.History.Add(history);
                Classes.Model.BD_Connection.bd.SaveChanges();
                MessageBox.Show("request add");
            }
            else return;
            
        }
        int countProd;
        private void CBProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectProd = CBProduct.SelectedItem as Classes.Model.Product;
            txtCount.Text = selectProd.Count.ToString();
            countProd = Convert.ToInt32(selectProd.Count);

        }
    }
}
