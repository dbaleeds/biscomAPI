using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class GetWorkspaceOutputWS
    {
        // Instance variables

        /** The return code for the method call */
        public int returnCode { get; set; }
        /** The specified package */
        public WorkspaceVOWS workspaceVOWS { get; set; }
    }
}
