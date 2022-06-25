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
            if (Client.Role == 3) ListDepartament.ItemsSource = Classes.Model.BD_Connection.bd.Departament.ToList();
            else
            {
                BtnEditContent.Visibility = Visibility.Hidden;
                ListDepartament.ItemsSource = Classes.Model.BD_Connection.bd.Departament.Where(c => c.Name == Client.Departament.Name).ToList();
            }


        }

        private void ListDepartament_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh(); 
            var selectDep = ListDepartament.SelectedItem as Classes.Model.Departament;
            try
            {
                txtDepFullName.Text = selectDep.FullName;
                txtDepName.Text = selectDep.Name;
                txtDepEmployeeCount.Text = Classes.Model.BD_Connection.bd.Client.Where(c => c.IdDepartament == selectDep.IdDepartament).ToList().Count().ToString();
                ListEmployee.ItemsSource = Classes.Model.BD_Connection.bd.Client.Where(d => d.Departament.IdDepartament == selectDep.IdDepartament).ToList();

            }
            catch (Exception)
            {
                return;
            }

        }

        private void BtnEditContent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Classes.Model.Departament departament = Classes.Model.BD_Connection.bd.Departament.FirstOrDefault(d => d.Name != txtDepName.Text || d.FullName != txtDepFullName.Text);
                if (departament != null || string.IsNullOrWhiteSpace(txtDepName.Text) || string.IsNullOrWhiteSpace(txtDepFullName.Text))
                {
                    var selectDep = ListDepartament.SelectedItem as Classes.Model.Departament;
                    var EditDep = Classes.Model.BD_Connection.bd.Departament.Where(d => d.IdDepartament == selectDep.IdDepartament).FirstOrDefault();
                    EditDep.Name = txtDepName.Text;
                    EditDep.FullName = txtDepFullName.Text;
                    Classes.Model.BD_Connection.bd.SaveChanges();
                    MessageBox.Show("departament edit");
                }
                else
                {
                    return;
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                return;
            }
            if (Client.Role == 3)
            {
                ListEmployee.ItemsSource = Classes.Model.BD_Connection.bd.Client.Where(c => c.Name == txtSearch.Text || c.Role.Type == txtSearch.Text ||
                c.Link == txtSearch.Text || c.Login == txtSearch.Text || c.idClient.ToString() == txtSearch.Text).ToList();
                ListDepartament.ItemsSource = Classes.Model.BD_Connection.bd.Departament.Where(d => d.Name == txtSearch.Text || d.FullName == txtSearch.Text || d.IdDepartament.ToString() == txtSearch.Text).ToList();
            }
            else
            {
                ListEmployee.ItemsSource = Classes.Model.BD_Connection.bd.Client.Where(c => c.Name == txtSearch.Text && c.Departament.Name == Client.Departament.Name).ToList();
            }
        }
        public void Refresh()
        {
            txtDepName.Text = null;
            txtDepFullName.Text = null;
            txtDepEmployeeCount.Text = null;
        }
    }
}
