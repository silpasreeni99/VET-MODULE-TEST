using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class AppointmentIdNotFoundException:Exception
    {
        public AppointmentIdNotFoundException(string msg):base(msg)
        {

        }
    }
}
