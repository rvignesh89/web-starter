using System.Collections.Generic;

namespace web_starter
{
    public class AppStarter
    {
        public List<IStartable> Instance { get; set; }

        public AppStarter()
        {
            Instance = new List<IStartable>();
        }
    }
}
