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
    /// Логика взаимодействия для AnswerWindow.xaml
    /// </summary>
    public partial class AnswerWindow : Window
    {
        public AnswerWindow(Handling handling)
        {
            InitializeComponent();
            this.handling = handling;
            Refresh();
        }
        TechnicalSupportDBEntities db = new TechnicalSupportDBEntities();
        Handling handling;
        private void Refresh()
        {
            AnswerData.Items.Clear();
            foreach (var i in Data.GetAllAnswers(db, handling.ClientId))
                AnswerData.Items.Add(i);
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (AnswerData.SelectedItem != null)
                Data.DeleteAnswer(db, AnswerData.SelectedItem as Answer);
            Refresh();
        }
        private void ChangeClick(object sender, RoutedEventArgs e)
        {
            //var w = new ChangeAnswerWindow(AnswerData.SelectedItem as Answer);
            //w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //w.Show();
            //w.Closed += Closed;
        }
        private void Closed(object sender, EventArgs e)
        {
            Refresh();
        }

        private void AddAnswer(object sender, RoutedEventArgs e)
        {
            //var w = new AddAnswer(handling);
            //w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //w.Show();
            //w.Closed += Closed;
        }
    }
}
