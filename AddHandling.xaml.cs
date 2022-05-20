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
    /// Логика взаимодействия для AddHandling.xaml
    /// </summary>
    public partial class AddHandling : Window
    {
        public AddHandling(Client client,Employee emp)
        {
            InitializeComponent();
            this.client = client;
            this.emp = emp;
        }
        Client client;
        Employee emp;
        TechnicalSupportDBEntities db = new TechnicalSupportDBEntities();
        private void AddClick(object sender, RoutedEventArgs e)
        {
            Data.AddHandling(db, new Handling
            {
                HDate = date.SelectedDate.Value.Date,
                CText = new TextRange(text.Document.ContentStart, text.Document.ContentEnd).Text,
                ClientId= client.ClientId,
                EmployeeId = emp.EmployeeId
            });
            this.Close();
        }
    }
}
