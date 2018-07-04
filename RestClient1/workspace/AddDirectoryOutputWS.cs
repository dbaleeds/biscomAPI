using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class AddDirectoryOutputWS
    {
        // Instance variables

        /** The return code for the method call */
        public int returnCode { get; set; }
        /** The newly created folder as <code>{@link DirectoryVO}</code> object */
        public BDSFileVOWS bdsFileVOWS { get; set; }

    }
}
