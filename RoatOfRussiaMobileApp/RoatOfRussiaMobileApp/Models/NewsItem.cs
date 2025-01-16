namespace RoatOfRussiaMobileApp.Models
{
    public partial class NewsItem
    {
        public string guild { get; set; }
        public string link { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; }

        public string Image
        {
            get
            {
                return $"data:text/plain;base64{image}";
            }
        }
    }
}
