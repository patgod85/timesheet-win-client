
namespace Models.Response
{
    public class LoginResult : BooleanResult
    {
        public User User { get; private set; }

        public LoginResult(bool success, User user)
            : base(success)
        {
            User = user;
        }
    }
}
