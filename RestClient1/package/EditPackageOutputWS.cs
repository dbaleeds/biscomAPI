using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1.package
{
    class EditPackageOutputWS
    {
        // Instance variables
        /** The return code for the method call */
        public int returnCode { get; set; }
        /** The package with the edits performed */
        public ExtPackageVOWS extPackageVO { get; set; }
        /** The list of email addresses (data type {@link String}) of non-users specified as owners */
        public List<string> nonUserEmails { get; set; }
        /** The list of inactive users ({@link UserVOWS}) specified as owners */
        public List<UserVOWS> inactiveUsers { get; set; }
        /** The list of non-senders ({@link UserVOWS}) specified as owners */
        public List<UserVOWS> nonSenders { get; set; }
        /** The list of invalid email addresses (data type {@link String}) specified as owners */
        public List<string> invalidEmails { get; set; }
    }
}
