
namespace Models
{
    public class LoginResult
    {
        public bool Success { get; private set; }

        public LoginResult(bool success)
        {
            Success = success;
        }


    }
}
