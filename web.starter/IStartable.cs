namespace web_starter
{
    public interface IStartable
    {
        void Start();
        void OnException();
        string GetName();
    }
}