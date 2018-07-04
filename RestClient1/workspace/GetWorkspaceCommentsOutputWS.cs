using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class GetWorkspaceCommentsOutputWS
    {
        /** The return code for the method call */
        public int returnCode { get; set; }
        /** The specified package */
        public List<CommentInfoWS> commentInfoList { get; set; }

        public string toString() 
        {
		String NEW_LINE = "\n";

		StringBuilder thisString = new StringBuilder();
		thisString.Append("returnCode: ");
		thisString.Append(this.returnCode);
		thisString.Append(NEW_LINE);
		thisString.Append("commentInfoList: ");
        foreach (CommentInfoWS cif in commentInfoList)
        {
            thisString.Append((cif == null) ? "<null>" : cif.toString());
        }
            
		thisString.Append(NEW_LINE);

		return thisString.ToString();
	}
    
    }
}
