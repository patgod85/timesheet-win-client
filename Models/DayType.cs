
using Newtonsoft.Json;

namespace Models
{
    public class DayType
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Title { get; private set; }

        [JsonProperty(PropertyName = "background_color")]
        public string BackgroundColor { get; private set; }

        public string Color { get; private set; }

        public DayType(int id, string name, string title, string backgroundColor, string color)
        {
            Id = id;
            Name = name;
            Title = title;
            BackgroundColor = backgroundColor;
            Color = color;
        }

    }
}
