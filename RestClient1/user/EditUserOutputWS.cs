﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1.user
{
    class EditUserOutputWS
    {
        // Instance variables

        /** The return code for the method call */
        public int returnCode { get; set; }
        /** The user with the edits performed */
        public UserVOWS userVO { get; set; }
    }
}
