using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControl
{

    interface IEntryNotification
    {
        void NotifyEntryGranted();
        void NotifyEntryDenied();
    }

    class EntryNotification : IEntryNotification
    {
        public void NotifyEntryGranted()
        {
            Console.WriteLine("Notifying Entry Granted");
        }

        public void NotifyEntryDenied()
        {
            Console.WriteLine("Notifying Entry Denied");
        }
    }
}
