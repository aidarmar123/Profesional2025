### Генерация отделов 
C#
```csharp
private async void CreateDepartment()
{
    if (DataManager.Departments == null)
        DataManager.Departments = await NetManger.Get<List<Department>>("api/Departments");

    var departmants = DataManager.Departments;
    foreach (var departmant in departmants)
    {
        var sp = new StackPanel() { Margin = new Thickness(5), Background = Brushes.LightGreen, DataContext = departmant };
        sp.MouseDown += SpOrg_MouseDown;
        RegisterName($"d{departmant.Id}", sp);
        var name = new TextBlock() { Text = departmant.Name, Margin = new Thickness(10) };
        sp.Children.Add(name);
        if (departmant.ParentDepartmentId == null)
        {
            First.Children.Add(sp);
            GetLines(sp, SpOrg);
        }
        else if (departmant._ParentDepartment.ParentDepartmentId != null)
        {
            Therd.Children.Add(sp);
        }
        else
        {
            Second.Children.Add(sp);
        }


    }
    foreach(var department in departmants)
    {
        var spParent = FindName($"d{department.Id}") as StackPanel;
        if(spParent != null)
        {
            foreach(var child in department.ChildDepartments)
            {
                var spChild = FindName($"d{child.Id}") as StackPanel;
                GetLines(spParent, spChild);
            }
        }
    }

}
```


XAML
```xaml
 <ScrollViewer HorizontalScrollBarVisibility="Visible" VerticalScrollBarVisibility="Visible">
     <Grid x:Name="MainGrid">
         <Grid.RowDefinitions>
             <RowDefinition/>
             <RowDefinition/>
             <RowDefinition/>
             <RowDefinition/>
         </Grid.RowDefinitions>
         <StackPanel HorizontalAlignment="Center"
                     MouseDown="SpOrg_MouseDown"
                     VerticalAlignment="Center"
                     Background="LightGreen"
                     x:Name="SpOrg">
             <TextBlock Text="Дороги России"
                        Margin="10"/>
         </StackPanel>

         <StackPanel Orientation="Horizontal" Grid.Row="1"
                     x:Name="First" HorizontalAlignment="Center" VerticalAlignment="Center"/>
         <StackPanel Orientation="Horizontal" Grid.Row="2"
                     x:Name="Second" HorizontalAlignment="Center" VerticalAlignment="Center"/>
         <StackPanel Orientation="Horizontal" Grid.Row="3"
                     x:Name="Therd" HorizontalAlignment="Center" VerticalAlignment="Center"/>
         
         
     </Grid>
 </ScrollViewer>
```

## Генерация стрелок
```csharp
  private void GetLines(StackPanel sp1, StackPanel sp2)
  {
      var line = new Line()
      {
          Stroke = Brushes.Black,
          StrokeThickness = 1.5
      };

      CompositionTarget.Rendering += (s, e) =>
      {
          var point1 = sp1.TranslatePoint(new Point(sp1.ActualWidth / 2, sp1.ActualHeight / 2), MainGrid);
          var point2 = sp2.TranslatePoint(new Point(sp2.ActualWidth / 2, sp2.ActualHeight / 2), MainGrid);

          line.X1 = point1.X;
          line.Y1 = point1.Y;
          line.X2 = point2.X;
          line.Y2 = point2.Y;
      };

      Grid.SetRowSpan(line, 4);
      MainGrid.Children.Add(line);
  }
```


## Сортировка событий 
```csharp
 private void SortEvent()
 {
     var eventsEmployee = DataManager.EmployeeEvents.Where(x => x.EmployeeId == contextEmployee.Id).ToList();
     if (!CBPast.IsChecked.Value)
     {
         var lastEvents = eventsEmployee.Where(x => x._Event.DateEnd < DateTime.Now).ToList();
         foreach (var e in lastEvents)
         {
             eventsEmployee.Remove(e);
         }
     }

     if (!CBPresent.IsChecked.Value)
     {
         var lastEvents = eventsEmployee.Where(x => x._Event.DateEnd >= DateTime.Now && x._Event.DateStart <= DateTime.Now).ToList();
         foreach (var e in lastEvents)
         {
             eventsEmployee.Remove(e);
         }
     }
     if (!CBFuture.IsChecked.Value)
     {
         var lastEvents = eventsEmployee.Where(x => x._Event.DateStart > DateTime.Now).ToList();
         foreach (var e in lastEvents)
         {
             eventsEmployee.Remove(e);
         }
     }
     EmployeeEvents = eventsEmployee.OrderBy(x=>x._Event.DateStart).ToList();
     RefreshList();
 }
```
