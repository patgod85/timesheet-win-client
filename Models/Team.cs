
namespace Models
{
    public class Team
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Code { get; private set; }

        public Team(int id, string name, string code)
        {
            Id = id;
            Name = name;
            Code = code;
        }
    }
}
