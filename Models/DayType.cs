
namespace Models
{
    public class DayType
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public DayType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
