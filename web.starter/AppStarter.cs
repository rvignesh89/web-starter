using System.Collections.Generic;
using log4net;

namespace web_starter
{
    public class AppStarter
    {
        private readonly ILog _Log;
        private readonly List<IStartable> _Instance;

        public AppStarter(ILog log)
        {
            _Log = log;
            _Instance = new List<IStartable>();
        }

        public void StartAll()
        {
            _Instance.ForEach(x =>
            {
                if(!x.Start())
                    _Log.ErrorFormat("Subscriber {0} failed to start",x.GetName());
            });
        }

        public void RegisterWith(IStartable startable)
        {
            _Instance.Add(startable);
        }
    }
}
