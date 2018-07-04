using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class CompleteDataFileUploadOutputWS
    {
        /** The return code for the method call */
        public int returnCode { get; set; }

        /** The newly created data file */
        public DataFileVOWS DataFileVO { get; set; }

        public int ScanRequestId { get; set; }
    }
}
