﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class DoctorNotFoundException:Exception
    {
        public DoctorNotFoundException(string msg):base(msg)
        {

        }
    }
}
