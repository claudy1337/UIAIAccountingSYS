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
using WPFModernVerticalMenu.Classes;

namespace WPFModernVerticalMenu
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void BtnAuthAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TxtClienLogin.Text) && string.IsNullOrWhiteSpace(TxtClientPassword.Password))
                {
                    MessageBox.Show("incorrect");
                }
                Classes.Model.Client client = Classes.Model.BD_Connection.bd.Client.FirstOrDefault(c => c.Login == TxtClienLogin.Text && c.Password == TxtClientPassword.Password);
                if (client != null)
                {
                    Classes.Model.Departament departament = Classes.Model.BD_Connection.bd.Departament.FirstOrDefault(d => d.IdDepartament == client.IdDepartament);
                    Classes.Departament departaments = new Departament(departament.Name, departament.FullName, departament.Image);
                    Classes.Client clients = new Classes.Client(client.Name, client.Login, client.Link, client.Role.idRole, client.Image, departaments);
                    MessageBox.Show("welcome: " + client.Name);
                    MainWindow main = new MainWindow(clients, departaments);
                    main.Show();
                    this.Close();
                }
                else MessageBox.Show("incorrect");
            }
            catch(Exception)
            {
                return;
            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ResetPassword reset = new ResetPassword();
            reset.Show();
            this.Close();
        }
    }
}
