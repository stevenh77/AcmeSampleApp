using Microsoft.Practices.Prism.PubSubEvents;

namespace Acme.UI.Events
{
    public class ApplicationExceptionEvent : PubSubEvent<string>
    {
    }
}
