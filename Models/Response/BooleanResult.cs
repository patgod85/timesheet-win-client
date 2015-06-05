
namespace Models.Response
{
    public class BooleanResult
    {
        public bool Success { get; private set; }

        public BooleanResult(bool success)
        {
            Success = success;
        }
    }
}
