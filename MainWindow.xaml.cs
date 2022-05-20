﻿using System;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using TechnicalSupport.Model;

namespace TechnicalSupport
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            db.Departments.Load();
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            foreach (ComboBoxItem item in combobox.Items)
                Data.AddDepartment(db, new Department { DLevel = item.Tag.ToString(), DName = item.Content.ToString() });
        }

        TechnicalSupportDBEntities db = new TechnicalSupportDBEntities();

        private void AddEmployeeClick(object sender, RoutedEventArgs e)
        {
            var emp = new Employee
            {
                EFirstName = firstname.Text,
                ESecondName = secondname.Text,
                ELastName = lastname.Text,
                EPassword = password.Text,
                DepartmentId = Data.FindDepartment(db, ((ComboBoxItem)combobox.SelectedItem).Content.ToString(),
                    ((ComboBoxItem)combobox.SelectedItem).Tag.ToString()).DepartmentId
            };
            if (phone.Text != "")
            {
                emp.EPhone = long.Parse(phone.Text);
                Data.AddEmployee(db, emp);
            }
            else
            {
                Data.AddEmployee(db, emp);
            }
            MessageBox.Show($" Логин(ID) сотрудника: {emp.EmployeeId} \n" +
                $" Пароль: {emp.EPassword}");
            firstname.Text = "";
            secondname.Text = "";
            lastname.Text = "";
            password.Text = "";
            phone.Text = "";
        }

        private void InClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (idin.Text != "" && passwordin.Password != "")
                {
                    if ((passwordin.Password == Data.LogIn(db, int.Parse(idin.Text))))
                    {
                        if (Data.FindEmployee(db, int.Parse(idin.Text)).Department.DLevel.Equals("Y"))
                        {
                            var a = new AdminWindow();
                            a.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                            a.Show();
                            a.Owner = this;
                            a.Closed += A_Closed;
                        }
                        if (Data.FindEmployee(db, int.Parse(idin.Text)).Department.DLevel.Equals("N"))
                        {
                            var a = new CommonWindow();
                            a.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                            a.Show();
                            a.Owner = this;
                            a.Closed += A_Closed;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
            passwordin.Clear();
            idin.Clear();
        }

        private void A_Closed(object sender, EventArgs e)
        {
            this.Activate();
        }
    }
}
