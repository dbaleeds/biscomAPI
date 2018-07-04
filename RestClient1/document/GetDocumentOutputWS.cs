using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1.document
{
    class GetDocumentOutputWS
    {
        // Instance variables

        /** The return code for the method call */
        public int returnCode { get; set; }
        /** The specified document */
        public DocumentVOWS documentVO { get; set; }

        public GetDocumentOutputWS() {}

        public GetDocumentOutputWS(int returnCode, DocumentVOWS documentVO)
        {
            this.returnCode = returnCode;
            this.documentVO = documentVO;
        }



        public String toString() {
		string NEW_LINE = "\n";

        StringBuilder thisString = new StringBuilder();
		thisString.Append("returnCode: ");
		thisString.Append(this.returnCode);
		thisString.Append(NEW_LINE);
		thisString.Append("documentVO: ");
		thisString.Append((this.documentVO == null) ? "<null>" : this.documentVO.toString());
		thisString.Append(NEW_LINE);

		return thisString.ToString();
	}
    }
}
