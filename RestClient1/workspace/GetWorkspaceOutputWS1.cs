using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{

    public class CommentInfoList
    {
        public string createdBy { get; set; }
        public string dateCreated { get; set; }
        public string parsedDateCreated { get; set; }
        public string replyMessage { get; set; }
    }

    public class DocumentVO
    {
        public string createdBy { get; set; }
        public string dataFileId { get; set; }
        public string dateCreated { get; set; }
        public string dateLastUpdated { get; set; }
        public string description { get; set; }
        public string directoryId { get; set; }
        public string displayOrder { get; set; }
        public string documentId { get; set; }
        public string encrypted { get; set; }
        public string hashValue { get; set; }
        public string isDownloadable { get; set; }
        public string lastUpdatedBy { get; set; }
        public string name { get; set; }
        public string size { get; set; }
        public string status { get; set; }
    }

    public class WorkspaceNotification
    {
        public string eventDate { get; set; }
        public string eventId { get; set; }
        public string message { get; set; }
        public string notificationType { get; set; }
        public string packageId { get; set; }
        public string parsedEventDate { get; set; }
        public string parsedSentDate { get; set; }
        public string sentDate { get; set; }
        public string status { get; set; }
    }

    public class WorkspaceTransaction
    {
        public string action { get; set; }
        public string category { get; set; }
        public string channelType { get; set; }
        public string deliveryId { get; set; }
        public string documentId { get; set; }
        public string documentName { get; set; }
        public string ipAddress { get; set; }
        public string level { get; set; }
        public string logEntry { get; set; }
        public string newValue { get; set; }
        public string oldValue { get; set; }
        public string packageId { get; set; }
        public string parentTransactionId { get; set; }
        public string parsedTransactionDate { get; set; }
        public string status { get; set; }
        public string target { get; set; }
        public string targetUserId { get; set; }
        public string transactionDate { get; set; }
        public string transactionId { get; set; }
        public string type { get; set; }
        public string userId { get; set; }
        public string version { get; set; }
    }

    public class Collaborators
    {
        public string activationCode { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string allowSMTPInput { get; set; }
        public string authenticationMethod { get; set; }
        public string autoUnlockCount { get; set; }
        public string city { get; set; }
        public string company { get; set; }
        public string country { get; set; }
        public string createdBy { get; set; }
        public string dateCreated { get; set; }
        public string dateLastUpdated { get; set; }
        public string displayName { get; set; }
        public string emailAddress { get; set; }
        public string externalUser { get; set; }
        public string faxNumber { get; set; }
        public string firstName { get; set; }
        public string forcePasswordReset { get; set; }
        public string homePhoneNumber { get; set; }
        public string lastName { get; set; }
        public string lastSignInDate { get; set; }
        public string lastUpdatedBy { get; set; }
        public string manualUnlockRequired { get; set; }
        public string middleName { get; set; }
        public string mobilePhoneNumber { get; set; }
        public string otherPhoneNumber { get; set; }
        public string passwordExpires { get; set; }
        public string quota { get; set; }
        public string quotaUsed { get; set; }
        public string recipientExclusionList { get; set; }
        public string recipientInclusionList { get; set; }
        public string resetPasswordFailureCount { get; set; }
        public string resetPasswordTotalFailureCount { get; set; }
        public string selfRegIPAddress { get; set; }
        public string senderRoleExpired { get; set; }
        public string signInFailureCount { get; set; }
        public string signInLocked { get; set; }
        public string signInTotalFailureCount { get; set; }
        public string signupCompletedDate { get; set; }
        public string state { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public string tosAccepted { get; set; }
        public string userId { get; set; }
        public string username { get; set; }
        public string workPhoneNumber { get; set; }
        public string zipCode { get; set; }
    }

    public class Manager
    {
        public string activationCode { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string allowSMTPInput { get; set; }
        public string authenticationMethod { get; set; }
        public string autoUnlockCount { get; set; }
        public string city { get; set; }
        public string company { get; set; }
        public string country { get; set; }
        public string createdBy { get; set; }
        public string dateCreated { get; set; }
        public string dateLastUpdated { get; set; }
        public string displayName { get; set; }
        public string emailAddress { get; set; }
        public string externalUser { get; set; }
        public string faxNumber { get; set; }
        public string firstName { get; set; }
        public string forcePasswordReset { get; set; }
        public string homePhoneNumber { get; set; }
        public string lastName { get; set; }
        public string lastSignInDate { get; set; }
        public string lastUpdatedBy { get; set; }
        public string manualUnlockRequired { get; set; }
        public string middleName { get; set; }
        public string mobilePhoneNumber { get; set; }
        public string otherPhoneNumber { get; set; }
        public string passwordExpires { get; set; }
        public string quota { get; set; }
        public string quotaUsed { get; set; }
        public string recipientExclusionList { get; set; }
        public string recipientInclusionList { get; set; }
        public string resetPasswordFailureCount { get; set; }
        public string resetPasswordTotalFailureCount { get; set; }
        public string selfRegIPAddress { get; set; }
        public string senderRoleExpired { get; set; }
        public string signInFailureCount { get; set; }
        public string signInLocked { get; set; }
        public string signInTotalFailureCount { get; set; }
        public string signupCompletedDate { get; set; }
        public string state { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public string tosAccepted { get; set; }
        public string userId { get; set; }
        public string username { get; set; }
        public string workPhoneNumber { get; set; }
        public string zipCode { get; set; }
    }

    public class Viewers
    {
        public string activationCode { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string allowSMTPInput { get; set; }
        public string authenticationMethod { get; set; }
        public string autoUnlockCount { get; set; }
        public string city { get; set; }
        public string company { get; set; }
        public string country { get; set; }
        public string createdBy { get; set; }
        public string dateCreated { get; set; }
        public string dateLastUpdated { get; set; }
        public string displayName { get; set; }
        public string emailAddress { get; set; }
        public string externalUser { get; set; }
        public string faxNumber { get; set; }
        public string firstName { get; set; }
        public string forcePasswordReset { get; set; }
        public string homePhoneNumber { get; set; }
        public string lastName { get; set; }
        public string lastSignInDate { get; set; }
        public string lastUpdatedBy { get; set; }
        public string manualUnlockRequired { get; set; }
        public string middleName { get; set; }
        public string mobilePhoneNumber { get; set; }
        public string otherPhoneNumber { get; set; }
        public string passwordExpires { get; set; }
        public string quota { get; set; }
        public string quotaUsed { get; set; }
        public string recipientExclusionList { get; set; }
        public string recipientInclusionList { get; set; }
        public string resetPasswordFailureCount { get; set; }
        public string resetPasswordTotalFailureCount { get; set; }
        public string selfRegIPAddress { get; set; }
        public string senderRoleExpired { get; set; }
        public string signInFailureCount { get; set; }
        public string signInLocked { get; set; }
        public string signInTotalFailureCount { get; set; }
        public string signupCompletedDate { get; set; }
        public string state { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public string tosAccepted { get; set; }
        public string userId { get; set; }
        public string username { get; set; }
        public string workPhoneNumber { get; set; }
        public string zipCode { get; set; }
    }

    public class WorkspaceUsers
    {
        public List<Collaborators> collaborators { get; set; }
        public List<Manager> managers { get; set; }
        public List<Viewers> viewers { get; set; }
    }

    public class WorkspaceVOWS1
    {
        public string collaborator { get; set; }
        public List<CommentInfoList> commentInfoList { get; set; }
        public string createdBy { get; set; }
        public string createdByDisplayName { get; set; }
        public string dateCreated { get; set; }
        public string dateLastUpdated { get; set; }
        public string description { get; set; }
        public List<DocumentVO> documentVOs { get; set; }
        public string hideWorkspaceActivity { get; set; }
        public string lastActivityDate { get; set; }
        public string lastUpdatedBy { get; set; }
        public string lastUpdatedByDisplayName { get; set; }
        public string latestPublishedVersion { get; set; }
        public string latestVersion { get; set; }
        public string locked { get; set; }
        public string lockedBy { get; set; }
        public string manager { get; set; }
        public string name { get; set; }
        public string packageId { get; set; }
        public string parsedAutoDelDate { get; set; }
        public string parsedAutoDelReminderDate { get; set; }
        public string parsedAutoDelReminderSentDate { get; set; }
        public string parsedDateCreated { get; set; }
        public string parsedDateLastUpdated { get; set; }
        public string parsedLastActivityDate { get; set; }
        public string rootDirectoryId { get; set; }
        public string size { get; set; }
        public string status { get; set; }
        public string tags { get; set; }
        public string totalActivity { get; set; }
        public string totalComment { get; set; }
        public string totalTransaction { get; set; }
        public string validPrimaryOwnerCount { get; set; }
        public string viewer { get; set; }
        public List<WorkspaceNotification> workspaceNotifications { get; set; }
        public List<WorkspaceTransaction> workspaceTransactions { get; set; }
        public WorkspaceUsers workspaceUsers { get; set; }
    }

    public class GetWorkspaceOutputWS1
    {
        public int returnCode { get; set; }
        public WorkspaceVOWS1 workspaceVOWS { get; set; }

        public string toString()
        {
            string NEW_LINE = "\n";
            StringBuilder thisString = new StringBuilder();
            thisString.Append("returnCode: ");
            thisString.Append(this.returnCode);
            thisString.Append(NEW_LINE);
            thisString.Append("Managers: ");
            thisString.Append(NEW_LINE);
            int lengthManagers = this.workspaceVOWS.workspaceUsers.managers.Count;
            for (int i = 0; i < lengthManagers; i++)
            {
                thisString.Append((this.workspaceVOWS.workspaceUsers.managers != null) ? this.workspaceVOWS.workspaceUsers.managers[i].emailAddress.ToString(): "<null>");
                thisString.Append(NEW_LINE);
            }

            thisString.Append(NEW_LINE);
            int lengthCollaborators = this.workspaceVOWS.workspaceUsers.collaborators.Count;
            for (int i = 0; i < lengthCollaborators; i++)
            {
                thisString.Append((this.workspaceVOWS.workspaceUsers.collaborators != null) ? this.workspaceVOWS.workspaceUsers.collaborators[i].emailAddress.ToString() : "<null>");
                thisString.Append(NEW_LINE);
            }
            thisString.Append(NEW_LINE);

            int lengthViewers = this.workspaceVOWS.workspaceUsers.viewers.Count;
            for (int i = 0; i < lengthViewers; i++)
            {
                thisString.Append((this.workspaceVOWS.workspaceUsers.viewers != null) ? this.workspaceVOWS.workspaceUsers.viewers[i].emailAddress.ToString() : "<null>");
                thisString.Append(NEW_LINE);
            }
            
            return thisString.ToString();
        }
    }
    
}
