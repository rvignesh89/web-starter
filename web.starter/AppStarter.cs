using System;
using System.Collections.Generic;

namespace web_starter
{
    public class AppStarter
    {
        private readonly List<IStartable> _Instance;

        public AppStarter()
        {
            _Instance = new List<IStartable>();
        }

        public void StartAll()
        {
            _Instance.ForEach(x =>
            {
                try
                {
                    x.Start();
                }
                catch (Exception)
                {
                    x.OnException();
                }
            });
        }

        public void RegisterWith(IStartable startable)
        {
            _Instance.Add(startable);
        }
    }
}
