using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            department.DisplayMemberPath = "DName";
            foreach (var i in Data.GetAllDepartments(db))
                department.Items.Add(i);
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
            if (department.SelectedIndex!=-1) emp.DepartmentId = (department.SelectedItem as Department).DepartmentId;
            Data.ChangeEmployee(db, old, emp);
            this.Close();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
