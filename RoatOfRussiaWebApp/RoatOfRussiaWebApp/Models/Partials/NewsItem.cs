namespace RoatOfRussiaWebApp.Models
{
    public partial class NewsItem
    {

        public string Find
        {
            get
            {
                return " " + title + description;
            }
        }
    }
}
