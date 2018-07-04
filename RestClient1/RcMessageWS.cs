using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    sealed class RcMessageWS
    {

        // Instance variables
        /** The return code for the method call */
        public int returnCode { get; set; }
        /** The newly created body of the message */
        public String body { get; set; }
    }
}
