using Newtonsoft.Json;

namespace Models.Request
{
    public class Day
    {
        [JsonProperty(PropertyName = "id")]
        public int UserId { get; private set; }

        [JsonProperty(PropertyName = "date")]
        public string Date { get; private set; }

        [JsonProperty(PropertyName = "type")]
        public int DayTypeId { get; private set; }

        public Day(int userId, string date, int dayTypeId)
        {
            UserId = userId;

            Date = date;

            DayTypeId = dayTypeId;
        }

    }
}
