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
    /// Логика взаимодействия для ChangeClientWindow.xaml
    /// </summary>
    public partial class ChangeClientWindow : Window
    {
        public ChangeClientWindow(Client c)
        {
            InitializeComponent();
            client = c;
            old = c;
        }
        TechnicalSupportDBEntities db = new TechnicalSupportDBEntities();
        Client client;
        Client old;

        private void ChangeClick(object sender, RoutedEventArgs e)
        {
            if(firstname.Text!="") client.CFirstName = firstname.Text;
            if(lastname.Text!="") client.CLastName = lastname.Text;
            if(secondname.Text!="") client.CSecondName = secondname.Text;
            if(phone.Text!="") client.CPhone = long.Parse(phone.Text);
            Data.ChangeClient(db, old, client);
            this.Close();
        }
    }
}
