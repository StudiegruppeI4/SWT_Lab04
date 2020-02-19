using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControl
{
    interface IUserValidation
    {
        bool validateEntryRequest(string validationstring);
        bool runSelfTest();
    }
    class UserValidation : IUserValidation
    {
        UserValidation() { }
        public bool validateEntryRequest(string validationstring)
        {
            if (validationstring == "password")
                return true;
            else
            {
                return false;
            }
        }

        public bool runSelfTest()
        {
            return true;
        }
    }
}
