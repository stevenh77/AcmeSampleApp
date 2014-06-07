using System;
using System.Diagnostics;
using Microsoft.Practices.Prism.Logging;

namespace Acme.UI.Services
{
    public class DebugLogger : ILoggerFacade
    {
        public void Log(string message, Category category, Priority priority)
        {
            string messageToLog =
                String.Format(System.Globalization.CultureInfo.InvariantCulture,
                    "{1}: {2}. Priority: {3}. Timestamp:{0:u}.",
                    DateTime.Now,
                    category.ToString().ToUpperInvariant(),
                    message,
                    priority);

            Debug.WriteLine(messageToLog);
        }
    }
}
