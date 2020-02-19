using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DoorControl;
using NSubstitute;

namespace DoorControlTests
{
    [TestFixture]
    public class DoorControlTestTest
    {
        private DoorControls uut;
        private IAlarm _alarm;
        private IDoor _door;
        private IEntryNotification _entry;
        private IUserValidation _validation;


        [SetUp]
        public void setup()
        {
            _alarm = Substitute.For<IAlarm>();
            _door = Substitute.For<IDoor>();
            _entry = Substitute.For<IEntryNotification>();
            _validation = Substitute.For<IUserValidation>();
            uut = new DoorControls(_alarm, _door, _entry, _validation);
        }

        [Test]
        public void entryDeniedAndDoorStateClosed()
        {
            _validation.validateEntryRequest("password").Returns(true);
            uut.RequestEntry("eh");
            _entry.Received(1).NotifyEntryDenied();
            Assert.That(uut._state,Is.EqualTo(DoorControls.DoorStates.DoorClosed));
        }

        [Test]
        public void entryAccessed()
        {
            _validation.validateEntryRequest("password").Returns(true);
            uut.RequestEntry("password");
            _entry.Received(1).NotifyEntryGranted();
            _door.Received(1).openDoor();
            _door.Received(1).closeDoor();
        }
    }
}
