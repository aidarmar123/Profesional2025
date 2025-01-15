# Сайт огрганизации
![image](https://github.com/user-attachments/assets/2d73b376-fabe-4c29-8878-70efcab51df6)

## Новости (Rss-feed)
### Получение новоcтей 
```csharp
XDocument document = XDocument.Load(@"C:\Users\Aidar\Desktop\Profesional2025\RoatOfRussiaWebApp\RoatOfRussiaWebApp\Data\news_response.xml");
news = document.Descendants("item").Select(item => new NewsItem()
    {
        title = (string)item.Element("title"),
        image = (string)item.Element("image"),
        description = (string)item.Element("description")

    }).ToList();
```
### Обработка ошибок на не полученое фото 
```razor
@rendermode InteractiveServer
<img class="imgNews" src="@newsItem.image" @onerror='@(()=>newsItem.image="/assets/photoNews.jpg")' />

@code {
    [Parameter]
    public NewsItem newsItem { get; set; }

}
```
## События
### Скачивание файла .ics
#### Важно
```razor
<a role="button" href="@fileURL" download="@_event.Name .ics">📆</a>
```

```csharp
private void GenerateFile()
{
    var content = "text"
    var bytes = Encoding.UTF8.GetBytes(content);
    var base64 = Convert.ToBase64String(bytes);
    fileURL = $"data:text/plain;base64,{base64}";
}
```

```razor
<div class="date">
    @if (fileURL == null)
    {
        <p>Loading</p>
    }
    else
    {

        <a role="button" href="@fileURL" download="@_event.Name .ics">📆</a>
    }
    <p>@_event.DateTimeEvent.ToString("d")</p>
</div>

@code{
 [Parameter]
public Event? _event { get; set; }
private string? fileURL;
protected override void OnInitialized()
{
   GenerateFile();
}

private void GenerateFile()
{
    var content = $"BEGIN:VCALENDAR\nVERSION:2.0\nBEGIN:VEVENT\nSUMMARY:{_event.Name}\nDTSTART:{_event.DateTimeEvent.ToString("yyyyMMddTHHmmss")}\nDTEND:{_event.DateTimeEvent.ToString("yyyyMMddTHHmmss")}\nDTSTAMP:{_event.DateTimeEvent.ToString("yyyyMMddTHHmss")}\nUID:{_event.Id}\nDESCRIPTION:{_event.ShortDescription}\nLOCATION:{_event.ShortDescription}\nORGANIZER:{_event.ShortDescription}\nSTATUS:CONFIRMED\nPRIORITY:0\nEND:VEVENT\nEND:VCALENDAR";
    var bytes = Encoding.UTF8.GetBytes(content);
    var base64 = Convert.ToBase64String(bytes);
    fileURL = $"data:text/plain;base64,{base64}";
}
}
```

## Работники

### Генерация QrCode

#### В EmployeeLayout
```razor
 <a href="/qrcode/@employee.Id">💾</a>
```

### В QrCodePage

```razor
@page "/qrcode/{Id:int}"
@using QRCoder

<img src="@qrcodeText" width="250"/>

@code {
    [Parameter]
    public int? Id { get; set; }

    public string qrcodeText = "";
    protected override async Task OnInitializedAsync()
    {
        Employee employee = await NetManager.Get<Employee>($"api/Employees/{Id}");
        var qrGenerator = new QRCodeGenerator();
        var vcardtext = $"BEGIN:VCARD \nVERSION:3.0\nN:{employee.Name}\nFN: {employee.Surname}\nORG: Дороги России\nTITLE:{employee.Position.Name}\nTEL; WORK; VOICE: {employee.WorkPhone}\nTEL; CELL: {employee.HomePhone}\nEMAIL; WORK; INTERNET:{employee.Email}\nEND:VCARD";
        var qrData = qrGenerator.CreateQrCode(vcardtext, QRCodeGenerator.ECCLevel.L);

        using (var qrcode = new PngByteQRCode(qrData))
        {
            var qrBytes = qrcode.GetGraphic(20);
            qrcodeText = $"data:image/png;base64,{Convert.ToBase64String(qrBytes)}";
        }
    }
}
```
Библиотека [QRCoder]("https://github.com/codebude/QRCoder/")


### Календарь
```razor
@using Models
@rendermode InteractiveServer

<header class="headerCalendar">
    <button @onclick="PrevoisMonth"> ⬅ </button>
    <h3>@selectDate.ToString("Y")</h3>
    <button @onclick="NextMonth"> ➡ </button>

</header>
<div class="calendar">


    <table width="100%">
        <thead>
            <tr>
                @foreach (var day in days)
                {
                    <th>
                        <div class="theader">

                            @day

                        </div>
                    </th>

                }
            </tr>
        </thead>
        <tbody>
            @for (int i = 1; i < dayInMonth - 1;)
            {
                <tr>
                    @for (int y = 0; y < 7; y++)
                    {
                        @if (i > dayInMonth)
                        {
                            <td></td>
                        }
                        else if (y < dayOfWeekMonth - 1 && i < 2)
                        {
                            <td></td>

                        }
                        else
                        {

                            <td>
                                <div class="@(date.Day==i&&date.Month==selectDate.Month&&selectDate.Year==date.Year?"today":"")
                                            @(workDay.FirstOrDefault(x=>x.ExceptionDate.Month==selectDate.Month && x.ExceptionDate.Day==i && x.IsWorkingDay==false)!=null?"holiday":"")
                                            @(events.Where(x=>x.DateTimeEvent.Month==selectDate.Month && x.DateTimeEvent.Day == i).Count()>=5?
"red":events.Where(x=>x.DateTimeEvent.Month==selectDate.Month && x.DateTimeEvent.Day == i).Count()==0?
"":events.Where(x=>x.DateTimeEvent.Month==selectDate.Month && x.DateTimeEvent.Day == i).Count()<2?
"green":"yellow")
                                            day">
                                    @if (employees.FirstOrDefault(e => e.Birthday.Month == selectDate.Month && e.Birthday.Day == i) != null)
                                    {

                                        <span title="@string.Join("\n", employees.Where(e => e.Birthday.Month == selectDate.Month && e.Birthday.Day == i).Select(x=>x.Surname).ToList())" class="@(true?i++:"")">🎂</span>
                                    }
                                    else
                                    {
                                        @(i++)

                                    }

                                </div>
                            </td>
                        }
                    }
                </tr>
            }
        </tbody>
    </table>
</div>

@code {
    [Parameter]
    public List<Event> events { get; set; }

    [Parameter]
    public List<Employee> employees { get; set; }

    [Parameter]
    public List<WorkingCalendar> workDay { get; set; }

    public DateTime date = DateTime.Now;
    public DateTime selectDate { get; set; }
    public string[] days = new string[] { "П", "В", "С", "Ч", "П", "С", "В" };

    private DateTime lastDayOfMonth{ get; set; }
    public int dayOfWeekMonth{ get; set; }
    public int dayInMonth{ get; set; }

    protected override void OnInitialized()
    {
        selectDate = date;
        Create();

    }
    private void Create()
    {
        dayInMonth = DateTime.DaysInMonth(selectDate.Year, selectDate.Month);
        lastDayOfMonth = new DateTime(selectDate.Year, selectDate.Month, 1);
        dayOfWeekMonth = (int)lastDayOfMonth.DayOfWeek;
    }

    public void PrevoisMonth()
    {
        selectDate = selectDate.AddMonths(-1);
        Create();
    }

    private void NextMonth()
    {
        selectDate = selectDate.AddMonths(1);
        Create();
    }
}
```
