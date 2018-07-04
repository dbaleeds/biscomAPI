using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class CommentVOWS
    {
        // Instance variables
        /** The reply's id. */
        public int commentId { get; set; }
        /** The reply's topic id. */
        public int topicId { get; set; }
        /** The reply's status. */
        public String status { get; set; }
        /** The reply's sequence number within topic. */
        public int replyNum { get; set; }
        /** The reply who created the record. */
        public int createdBy { get; set; }
        /** The date when the record was created. */
        public DateTime dateCreated { get; set; }
        /** The reply who last updated the record. */
        public int lastUpdatedBy { get; set; }
        /** The date when the record was last updated. */
        public DateTime dateLastUpdated { get; set; }
        /** The reply's subject. */
        public String replySubject { get; set; }
        /** The reply's body. */
        public String replyMessage { get; set; }
        /** The reply's notification message. */
        public String replySystemMessage { get; set; }
        /** The read indicator */
        public Boolean read { get; set; }
        /** The reply's view count. */
        public int totalViewed { get; set; }
        /** Virus scan status*/
        public String scanStatus { get; set; }
    }
}
