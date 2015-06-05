
using Newtonsoft.Json;

namespace Models.Request
{
    public class Login
    {
        [JsonProperty(PropertyName = "username")]
        public string Username { get; private set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; private set; }

        public Login(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
