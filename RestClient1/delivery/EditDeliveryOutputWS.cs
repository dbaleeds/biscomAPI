using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RestClient1.delivery
{
    class EditDeliveryOutputWS
    {
        // Instance variables

        /** The return code for the method call */
        public int returnCode{get; set;}
        /** The delivery with the edits performed */
        public DeliveryVOWS deliveryVO{get; set;}
        /** The list of email addresses (data type {@link string}) of non-users specified as recipients */
        public List<string> nonUserEmails{get; set;}
        /** The list of inactive users ({@link UserVO}) specified as recipients */
        public List<UserVOWS> inactiveUsers{get; set;}
        /** The list of non-recipients ({@link UserVO}) specified as recipients */
        public List<UserVOWS> nonRecipients{get; set;}
        /** The list of invalid email addresses (data type {@link string}) specified as recipients */
        public List<string> invalidEmails{get; set;}
        /** The list of email addresses the user is not allowed to send to (data type {@link string}) */
        public List<string> rejectedEmails{get; set;}
    }
}
