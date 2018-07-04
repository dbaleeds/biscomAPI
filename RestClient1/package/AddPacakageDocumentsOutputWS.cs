using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1.package
{
    class AddPacakageDocumentsOutputWS
    {
        // Instance variables
        /** The return code for the method call */
        public int returnCode { get; set; }
        /** The newly created documents list */
        public List<DocumentVOWS> documentVOs { get; set; }
    }
}
