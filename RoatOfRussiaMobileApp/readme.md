## Мобильное приложение 

### Насторийка APi
В Api в файле ".vs/RoatOfRussiaApi/config/applicationhost.config" добавить 
```xaml
<binding protocol="http" bindingInformation="*:62367:127.0.0.1" />
```
### Настройка Visual Studio 
В командной строке Adb Android прописать команду
```
adb reverse tcp:62367 tcp:62367
```
В Platforms/Android/MainApplication изменить [Application]
```csharp
 [Application(UsesCleartextTraffic = true)]
 public class MainApplication : MauiApplication
 {
     public MainApplication(IntPtr handle, JniHandleOwnership ownership)
         : base(handle, ownership)
     {
     }

     protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
 }
```

### Скачивание .ics файла

```csharp
var _event = (sender as Button).BindingContext as Event;
       
var icalEvent = new CalendarEvent
{
    Summary = _event.Name,
    Start = new CalDateTime(_event.DateTimeEvent.Year, _event.DateTimeEvent.Month, _event.DateTimeEvent.Day),
    End = new CalDateTime(_event.DateTimeEvent.Year, _event.DateTimeEvent.Month, _event.DateTimeEvent.Day),
    IsAllDay = true,
};

var calendar = new Calendar();
calendar.Events.Add(icalEvent);

var serializer = new CalendarSerializer();
string icalContent = serializer.SerializeToString(calendar);

string filePath = "event.ics";

string popoverTitle = "Read ical file";
string file = System.IO.Path.Combine(FileSystem.CacheDirectory, filePath);

System.IO.File.WriteAllText(file, icalContent);

Launcher.Default.OpenAsync(new OpenFileRequest(popoverTitle, new ReadOnlyFile(file))).ConfigureAwait(false);
```
