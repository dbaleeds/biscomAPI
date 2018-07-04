using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1.delivery
{
    class DeliveryVOWS
    {
        // Instance variables
        /** The id of the delivery */
        public int deliveryId { get; set; }
        /** The status of the delivery */
        public string status { get; set; }
        /** The tracking number of the delivery */
        public string trackingNumber { get; set; }
        /** The id of the package the delivery is for */
        public int packageId { get; set; }
        /** The id of the delivery sender */
        public int senderId { get; set; }
        /** The reply to address to use */
        public string replyToAddress { get; set; }
        /** The delivery's name. */
        public string name { get; set; }
        /** The delivery's description. */
        public string description { get; set; }
        /** The message for the delivery. */
        public string message { get; set; }
        /** The secure message for the delivery. */
        public string secureMessage { get; set; }
        /** The DateTime when the delivery is available. */
        public DateTime dateAvailable { get; set; }
        /** The DateTime when the delivery expires. */
        public DateTime dateExpires { get; set; }
        /** Flag to indicate if sign in is required for viewing the delivery. */
        public Boolean requireSignIn { get; set; }
        /** The encoded password for the delivery. */
        public string encodedPassword { get; set; }
        /** The list of emails to send the notification on access message to. */
        private string notificationEmails = "";

        public string NotificationEmails
        {
            get { return notificationEmails; }
            set { notificationEmails = value; }
        }
        /** The user who created the record. */
        public int createdBy { get; set; }
        /** The DateTime when the record was created. */
        public DateTime dateCreated { get; set; }
        /** The user who last upDateTimed the record. */
        public int lastUpdatedBy { get; set; }
        /** The DateTime when the record was last upDateTimed. */
        public DateTime dateLastUpdated { get; set; }
        /** The DateTime of the last activity. */
        public DateTime lastActivityDate { get; set; }
        /** Flag to indicate if the delivery has been read. */
        public Boolean read { get; set; }
        /** The unread reply count. */
        public int unreadReplyCount { get; set; }
        /** Flag to indicate if notification on deletion is turned on / off */
        public Boolean notifyWhenRecipientDeletes { get; set; }
        /**
         * Flag to indicate if notification on document access is turned on / off
         * @deprecated As of release 4.1, use {@link #notifyOnFileDownloadSetting} with values {@link #DO_NOT_NOTIFY},
         *             {@link #NOTIFY_FIRST_TIME} or {@link #NOTIFY_EVERY_TIME}
         */
        /** Flag to indicate if it is a limited delivery */
        public Boolean isLimited { get; set; }
        /** Flag to indicate if the delivery contains only safe html */
        public Boolean safeHtml { get; set; }
        /** Days to remind after sending delivery. */
        public int remindDaysAfterSendingDelivery { get; set; }
        /** Days to remind before delivery expires. */
        public int remindDaysBeforeDeliveryExpires { get; set; }
        /** Requires payment or not */
        public Boolean requiresPayment { get; set; }
        /** Payment amount */
        public double amount { get; set; }
        /** Is express delivery */
        private Boolean isExpress = false;

        public Boolean IsExpress
        {
            get { return isExpress; }
            set { isExpress = value; }
        }
        /** Virus scan status */
        private string scanStatus = "";

        public string ScanStatus
        {
            get { return scanStatus; }
            set { scanStatus = value; }
        }
        /** Notify on file download setting (first access, every access, etc.). */
        private string notifyOnFileDownloadSetting = "";

        public string NotifyOnFileDownloadSetting
        {
            get { return notifyOnFileDownloadSetting; }
            set { notifyOnFileDownloadSetting = value; }
        }
        /** Notify on delivery view setting (first access, every access, etc.). */
        private string notifyOnDeliveryViewSetting = "";

        public string NotifyOnDeliveryViewSetting
        {
            get { return notifyOnDeliveryViewSetting; }
            set { notifyOnDeliveryViewSetting = value; }
        }


        /**
	 * Returns the string representation of the object.
	 * @return The string representation of the object.
	 */
        public String toString1()
        {
            String NEW_LINE = "\n";

            StringBuilder thisString = new StringBuilder();
            thisString.Append("deliveryId: ");
            thisString.Append(this.deliveryId);
            thisString.Append(NEW_LINE);
            thisString.Append("status: ");
            thisString.Append((this.status == null) ? "<null>" : this.status.ToString());
            thisString.Append(NEW_LINE);
            thisString.Append("trackingNumber: ");
            thisString.Append((this.trackingNumber == null) ? "<null>" : this.trackingNumber.ToString());
            thisString.Append(NEW_LINE);
            thisString.Append("packageId: ");
            thisString.Append(this.packageId);
            thisString.Append(NEW_LINE);
            thisString.Append("senderId: ");
            thisString.Append(this.senderId);
            thisString.Append(NEW_LINE);
            thisString.Append("replyToAddress: ");
            thisString.Append((this.replyToAddress == null) ? "<null>" : this.replyToAddress.ToString());
            thisString.Append(NEW_LINE);
            thisString.Append("name: ");
            thisString.Append((this.name == null) ? "<null>" : this.name.ToString());
            thisString.Append(NEW_LINE);
            thisString.Append("description: ");
            thisString.Append((this.description == null) ? "<null>" : this.description.ToString());
            thisString.Append(NEW_LINE);
            thisString.Append("message: ");
            thisString.Append((this.message == null) ? "<null>" : this.message.ToString());
            thisString.Append(NEW_LINE);
            thisString.Append("secureMessage: ");
            thisString.Append((this.secureMessage == null) ? "<null>" : this.secureMessage.ToString());
            thisString.Append(NEW_LINE);
            thisString.Append("dateAvailable: ");
            thisString.Append((this.dateAvailable == null) ? "<null>" : this.dateAvailable.ToString());
            thisString.Append(NEW_LINE);
            thisString.Append("dateExpires: ");
            thisString.Append((this.dateExpires == null) ? "<null>" : this.dateExpires.ToString());
            thisString.Append(NEW_LINE);
            thisString.Append("requireSignIn: ");
            thisString.Append(this.requireSignIn);
            thisString.Append(NEW_LINE);
            thisString.Append("encodedPassword: ");
            thisString.Append(((this.encodedPassword == null) || (this.encodedPassword.Length == 0))
                    ? "<null or empty>" : "<not empty>");
            thisString.Append(NEW_LINE);
            thisString.Append("notificationEmails: ");
            thisString.Append((this.notificationEmails == null) ? "<null>" : this.notificationEmails);
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
            thisString.Append("lastActivityDate: ");
            thisString.Append((this.lastActivityDate == null) ? "<null>" : this.lastActivityDate.ToString());
            thisString.Append(NEW_LINE);
            thisString.Append("read: ");
            thisString.Append(this.read);
            thisString.Append(NEW_LINE);
            thisString.Append("unreadReplyCount: ");
            thisString.Append(this.unreadReplyCount);
            thisString.Append(NEW_LINE);
            thisString.Append("notifyWhenRecipientDeletes: ");
            thisString.Append(this.notifyWhenRecipientDeletes);
            thisString.Append(NEW_LINE);
            thisString.Append("notifyOnFileAccess: ");
            thisString.Append(NEW_LINE);
            thisString.Append("isLimited: ");
            thisString.Append(this.isLimited);
            thisString.Append(NEW_LINE);
            thisString.Append("remindDaysAfterSendingDelivery: ");
            thisString.Append(this.remindDaysAfterSendingDelivery);
            thisString.Append(NEW_LINE);
            thisString.Append("remindDaysBeforeDeliveryExpires: ");
            thisString.Append(this.remindDaysBeforeDeliveryExpires);
            thisString.Append(NEW_LINE);
            thisString.Append("notifyOnDeliveryViewSetting: ");
            thisString.Append(this.notifyOnDeliveryViewSetting);
            thisString.Append(NEW_LINE);
            thisString.Append("notifyOnFileDownloadSetting: ");
            thisString.Append(this.notifyOnFileDownloadSetting);
            thisString.Append(NEW_LINE);

            return thisString.ToString();
        }
    }
}
