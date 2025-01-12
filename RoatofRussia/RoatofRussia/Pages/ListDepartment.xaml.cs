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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RoatofRussia.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListDepartment.xaml
    /// </summary>
    public partial class ListDepartment : Page
    {
        public ListDepartment()
        {
            InitializeComponent();
            CreateTree();

        }



        private void CreateTree()
        {
            var departments = App.Db.Department.ToList();
            foreach (var department in departments)
            {
                var stackPanel = new StackPanel()
                {
                    Background = Brushes.LightGreen,
                    Margin = new Thickness(10),


                };
                RegisterName($"d{department.Id}", stackPanel);
                var textBlock = new TextBlock() { Text = department.Name, Margin = new Thickness(4) };
                stackPanel.Children.Add(textBlock);
                if (department.ParentDepartment == null)
                {
                    First.Children.Add(stackPanel);

                }
                else if (department.ParentDepartmentClass.ParentDepartment != null)
                {
                    var df = department.Departments;
                    Theard.Children.Add(stackPanel);

                }
                else
                {
                    Second.Children.Add(stackPanel);

                }

            }
            foreach (var department in departments)
            {
                StackPanel stackPanelParent = this.FindName($"d{department.Id}") as StackPanel;
                if (stackPanelParent != null)
                {

                    foreach (var child in department.Departments)
                    {
                        StackPanel stackPanel = FindName($"d{child.Id}") as StackPanel;
                        GetLine(stackPanel, stackPanelParent);

                    }
                }


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
                var point1 = sp1.TranslatePoint(new Point(sp1.ActualWidth / 2, sp1.ActualHeight / 2), MainCanvas);
                var point2 = sp2.TranslatePoint(new Point(sp2.ActualWidth / 2, sp2.ActualHeight / 2), MainCanvas);

                line.X1 = point1.X;
                line.Y1 = point1.Y;
                line.X2 = point2.X;
                line.Y2 = point2.Y;
            };
            Grid.SetRowSpan(line, 3);
            MainCanvas.Children.Add(line);
        }
    }
}
