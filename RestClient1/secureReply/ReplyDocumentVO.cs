using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace RestClient1.secureReply
{
    class ReplyDocumentVO
    {
        [JsonProperty(PropertyName = "@type")]
        public string type { get; set; }
        public string createdBy { get; set; }
        public string dataFileId { get; set; }
        public string dateCreated { get; set; }
        public string dateLastUpdated { get; set; }
        public string hashValue { get; set; }
        public string isDownloadable { get; set; }
        public string lastUpdatedBy { get; set; }
        public string name { get; set; }
        public string replyDocumentId { get; set; }
        public string replyId { get; set; }
        public string size { get; set; }
        public string status { get; set; }

        public String toString()
        {
            String NEW_LINE = "\n";

            StringBuilder thisString = new StringBuilder();
            thisString.Append("type: ");
            thisString.Append(this.type);
            thisString.Append(NEW_LINE);
            thisString.Append("createdBy: ");
            thisString.Append(this.createdBy);
            thisString.Append(NEW_LINE);
            thisString.Append("dataFileId: ");
            thisString.Append(this.dataFileId);
            thisString.Append(NEW_LINE);
            thisString.Append("dateCreated: ");
            thisString.Append(this.dateCreated);
            thisString.Append(NEW_LINE);
            thisString.Append("replyDocumentId: ");
            thisString.Append(this.replyDocumentId);
            thisString.Append(NEW_LINE);
            thisString.Append("replyId: ");
            thisString.Append(this.replyId);
            thisString.Append(NEW_LINE);
            thisString.Append("size: ");
            thisString.Append(this.size);
            thisString.Append(NEW_LINE);
            thisString.Append("status: ");
            thisString.Append(this.status);
            thisString.Append(NEW_LINE);

            return thisString.ToString();
        }


    }
}