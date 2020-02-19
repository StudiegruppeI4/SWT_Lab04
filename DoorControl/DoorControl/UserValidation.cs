using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControl
{
    public interface IUserValidation
    {
        bool validateEntryRequest(string validationstring);
        bool runSelfTest();
    }
    public class UserValidation : IUserValidation
    {
        UserValidation() { }
        public bool validateEntryRequest(string validationstring)
        {
            if (validationstring == "password")
                return true;

            return false;
        }

        public bool runSelfTest()
        {
            return true;
        }
    }
}
