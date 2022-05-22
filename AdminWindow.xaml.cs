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
using TechnicalSupport.Model;

namespace TechnicalSupport
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow(Employee emp)
        {
            InitializeComponent();
            Refresh();
            this.emp = emp;
        }
        Employee emp;
        TechnicalSupportDBEntities db = new TechnicalSupportDBEntities();

        private void Refresh()
        {
            ClientData.Items.Clear();
            EmpData.Items.Clear();
            foreach (var i in Data.GetAllEmployees(db))
                EmpData.Items.Add(i);
            foreach (var i in Data.GetAllClients(db))
                ClientData.Items.Add(i);
        }

        private void DeleteEmpClick(object sender, RoutedEventArgs e)
        {
            if (EmpData.SelectedItem != null)
                Data.DeleteEmployee(db, EmpData.SelectedItem as Employee);
            Refresh();
        }
        private void ChangeEmpClick(object sender, RoutedEventArgs e)
        {
            var w = new ChangeEmployeeWindow(EmpData.SelectedItem as Employee);
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            w.Show();
            w.Closed += Closed;
        }
        private void OpenEmpClick(object sender, RoutedEventArgs e)
        {
            var w = new CommonWindow(EmpData.SelectedItem as Employee);
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            w.Show();
        }
        private void DeleteClientClick(object sender, RoutedEventArgs e)
        {
            if(ClientData.SelectedItem != null)
                Data.DeleteClient(db, ClientData.SelectedItem as Client);
            Refresh();
        }
        private void ChangeClientClick(object sender, RoutedEventArgs e)
        {
            var w = new ChangeClientWindow(ClientData.SelectedItem as Client);
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            w.Show();
            w.Closed += Closed;
        }

        private void ClientClick(object sender, RoutedEventArgs e)
        {
            var w = new HandlingWindow(ClientData.SelectedItem as Client, emp);
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            w.Show();
        }

        private void AddClient(object sender, RoutedEventArgs e)
        {
            var w = new AddClientWindow();
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            w.Show();
            w.Closed += Closed;
        }
        private void Closed(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
