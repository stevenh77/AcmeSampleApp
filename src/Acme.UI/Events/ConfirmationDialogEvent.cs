using Microsoft.Practices.Prism.PubSubEvents;
using System;

namespace Acme.UI.Events
{
    public class ConfirmationDialogEvent : PubSubEvent<Action>
    {
    }
}
