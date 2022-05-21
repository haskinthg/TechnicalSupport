using System.Windows;
using System.Windows.Documents;
using TechnicalSupport.Model;

namespace TechnicalSupport
{
    /// <summary>
    /// Логика взаимодействия для AddHandling.xaml
    /// </summary>
    public partial class AddHandling : Window
    {
        public AddHandling(Client client, Employee emp)
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
            if (new TextRange(text.Document.ContentStart, text.Document.ContentEnd).Text != "\r\n" && date.SelectedDate != null)
            {
                Data.AddHandling(db, new Handling
                {
                    HDate = date.SelectedDate.Value.Date,
                    CText = new TextRange(text.Document.ContentStart, text.Document.ContentEnd).Text,
                    ClientId = client.ClientId,
                    EmployeeId = emp.EmployeeId
                });
                this.Close();
            }
            else MessageBox.Show("Введите данные");
        }
    }
}
