using System.Windows;
using System.Windows.Documents;
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
            Data.AddAnswer(db, new Answer
            {
                HandlingId = handing.HandlingId,
                CText = new TextRange(text.Document.ContentStart, text.Document.ContentEnd).Text,
                ADate = date.SelectedDate.Value.Date
            }); ;
            this.Close();
        }
    }
}
