﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class FeedbackNotPresentException:Exception
    {
        public FeedbackNotPresentException(string msg):base(msg)
        {

        }
    }
}
