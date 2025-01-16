
using RoatOfRussiaMobileApp.Models;
using RoatOfRussiaMobileApp.Service;
using System.Xml.Linq;

namespace RoatOfRussiaMobileApp.Pages;

public partial class NewsPage : ContentPage
{
	public NewsPage()
	{
		InitializeComponent();
		Refresh();
	}

    private void Refresh()
    {
        var list = new List<NewsItem>();
		
		
        var xDoc = XDocument.Load($"{NetManager.URl}api/news");
		list = xDoc.Descendants("item").Select(x=> new NewsItem()
		{
			title = (string)x.Element("title"),
            description = (string)x.Element("description"),
            link = (string)x.Element("link"),
            image = (string)x.Element("image"),
		}).ToList();
		CVNews.ItemsSource = list;
    }
}