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
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для CardEmployee.xaml
    /// </summary>
    public partial class CardEmployee : Window
    {
        Employee contextEmployee;
        Event contextEvent = new Event();
        public CardEmployee(Models.Employee employee)
        {
            InitializeComponent();
            contextEmployee = employee;
            CbDepartments.ItemsSource = DbContext.Departments;
            CbCabinet.ItemsSource = DbContext.Cabinets;
            CbTypeEvent.ItemsSource = DbContext.TypeEvents;

            RefreshBox();
            if(contextEmployee.Id!=0)
                 RefreshEvent();
            SpAddEvent.DataContext = contextEvent;
            DataContext = contextEmployee;
        }

        private void RefreshEvent()
        {
            var eventEmployee = DbContext.EventEmployees.Where(x => x.EmployeeId == contextEmployee.Id).ToList();
            LVLearning.ItemsSource = eventEmployee.Where(x=>x.Event.TypeEventId ==1).ToList();
            LVAdsence.ItemsSource = eventEmployee.Where(x=>x.Event.TypeEventId ==2).ToList();
            LVVacation.ItemsSource = eventEmployee.Where(x=>x.Event.TypeEventId ==3).ToList();
        }

        private void RefreshBox()
        {
            if (contextEmployee.Id != 0)
            {
                CbPosition.ItemsSource = DbContext.Positions.Where(x=>x.DepartmentId == contextEmployee.Position.DepartmentId).ToList();
                CbDirector.ItemsSource = DbContext.Employees.Where(x=>x.Position.DepartmentId == contextEmployee.Position.DepartmentId).ToList();
                CbAssistent.ItemsSource = DbContext.Employees.Where(x => x.Position.DepartmentId == contextEmployee.Position.DepartmentId).ToList();
            }
            else
            {
                SpCard.IsEnabled = true;
            }
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            SpCard.IsEnabled = true;
        }

        private void CbDepartments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CbDepartments.SelectedItem is Department department)
            {
                CbPosition.ItemsSource = DbContext.Positions.Where(x => x.DepartmentId == department.Id).ToList();
                CbDirector.ItemsSource = DbContext.Employees.Where(x => x.Position.DepartmentId == department.Id).ToList();
                CbAssistent.ItemsSource = DbContext.Employees.Where(x => x.Position.DepartmentId == department.Id).ToList();
            }
        }

        private async void BSave_Click(object sender, RoutedEventArgs e)
        {
            var error = ValidObject.Valid(contextEmployee);
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
            }
            else
            {
                if (contextEmployee.Id == 0)
                {
                    await NetManager.Post($"api/Employees", contextEmployee);

                }
                else
                {
                    await NetManager.Put($"api/Employees/{contextEmployee.Id}", contextEmployee);
                }
                this.Close();
            }
        }

        private async void BDelete_Click(object sender, RoutedEventArgs e)
        {
            if(contextEmployee.Id == 0)
            {
                MessageBox.Show("Работник еще не работает");
                return;
            }

            if(contextEmployee.EventEmployee.FirstOrDefault(x=>x.Event.DateTimeEnd>DateTime.Now || x.Event.DateTimeStart > DateTime.Now) != null)
            {
                MessageBox.Show("Есть записи о предстоящих обучениях");
                return;
            }

            bool? rusult = new AbrovedDelete().ShowDialog();
            if (rusult.Value) 
            {
                contextEmployee.DateDismissal = DateTime.Now;
                var eventsEmployee = DbContext.EventEmployees.Where(x=>x.EmployeeId == contextEmployee.Id).ToList();
                foreach(var evEmp in eventsEmployee)
                {
                    await NetManager.Delete($"api/EventEmployees/{evEmp.Id}");
                }
                this.Close() ;
            }
        }
        private async Task AddEvent()
        {
            await NetManager.Post("api/Events", contextEvent);
            var events = await NetManager.Get<List<Event>>("api/Events");
            var idevent = events.Last().Id;
            await NetManager.Post("api/EventEmployees", new EventEmployee() { EventId = idevent, EmployeeId = contextEmployee.Id });
            contextEvent = new Event();
            SpAddEvent.DataContext = null;
            SpAddEvent.DataContext = contextEvent;
        }
        private async void BaddEvebt_Click(object sender, RoutedEventArgs e)
        {
            if(contextEmployee.Id == 0)
                return;

            var error = ValidObject.Valid(contextEvent);
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
            }
            else
            {
                if (contextEvent.DateTimeStart > contextEvent.DateTimeEnd)
                {
                    MessageBox.Show("Неправильные даты");
                    return;
                }
                    

                var workDays = await NetManager.Get<List<WorkingCalendar>>("api/WorkingCalendars");
                var eventEmployee = DbContext.EventEmployees.Where(x => x.EmployeeId == contextEmployee.Id).ToList();
                if(contextEvent.TypeEventId == 1)
                {
                    if (eventEmployee.FirstOrDefault(x => x.Event.TypeEventId == 2 && x.Event.DateTimeStart.Date == contextEvent.DateTimeStart.Date) == null)
                       await AddEvent();
                    
                }else if (contextEvent.TypeEventId == 2)
                {
                    if (eventEmployee.FirstOrDefault(x => x.Event.TypeEventId == 3 && x.Event.DateTimeStart.Date == contextEvent.DateTimeStart.Date) == null &&
                    eventEmployee.FirstOrDefault(x => x.Event.TypeEventId == 1 && x.Event.DateTimeStart.Date == contextEvent.DateTimeStart.Date) == null  
                    && workDays.FirstOrDefault(x=>x.ExceptionDate==contextEvent.DateTimeStart && !x.IsWorkingDay) == null)
                    {
                        await AddEvent();

                    }

                }else if(contextEvent.TypeEventId == 3)
                {
                    if (eventEmployee.FirstOrDefault(x => x.Event.TypeEventId == 1 && x.Event.DateTimeStart.Date == contextEvent.DateTimeStart.Date) == null )
                    
                    {
                        await AddEvent();

                    }
                }
                
            }
        }
    }
}
