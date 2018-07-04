using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1.secureReply
{
    class AddReplyOutputWS
    {
        // Instance variables

        /** The return code for the method call */
        public int returnCode { get; set; }
        /** The newly created <code>{@link ReplyVO}</code> */
        public ReplyVOWS replyVOws { get; set; }
        /** The newly created list of <code>{@link RcMessage}</code>s */
        private List<RcMessageWS> messages = new List<RcMessageWS>();

        internal List<RcMessageWS> Messages
        {
            get { return messages; }
            set { messages = value; }
        }

        private List<int> scanFileRequestIds = new List<int>();

        public List<int> ScanFileRequestIds
        {
            get { return scanFileRequestIds; }
            set { scanFileRequestIds = value; }
        }
        private Dictionary<String, String> fileNameMap = new Dictionary<String, String>();

        public Dictionary<String, String> FileNameMap
        {
            get { return fileNameMap; }
            set { fileNameMap = value; }
        }
    }
}
