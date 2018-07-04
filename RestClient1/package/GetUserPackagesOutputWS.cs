using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1.package
{
    class GetUserPackagesOutputWS
    {
        // Instance variables

        /** The return code for the method call */
        public int returnCode { get; set; }
        /** The list of {@link ExtPackageVO} objects */
        public List<ExtPackageVOWS> extPackageVOWss { get; set; }
        /** The total number of rows */
        public int totalRowCount { get; set; }
    }
}
