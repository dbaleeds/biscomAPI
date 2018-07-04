using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class InitiateDataFileUploadOutputWS
    {
        public int returnCode { get; set; }
        public int dataFileId { get; set; }
        public int chunkSize { get; set; }
    }
}
