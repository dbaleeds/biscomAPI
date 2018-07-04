using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1.package
{
    class AddPackageOutputWS
    {
        /** The return code for the method call */
        public int returnCode { get; set; }
        /** The newly created package */
        public ExtPackageVOWS extPackageVO { get; set; }
        /** The list of email addresses (data type {@link String}) of non-users specified as owners */
        public List<String> nonUserEmails { get; set; }
        /** The list of inactive users ({@link com.biscom.fds.api.type.UserVO}) specified as owners */
        public List<UserVOWS> inactiveUsers { get; set; }
        /** The list of non-senders ({@link UserVO}) specified as owners */
        public List<UserVOWS> nonSenders { get; set; }
        /** The list of invalid email addresses (data type {@link String}) specified as owners */
        public List<String> invalidEmails { get; set; }
    }
}
