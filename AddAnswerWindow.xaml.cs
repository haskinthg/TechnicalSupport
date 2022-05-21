using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using TechnicalSupport.Model;

namespace TechnicalSupport
{
    /// <summary>
    /// Логика взаимодействия для AddAnswerWindow.xaml
    /// </summary>
    public partial class AddAnswerWindow : Window
    {
        public AddAnswerWindow(Handling handing)
        {
            InitializeComponent();
            this.handing = handing;
        }
        TechnicalSupportDBEntities db = new TechnicalSupportDBEntities();
        Handling handing;
        private void AddClick(object sender, RoutedEventArgs e)
        {
            if (new TextRange(text.Document.ContentStart, text.Document.ContentEnd).Text != "\r\n" && date.SelectedDate != null)
            {
                Data.AddAnswer(db, new Answer
                {
                    HandlingId = handing.HandlingId,
                    CText = new TextRange(text.Document.ContentStart, text.Document.ContentEnd).Text,
                    ADate = date.SelectedDate.Value.Date
                }); ;
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
