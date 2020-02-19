using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControl
{



    interface IDoor
    {
        void openDoor();
        void closeDoor();

        bool runSelfTest();
    }

    class Door : IDoor
    {
        public void openDoor()
        {
            Console.WriteLine("Door has been opened");
        }

        public void closeDoor()
        {
           Console.WriteLine("Door has been closed");
        }

        public bool runSelfTest()
        {
            return true;
        }

    }
}
