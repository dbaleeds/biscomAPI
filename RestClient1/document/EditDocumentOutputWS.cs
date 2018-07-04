using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1.document
{
    class EditDocumentOutputWS
    {
        // Instance variables

        /** The return code for the method call */
        public int returnCode { get; set; }

        /** The document with the edits performed */
        public DocumentVOWS documentVO { get; set; }
    }
}
