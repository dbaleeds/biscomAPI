using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class DocumentVOWS
    {
        // Instance variables

        /** 
         * The document id.
         */
        public int documentId { get; set; }
        /** 
         * The document status.
         */
        public String status { get; set; }
        /** 
         * The document name.
         */
        public String name { get; set; }
        /** 
         * The document description.
         */
        public String description { get; set; }
        /** 
         * The document size.
         */
        public long size { get; set; }
        /** 
         * The id of the directory the document belongs to.
         */
        public int directoryId { get; set; }
        /** 
         * The id of the data file for the document.
         */
        public int dataFileId { get; set; }
        /** 
         * The document creator Id.
         */
        public int createdBy { get; set; }
        /** 
         * The date when the object was created.
         */
        public DateTime dateCreated { get; set; }
        /** 
         * The id of the user who last updated the document.
         */
        public int lastUpdatedBy { get; set; }
        /** 
         * The date when the object was last updated.
         */
        public DateTime dateLastUpdated { get; set; }
        /** 
         * The display order of the document by which the document will be sorted.
         */
        public int displayOrder { get; set; }
        /** 
         * Flag indicating whether a document is downloadable or not.
         */
        //public Boolean isDownloadable= true;

        public Boolean isDownloadable = true;

        public Boolean IsDownloadable
        {
            get { return isDownloadable; }
            set { isDownloadable = value; }
        }



        /** 
         * Flag indicating whether the document is encrypted.
         */
        public Boolean isEncrypted = false;

        public Boolean IsEncrypted
        {
            get { return isEncrypted; }
            set { isEncrypted = value; }
        }

        /** 
         * The hash value of the document.
         */
        public String hashValue { get; set; }

        public String lastScanStatus { get; set; }

        public String fileDownloadLinks { get; set; }

        public DocumentVOWS(int documentId, string status, string name, string description, long size, int directoryId, int dataFileId,
            int createdBy, System.DateTime dateCreated, int lastUpdatedBy, System.DateTime dateLastUpdated, int displayOrder, bool isDownloadable,
            bool isEncrypted, string hashValue, string lastScanStatus, string fileDownloadLinks)
        {
            this.fileDownloadLinks = fileDownloadLinks;
            this.lastScanStatus = lastScanStatus;
            this.hashValue = hashValue;
            this.IsEncrypted = isEncrypted;
            this.IsDownloadable = isDownloadable;
            this.displayOrder = displayOrder;
            this.dateLastUpdated = dateLastUpdated;
            this.lastUpdatedBy = lastUpdatedBy;
            this.dateCreated = dateCreated;
            this.createdBy = createdBy;
            this.dataFileId = dataFileId;
            this.directoryId = directoryId;
            this.size = size;
            this.description = description;
            this.name = name;
            this.status = status;
            this.documentId = documentId;
        }


        public String toString()
        {
            string NEW_LINE = "\n";

            StringBuilder thisString = new StringBuilder();
            thisString.Append("documentId: ");
            thisString.Append(this.documentId);
            thisString.Append(NEW_LINE);
            thisString.Append("status: ");
            thisString.Append((this.status != null) ? this.status : "<null>");
            thisString.Append(NEW_LINE);
            thisString.Append("name: ");
            thisString.Append((this.name != null) ? this.name : "<null>");
            thisString.Append(NEW_LINE);
            thisString.Append("description: ");
            thisString.Append((this.description != null) ? this.description : "<null>");
            thisString.Append(NEW_LINE);
            thisString.Append("size: ");
            thisString.Append(this.size);
            thisString.Append(NEW_LINE);
            thisString.Append("directoryId: ");
            thisString.Append(this.directoryId);
            thisString.Append(NEW_LINE);
            thisString.Append("dataFileId: ");
            thisString.Append(this.dataFileId);
            thisString.Append(NEW_LINE);
            thisString.Append("createdBy: ");
            thisString.Append(this.createdBy);
            thisString.Append(NEW_LINE);
            thisString.Append("dateCreated: ");
            thisString.Append((this.dateCreated == null) ? "<null>" : this.dateCreated.ToString());
            thisString.Append(NEW_LINE);
            thisString.Append("lastUpdatedBy: ");
            thisString.Append(this.lastUpdatedBy);
            thisString.Append(NEW_LINE);
            thisString.Append("dateLastUpdated: ");
            thisString.Append((this.dateLastUpdated == null) ? "<null>" : this.dateLastUpdated.ToString());
            thisString.Append(NEW_LINE);
            thisString.Append("displayOrder: ");
            thisString.Append(this.displayOrder);
            thisString.Append(NEW_LINE);
            thisString.Append("isDownloadable: ");
            thisString.Append(this.isDownloadable);
            thisString.Append(NEW_LINE);
            thisString.Append("isEncrypted: ");
            thisString.Append(this.isEncrypted);
            thisString.Append(NEW_LINE);
            thisString.Append("hashValue: ");
            thisString.Append(this.hashValue);
            thisString.Append(NEW_LINE);
            thisString.Append("lastScanStatus: ");
            thisString.Append(this.lastScanStatus);
            thisString.Append(NEW_LINE);
            thisString.Append("fileDownloadLinks: ");
            thisString.Append(this.fileDownloadLinks);
            thisString.Append(NEW_LINE);

            return thisString.ToString();
        }
    }
}
