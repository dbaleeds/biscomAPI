using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1.package
{
    class GetPackageOwnersOutputWS
    {
        // Instance variables

        /** The return code for the method call */
        public int returnCode { get; set; }
        /** List of owners */
        private List<UserVOWS> owners = new List<UserVOWS>();

        public List<UserVOWS> Owners
        {
            get { return owners; }
            set { owners = value; }
        }
        /** The total number of rows */
        public int totalRowCount { get; set; }
    }
}
