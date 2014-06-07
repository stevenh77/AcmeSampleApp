using System;
using System.Collections.Concurrent;

namespace Acme.UI.Services
{
    public class SessionState : ConcurrentDictionary<StateKeys, object>
    {
        // use this for a quick way to get an item you know should exist
        public T Get<T>(StateKeys key)
        {
            object item;
            if (this.TryGetValue(key, out item)) return (T)item;
            throw new Exception(key + " not found in SessionState");
        }
    }
}
