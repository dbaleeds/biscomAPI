using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class GetSoleManagerWorkspacesOutputWS
    {
        /** The return code for the method call */
        public int returnCode { get; set; }
        /** The name of workspaces separated by comma */
        public string workspaceNames { get; set; }
        /** The total number of rows */
        public int soleManagerCount { get; set; }
    }
}
