using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class ObjectLink
    {
        /* The user ID*/
        public int userId { get; set; }
        /*The email address of the user*/
        public String emailAddress { get; set; }
        /* Link of the delivery/document for the user*/
        public String link { get; set; }
        
        public String toString()
        {
            StringBuilder thisString = new StringBuilder();
            thisString.AppendLine("Links for the users: ");
            thisString.Append("userId: ");
            thisString.AppendLine(this.userId.ToString());
            thisString.Append("Email Address: ");
            thisString.AppendLine(this.emailAddress);
            thisString.Append("Link: ");
            thisString.AppendLine(this.link);
            return thisString.ToString();
        }

    }
}
