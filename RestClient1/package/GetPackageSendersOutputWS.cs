using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1.package
{
    class GetPackageSendersOutputWS
    {
        // Instance variables
        /** The return code for the method call */
        public int returnCode { get; set; }
        /** The package senders */
        private List<UserVOWS> senders = new List<UserVOWS>();

        public List<UserVOWS> Senders
        {
            get { return senders; }
            set { senders = value; }
        }
        /** The total number of rows */
        public int totalRowCount { get; set; }
    }
}
