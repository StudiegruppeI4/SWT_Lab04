using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControl
{

    public interface IEntryNotification
    {
        void NotifyEntryGranted();
        void NotifyEntryDenied();

        bool runSelfTest();
    }

    public class EntryNotification : IEntryNotification
    {
        public void NotifyEntryGranted()
        {
            Console.WriteLine("Notifying Entry Granted");
        }

        public void NotifyEntryDenied()
        {
            Console.WriteLine("Notifying Entry Denied");
        }

        public bool runSelfTest()
        {
            return true;
        }
    }
}
