using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
//using System.Text.StringBuilder;

namespace RestClient1
{
    class WorkspaceVOWS
    {

        // Instance variables
        /** The id of the workspace */
        public int packageId { get; set; }
        /** The name of the workspace */
        public string name { get; set; }
        /** The description of the workspace */
        public string description { get; set; }
        /** The tags of the workspace */
        public string tags { get; set; }
        /** The Hide Workspace Activity of the workspace */
        public Boolean hideWorkspaceActivity { get; set; }
        /** The users of the workspace */
        public WorkspaceUsersWS workspaceUsers { get; set; }
        /** The documents of the workspace */
        private List<DocumentVOWS> documentVOs = new List<DocumentVOWS>();

        internal List<DocumentVOWS> DocumentVOs
        {
            get { return documentVOs; }
            set { documentVOs = value; }
        }       
        /** The status of the workspace */
        public string status { get; set; }
        /** The latest version number of the workspace */
        public int latestVersion { get; set; }
        /** The latest published version number of the workspace */
        public int latestPublishedVersion { get; set; }
        /** The user who created the workspace. */
        public int createdBy { get; set; }
        public string createdByDisplayName { get; set; }
        /** The date when the workspace will be deleted automatically. */
        public DateTime autoDelDate { get; set; }
        public string parsedAutoDelDate { get; set; }
        /** The date when the workspace deletion reminder will be send. */
        public DateTime autoDelReminderDate { get; set; }
        public string parsedAutoDelReminderDate { get; set; }
        /** The date when the workspace deletion reminder was sent. */
        public DateTime autoDelReminderSentDate { get; set; }
        public string parsedAutoDelReminderSentDate { get; set; }
        /** The date when the workspace was created. */
        public DateTime dateCreated { get; set; }
        public string parsedDateCreated { get; set; }
        /** The user who last updated the workspace. */
        public int lastUpdatedBy { get; set; }
        public string lastUpdatedByDisplayName { get; set; }
        /** The date when the workspace was last updated. */
        public DateTime dateLastUpdated { get; set; }
        public string parsedDateLastUpdated { get; set; }
        /** The date when the workspace was accessed. */
        public DateTime lastActivityDate { get; set; }
        public string parsedLastActivityDate { get; set; }
        /** The number of valid primary owners of the workspace*/
        public int validPrimaryOwnerCount { get; set; }
        public long size { get; set; }
        public int rootDirectoryId { get; set; }
        private Boolean locked = false;

        public Boolean Locked
        {
            get { return locked; }
            set { locked = value; }
        }
        private int lockedBy { get; set; }

        public Boolean manager { get; set; }
        public Boolean collaborator { get; set; }
        public Boolean viewer { get; set; }

        List<CommentInfoWS> commentInfoList = new List<CommentInfoWS>();

        internal List<CommentInfoWS> CommentInfoList
        {
            get { return commentInfoList; }
            set { commentInfoList = value; }
        }
        public int totalComment { get; set; }
        public int totalActivity { get; set; }
        public int totalTransaction { get; set; }

        public List<WorkspaceNotificationVOWS> workspaceNotifications { get; set; }
        public List<TransactionVOWS> workspaceTransactions { get; set; }

        public GetWorkspaceNotificationsOutputWS gwsno { get; set; }


        public string toString() {
		string NEW_LINE = "\n";

		
        StringBuilder thisString = new StringBuilder();
        thisString.Append("Workspace Name: ");
        thisString.Append(this.name);
        thisString.Append(NEW_LINE);
        thisString.Append("packageId: ");
		thisString.Append(this.packageId);
		thisString.Append(NEW_LINE);
		thisString.Append("status: ");
		thisString.Append((this.status == null) ? "<null>" : this.status.ToString());
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
		thisString.Append("validPrimaryOwnerCount: ");
		thisString.Append(this.validPrimaryOwnerCount);
		thisString.Append(NEW_LINE);

		thisString.Append(NEW_LINE);
		thisString.Append("workspaceUsers: ");
        thisString.Append(NEW_LINE);


        thisString.Append((this.workspaceUsers == null) ? "<null>" : this.workspaceUsers.toString());
		thisString.Append(NEW_LINE);
		
		
        thisString.Append("locked: ");
		thisString.Append(this.locked);
		thisString.Append(NEW_LINE);
		thisString.Append("lockedBy: ");
		thisString.Append(this.lockedBy);
		thisString.Append(NEW_LINE);

		return thisString.ToString();
	}
    }
}
