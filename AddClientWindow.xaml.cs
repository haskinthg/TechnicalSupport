using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
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
            if (firstname.Text != "" && secondname.Text != "" && lastname.Text != "")
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
            else MessageBox.Show("Введите данные");
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
