using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class AppointmentToGivenDoctorNotFound:Exception
    {
        public AppointmentToGivenDoctorNotFound(string msg):base(msg)
        {

        }
    }
}
