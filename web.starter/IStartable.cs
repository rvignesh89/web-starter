namespace web_starter
{
    public interface IStartable
    {
        bool Start();
        void Interrupt();        
    }
}