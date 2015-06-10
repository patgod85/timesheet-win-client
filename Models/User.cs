
namespace Models
{
    public class User
    {
        public int Id { get; private set; }

        public string Email { get; private set; }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public int TeamId { get; private set; }

        public string FullName { get { return Name + " " + Surname; }}

        public User(int id, string email, string name, string surname, int teamId)
        {
            Id = id;
            Email = email;
            Name = name;
            Surname = surname;
            TeamId = teamId;
        }
    }
}
