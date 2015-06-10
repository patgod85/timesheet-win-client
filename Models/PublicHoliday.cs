
namespace Models
{
    public class PublicHoliday
    {
        public string Date { get; private set; }

        public string Description { get; private set; }

        public PublicHoliday(string date, string description)
        {
            Date = date;
            Description = description;
        }
    }
}
