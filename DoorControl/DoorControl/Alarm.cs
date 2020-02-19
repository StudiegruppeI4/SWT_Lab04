using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControl
{
    interface IAlarm
    {
        void RaiseAlarm();
        bool runSelfTest();
    }

    class Alarm : IAlarm
    {
        public Alarm() { }

        public void RaiseAlarm()
        {
            Console.WriteLine("Alarm raised!");
        }

        public bool runSelfTest()
        {
            return true;
        }
    }
}
