using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1.delivery
{
    class AddDeliveryOutputWS
    {
        /** 
   * The return code for the method call 
   */
        public int returnCode { get; set; }
        /** 
         * The newly created delivery 
         */
        public DeliveryVOWS deliveryVOWS { get; set; }
        /** 
         * The list of email addresses (data type {@link String}) of non-users specified as recipients 
         */
        public List<string> nonUserEmails { get; set; }
        /** 
         * The list of inactive users ({@link UserVOWS}) specified as recipients 
         */
        public List<UserVOWS> inactiveUsers { get; set; }
        /** 
         * The list of non-recipients ({@link UserVOWS}) specified as recipients 
         */
        public List<UserVOWS> nonRecipients { get; set; }
        /** 
         * The list of invalid email addresses (data type {@link String}) specified as recipients 
         */
        public List<string> invalidEmails { get; set; }
        /** 
         * The list of email addresses the user is not allowed to send to (data type {@link String}) 
         */
        public List<string> rejectedEmails { get; set; }
    }
}
