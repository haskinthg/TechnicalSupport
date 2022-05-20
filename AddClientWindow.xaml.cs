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
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public AddClientWindow()
        {
            InitializeComponent();
        }
        TechnicalSupportDBEntities db = new TechnicalSupportDBEntities();

        private void AddClick(object sender, RoutedEventArgs e)
        {
            if (phone.Text != "")
            {
                Data.AddClient(db, new Client
                {
                    CFirstName = firstname.Text,
                    CLastName = lastname.Text,
                    CPhone = long.Parse(phone.Text),
                    CSecondName = secondname.Text
                });
            }
            else
            {
                Data.AddClient(db, new Client
                {
                    CFirstName = firstname.Text,
                    CLastName = lastname.Text,
                    CSecondName = secondname.Text
                });
            }
            this.Close();
        }
    }
}
