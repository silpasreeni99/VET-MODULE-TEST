using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class FeedbackExitsException:Exception
    {
        public FeedbackExitsException(string msg):base(msg)
        {

        }
    }
}
