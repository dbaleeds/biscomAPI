using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class DataFileVOWS
    {
        /** The data file id */
        public int dataFileId { get; set; }
        /** The data file status */
        public String status { get; set; }
        /** The data file size */
        public long size { get; set; }
        /** The storage root id */
        public int storageRootId { get; set; }
        /** The data file datePurged */
        public DateTime datePurged { get; set; }
        /** The data file recoveryFilename */
        public String recoveryFilename { get; set; }
        /** The data file creation date */
        public DateTime creationDate { get; set; }
        /** The data file creator Id */
        public int createdBy { get; set; }
        /** The date when the data file was last updated */
        public DateTime lastUpdateDate { get; set; }
        /** The id of the user who last updated the data file */
        public int lastUpdatedBy { get; set; }

        public int encryptionKeyId { get; set; }
    }
}
