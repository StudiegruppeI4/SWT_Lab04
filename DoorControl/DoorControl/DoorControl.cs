using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControl
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class DoorControls
    {
        public DoorControls(IAlarm alarm, IDoor door, IEntryNotification entry, IUserValidation user)
        {
            _door = door;
            _alarm = alarm;
            _userValidation = user;
            _entryNotification = entry;
            _state = DoorStates.DoorClosed;
        }

        public enum DoorStates
        {
            DoorClosing, 
            DoorOpening,
            DoorBreached,
            DoorClosed,
            DoorOpen
        }

        private IDoor _door;
        private IAlarm _alarm;
        private IEntryNotification _entryNotification;
        private IUserValidation _userValidation;
        public DoorStates _state;

        public void RequestEntry(string validationstring)
        {
           var result =  _userValidation.validateEntryRequest(validationstring);
           if (result && _state == DoorStates.DoorClosed)
           {
               _entryNotification.NotifyEntryGranted();
               _state = DoorStates.DoorOpening;
               _door.openDoor();
               _state = DoorStates.DoorOpen;
               _door.closeDoor();
               _state = DoorStates.DoorClosing;
               _state = DoorStates.DoorClosed;

           }
           else if (_state == DoorStates.DoorOpen && !result)
           {
               _alarm.RaiseAlarm();
               _state = DoorStates.DoorBreached;
               _door.closeDoor();
               _state = DoorStates.DoorClosing;
               _state = DoorStates.DoorClosed;
           }
            else if (!result)
           {
               _entryNotification.NotifyEntryDenied();
           }

        }
    }

}


