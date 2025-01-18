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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Models;
using WpfApp1.Services;
using WpfApp1.Windows;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListEmployee.xaml
    /// </summary>
    public partial class ListEmployee : Page
    {
        public ListEmployee()
        {
            InitializeComponent();
            RefreshList();
            Generate();
        }

        private void RefreshList()
        {
            DbContext.InitData();
            LVEmployee.ItemsSource = DbContext.Employees;

        }

        private async void Generate()
        {
            if(DbContext.Departments == null)
            {
                DbContext.InitData();
                DbContext.Departments =  await NetManager.Get<List<Department>>("api/Departments");
            }
            var departments = DbContext.Departments;
            foreach (var department in departments)
            {
                var stackPanel = new StackPanel()
                {
                    Margin = new Thickness(5),
                    Background = Brushes.LightGreen,
                    DataContext = department
                };
                
                var text = new TextBlock() { Text = department.Name };
                RegisterName($"d{department.Id}", stackPanel);
                stackPanel.Children.Add(text);

                stackPanel.MouseDown += StackPanel_MouseDown;
               if(department.ParentDepartmentId == null)
                {
                    First.Children.Add(stackPanel);
                    GetLine(stackPanel, SpOrg);
                }else if(department.ParentDepart.ParentDepartmentId != null)
                {
                    Therd.Children.Add(stackPanel);
                }
                else
                {
                    Second.Children.Add(stackPanel);
                }
            }
            foreach (var department in departments)
            {
                var stackPanel = FindName($"d{department.Id}") as StackPanel;
                if(stackPanel != null)
                {
                    foreach (var child in department.ChildDepart)
                    {
                        var childSp = FindName($"d{child.Id}") as StackPanel;
                        GetLine(stackPanel, childSp);
                    }
                }
            }
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var department = (sender as StackPanel).DataContext as Department;
            if(department != null)
            {
                var employeeList = new List<Employee>();
                employeeList = DbContext.Employees.Where(x=>x.Position.DepartmentId == department.Id).ToList();
                foreach(var child in department.ChildDepart)
                {
                    employeeList.AddRange(DbContext.Employees.Where(x => x.Position.DepartmentId == child.Id).ToList());
                    foreach(var child1 in child.ChildDepart)
                    {
                        employeeList.AddRange(DbContext.Employees.Where(x => x.Position.DepartmentId == child1.Id).ToList());

                    }
                }
                LVEmployee.ItemsSource = employeeList;

            }
            else
            {
                LVEmployee.ItemsSource = DbContext.Employees;
            }
        }

        private void GetLine(StackPanel sp1, StackPanel sp2)
        {
            var line = new Line()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
            };

            CompositionTarget.Rendering += (s, e) =>
            {
                var point1 = sp1.TranslatePoint(new Point(sp1.ActualWidth / 2, sp1.ActualHeight / 2), Main);
                var point2 = sp2.TranslatePoint(new Point(sp2.ActualWidth / 2, sp2.ActualHeight / 2), Main);

                line.X1 = point1.X;
                line.Y1 = point1.Y;
                line.X2 = point2.X;
                line.Y2 = point2.Y;
            };
            Grid.SetRowSpan(line, 4);
            Main.Children.Add(line);
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            new CardEmployee(new Employee()).ShowDialog();
            RefreshList();
        }

        private void LVEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(LVEmployee.SelectedItem is Employee employee)
            {
                new CardEmployee(employee).ShowDialog();
                RefreshList();

            }
        }
    }
}
