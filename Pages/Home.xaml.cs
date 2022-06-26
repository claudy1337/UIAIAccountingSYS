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
using WPFModernVerticalMenu.Classes;
using WPFModernVerticalMenu.Classes.Model;

namespace WPFModernVerticalMenu.Pages
{
    /// <summary>
    /// Lógica de interacción para Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public static Classes.Client Client;
        public Home(Classes.Client client)
        {
            Client = client;
            InitializeComponent();
            txtClientLink.Text = Client.Link;
            txtClientLogin.Text = Client.Login;
            txtClientName.Text = Client.Name;
            txtDepName.Text = Client.Departament.Name;
            imgClient.Source = new BitmapImage(new Uri(Client.Image, UriKind.RelativeOrAbsolute));
        }

        private void txtDepName_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Pages.DivisionInformation(Client,Client.Departament));
        }

        private void BtnEditContents_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectClient = Classes.Model.BD_Connection.bd.Client.Where(c => c.Login == Client.Login).FirstOrDefault();
                if (selectClient != null)
                {
                   
                    Classes.Model.Client searchClient = Classes.Model.BD_Connection.bd.Client.FirstOrDefault(c => c.Link == txtClientLink.Text && c.Login != Client.Login);
                    if (searchClient == null)
                    {
                        selectClient.Link = txtClientLink.Text;
                        selectClient.Name = txtClientName.Text;

                        BD_Connection.bd.SaveChanges();
                        Client.Name = txtClientName.Text;
                        Client.Link = txtClientLink.Text;
                        MessageBox.Show("edit");
                    }
                    
                }
                else if (string.IsNullOrWhiteSpace(txtClientLink.Text) || string.IsNullOrWhiteSpace(txtClientName.Text)) return;
                else return;

            }
            catch (Exception)
            {
                MessageBox.Show("{dsd");
            }
        }
    }
}
