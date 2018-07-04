using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1.package
{
    class ExtPackageVOWS
    {
        // Instance variables
        /** Flag to indicate if the user who retrieved this package is an owner of the package */
        public Boolean requesterIsOwner { get; set; }
        /** The id of the package */
        public int packageId { get; set; }
        /** The status of the package */
        public string status { get; set; }
        /** The id of the folder the package is in */
        public int folderId { get; set; }
        /** The latest version number of the package */
        public int latestVersion { get; set; }
        /** The latest published version number of the package */
        public int latestPublishedVersion { get; set; }
        /** The user who created the record. */
        public int createdBy { get; set; }
        /** The date when the package will be deleted automatically. */
        public DateTime autoDelDate { get; set; }
        /** The date when the package deletion reminder will be send. */
        public DateTime autoDelReminderDate { get; set; }
        /** The date when the package deletion reminder was sent. */
        public DateTime autoDelReminderSentDate { get; set; }
        /** The date when the record was created. */
        public DateTime dateCreated { get; set; }
        /** The user who last updated the record. */
        public int lastUpdatedBy { get; set; }
        /** The date when the record was last updated. */
        public DateTime dateLastUpdated { get; set; }
        /** The date when the package was accessed. */
        public DateTime lastActivityDate { get; set; }
        /** The date when the package was last delivered. */
        public DateTime dateLastDelivered { get; set; }
        /** Is the package limited? */
        public Boolean isLimited { get; set; }
        /** The number of valid primary owners of the package */
        public int validPrimaryOwnerCount { get; set; }
        /** Is the package allowed for collaboration? */
        public Boolean allowCollaboration { get; set; }


        public string toString() {
		string NEW_LINE = "\n";

        StringBuilder thisString = new StringBuilder();
		thisString.Append("packageId: ");
		thisString.Append(this.packageId);
		thisString.Append(NEW_LINE);
		thisString.Append("status: ");
		thisString.Append((this.status == null) ? "<null>" : this.status);
		thisString.Append(NEW_LINE);
		thisString.Append("folderId: ");
		thisString.Append(this.folderId);
		thisString.Append(NEW_LINE);
		thisString.Append("latestVersion: ");
		thisString.Append(this.latestVersion);
		thisString.Append(NEW_LINE);
		thisString.Append("latestPublishedVersion: ");
		thisString.Append(this.latestPublishedVersion);
		thisString.Append(NEW_LINE);
		thisString.Append("createdBy: ");
		thisString.Append(this.createdBy);
		thisString.Append(NEW_LINE);
		thisString.Append("autoDelDate: ");
		thisString.Append((this.autoDelDate == null) ? "<null>" : this.autoDelDate.ToString());
		thisString.Append(NEW_LINE);
		thisString.Append("autoDelReminderDate: ");
		thisString.Append((this.autoDelReminderDate == null) ? "<null>" : this.autoDelReminderDate.ToString());
		thisString.Append(NEW_LINE);
		thisString.Append("autoDelReminderSentDate: ");
		thisString.Append((this.autoDelReminderSentDate == null) ? "<null>"
				: this.autoDelReminderSentDate.ToString());
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
		thisString.Append("lastActivityDate: ");
		thisString.Append((this.lastActivityDate == null) ? "<null>" : this.lastActivityDate.ToString());
		thisString.Append(NEW_LINE);
		thisString.Append("dateLastDelivered: ");
		thisString.Append((this.dateLastDelivered == null) ? "<null>" : this.dateLastDelivered.ToString());
		thisString.Append(NEW_LINE);
		thisString.Append("isLimited: ");
		thisString.Append(this.isLimited);
		thisString.Append(NEW_LINE);
		thisString.Append("validPrimaryOwnerCount: ");
		thisString.Append(this.validPrimaryOwnerCount);
		thisString.Append(NEW_LINE);
		thisString.Append("allowCollaboration: ");
		thisString.Append(this.allowCollaboration);
		thisString.Append(NEW_LINE);
		thisString.Append("requesterIsOwner: ");
		thisString.Append(this.requesterIsOwner);
		thisString.Append(NEW_LINE);

		return thisString.ToString();
	}
    }
}
