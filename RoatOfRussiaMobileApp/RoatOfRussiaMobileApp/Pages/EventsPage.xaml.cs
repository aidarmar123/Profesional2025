
using Ical.Net;
using RoatOfRussiaMobileApp.Models;
using RoatOfRussiaMobileApp.Service;
using System.Text;
using Ical.Net;
using Ical.Net.DataTypes;
using Ical.Net.CalendarComponents;
using Ical.Net.Serialization;

namespace RoatOfRussiaMobileApp.Pages;

public partial class EventsPage : ContentPage
{
	public EventsPage()
	{
		InitializeComponent();
		Refresh();
	}

    private async void Refresh()
    {
		List<Event> events = await NetManager.Get<List<Event>>("api/Events"); 
        CvEvents.ItemsSource = events;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
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
    }
}