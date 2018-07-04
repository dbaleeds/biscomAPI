using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RestClient1.dataFile
{
    class GetDataFileChunkISOutputWS
    {
        // Instance variables

        /** The return code for the method call */
        public int returnCode { get; set; }
        /** InputStream of the chunk */
        public Stream inputStream { get; set; }
        /** Chunk size read by the helper */
        public int bytesRead { get; set; }
        /** Checksum of the data */
        public string checksum { get; set; }
    }
}
