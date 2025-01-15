using RoatofRussia.Models;
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

namespace RoatofRussia.Windows
{
    /// <summary>
    /// Логика взаимодействия для CardEmployee.xaml
    /// </summary>
    public partial class CardEmployee : Window
    {
        Employee contextEmployee;
        public CardEmployee(Models.Employee employee)
        {
            InitializeComponent();
            contextEmployee = employee;
            DataContext = contextEmployee;
            CbDeprtment.ItemsSource = App.Db.Department.ToList();
            CbCabinet.ItemsSource = App.Db.Cabinet.ToList();
            Refresh();
           

        }

        private void Refresh()
        {
            if (CbDeprtment.SelectedItem != null && CbDeprtment.SelectedItem is Department department)
            {
                CbPosition.ItemsSource = App.Db.Position.Where(x => x.DepartmentId == department.Id).ToList();
                CbDirector.ItemsSource = App.Db.Employee.Where(x => x.Position.DepartmentId == department.Id).ToList();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CbDeprtment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Department selectDepartment = null;
            if (CbDeprtment.SelectedItem is Department department)
            {
                selectDepartment = department;
            }
            Refresh();

            if(selectDepartment != null)
            {
                CbDeprtment.SelectedItem = selectDepartment;
            }
        }
    }
}
