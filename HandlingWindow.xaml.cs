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
    /// Логика взаимодействия для HandlingWindow.xaml
    /// </summary>
    public partial class HandlingWindow : Window
    {
        public HandlingWindow(Client client,Employee emp)
        {
            InitializeComponent();
            this.client = client;
            this.emp = emp;
            Refresh();
        }

        Client client;
        Employee emp;

        TechnicalSupportDBEntities db = new TechnicalSupportDBEntities();
        private void Refresh()
        {
            HandlingData.Items.Clear();
            foreach(var i in Data.GetAllHandlings(db,client.ClientId,emp.EmployeeId))
                HandlingData.Items.Add(i);
        }
        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (HandlingData.SelectedItem != null)
                Data.DeleteHandling(db, HandlingData.SelectedItem as Handling);
            Refresh();
        }
        private void ChangeClick(object sender, RoutedEventArgs e)
        {
            var w = new ChangeHandlingWindow(HandlingData.SelectedItem as Handling);
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            w.Show();
            w.Closed += Closed;
        }
        private void Closed(object sender, EventArgs e)
        {
            Refresh();
        }
        private void AnswerClick(object sender, RoutedEventArgs e)
        {
            var w = new AnswerWindow(HandlingData.SelectedItem as Handling);
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            w.Show();
            w.Closed += Closed;
        }

        private void AddHandling(object sender, RoutedEventArgs e)
        {
            var w = new AddHandling(client,emp);
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            w.Show();
            w.Closed += Closed;
        }

    }
}
