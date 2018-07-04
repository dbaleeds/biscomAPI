using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class GetInitPropertyOutputWS
    {
        /** The return code for the method call */
        public int returnCode {get; set;}
        /** The specified initialization property */
        public InitPropertyVOWS initPropertyVOWS { get; set; }
    }
}
