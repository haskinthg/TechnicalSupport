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
    /// Логика взаимодействия для ChangeEmployeeWindow.xaml
    /// </summary>
    public partial class ChangeEmployeeWindow : Window
    {
        public ChangeEmployeeWindow(Employee e)
        {
            InitializeComponent();
            emp = e;
            old = e;
        }
        TechnicalSupportDBEntities db = new TechnicalSupportDBEntities();

        Employee emp;
        Employee old;
        private void ChangeClick(object sender, RoutedEventArgs e)
        {
            if (firstname.Text != "") emp.EFirstName = firstname.Text;
            if (lastname.Text != "") emp.ELastName = lastname.Text;
            if (secondname.Text != "") emp.ESecondName = secondname.Text;
            if (phone.Text != "") emp.EPhone = long.Parse(phone.Text);
            if (password.Text != "") emp.EPassword = password.Text;
            Data.ChangeEmployee(db, old, emp);
            this.Close();
        }
    }
}
