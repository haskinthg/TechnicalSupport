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
    /// Логика взаимодействия для CommonWindow.xaml
    /// </summary>
    public partial class CommonWindow : Window
    {
        public CommonWindow()
        {
            InitializeComponent();
            Refresh();
        }

        TechnicalSupportDBEntities db = new TechnicalSupportDBEntities();
        private void DeleteClientClick(object sender, RoutedEventArgs e)
        {
            if (ClientData.SelectedItem != null)
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

        private void Refresh()
        {
            ClientData.Items.Clear();
            foreach (var i in Data.GetAllClients(db))
                ClientData.Items.Add(i);
        }
    }
}
