using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1.delivery
{
    class AddExpressDeliveryWithDataFileIdsExtOutputWS
    {
        public int ReturnCode { get; set; }
        /** The newly created delivery */
        public DeliveryVOWS deliveryVO { get; set; }
        /** The list of email addresses (data type {@link String}) of non-users specified as recipients */
        public List<String> nonUserEmails { get; set; }
        /** The list of inactive users ({@link com.biscom.fds.api.type.UserVO}) specified as recipients */
        public List<UserVOWS> inactiveUsers { get; set; }
        /** The list of non-recipients ({@link com.biscom.fds.api.type.UserVO}) specified as recipients */
        public List<UserVOWS> nonRecipients { get; set; }
        /** The list of invalid email addresses (data type {@link String}) specified as recipients */
        public List<String> invalidEmails { get; set; }
        /** The list of email addresses the user is not allowed to send to (data type {@link String}) */
        public List<String> rejectedEmails { get; set; }
    }
}
