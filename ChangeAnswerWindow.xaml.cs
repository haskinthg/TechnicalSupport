using System.Windows;
using System.Windows.Documents;
using TechnicalSupport.Model;

namespace TechnicalSupport
{
    /// <summary>
    /// Логика взаимодействия для ChangeAnswerWindow.xaml
    /// </summary>
    public partial class ChangeAnswerWindow : Window
    {
        public ChangeAnswerWindow(Answer answer)
        {
            InitializeComponent();
            this.answer = answer;
            this.old = answer;
        }
        TechnicalSupportDBEntities db = new TechnicalSupportDBEntities();
        Answer answer;
        Answer old;
        private void ChangeClick(object sender, RoutedEventArgs e)
        {
            if (new TextRange(text.Document.ContentStart, text.Document.ContentEnd).Text != "") answer.CText = new TextRange(text.Document.ContentStart, text.Document.ContentEnd).Text;
            if (date.SelectedDate != null) answer.ADate = date.SelectedDate.Value.Date;
            Data.ChangeAnswer(db, old, answer);
            this.Close();
        }
    }
}
