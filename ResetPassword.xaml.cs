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
using System.Windows.Shapes;
using WPFModernVerticalMenu.Classes.Model;
using WPFModernVerticalMenu.Classes;

namespace WPFModernVerticalMenu
{
    /// <summary>
    /// Логика взаимодействия для ResetPassword.xaml
    /// </summary>
    public partial class ResetPassword : Window
    {
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void BtnResetPass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TxtClienLink.Text) && string.IsNullOrWhiteSpace(TxtClientPassword.Password))
                {
                    MessageBox.Show("incorrect");
                    Refresh();
                }
                else
                {
                   Classes.Model.Client client = Classes.Model.BD_Connection.bd.Client.FirstOrDefault(c => c.Link == TxtClienLink.Text && c.Login == txtClientLogin.Text);
                    if (client != null)
                    {
                        client.Password = TxtClientPassword.Password;
                        BD_Connection.bd.SaveChanges();
                        MessageBox.Show("edit password");
                        Refresh();
                        Auth auth = new Auth();
                    }
                }
            }
            catch(Exception)
            {
                Refresh();
            }
        }
        public void Refresh()
        {
            txtClientLogin.Text = null;
            TxtClienLink.Text = null;
            TxtClientPassword.Password = null;
        }
    }
}
