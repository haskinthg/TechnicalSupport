using System.Windows;
using System.Windows.Documents;
using TechnicalSupport.Model;

namespace TechnicalSupport
{
    /// <summary>
    /// Логика взаимодействия для ChangeHandlingWindow.xaml
    /// </summary>
    public partial class ChangeHandlingWindow : Window
    {
        public ChangeHandlingWindow(Handling handling)
        {
            InitializeComponent();
            this.handling = handling;
            this.old = handling;
        }
        TechnicalSupportDBEntities db = new TechnicalSupportDBEntities();
        Handling old;
        Handling handling;
        private void ChangeClick(object sender, RoutedEventArgs e)
        {
            if (new TextRange(text.Document.ContentStart, text.Document.ContentEnd).Text != "") handling.CText = new TextRange(text.Document.ContentStart, text.Document.ContentEnd).Text;
            if(date.SelectedDate!=null) handling.HDate = date.SelectedDate.Value.Date;
            Data.ChangeHandling(db,old,handling);
            this.Close();
        }
    }
}
