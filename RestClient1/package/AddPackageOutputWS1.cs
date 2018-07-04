using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1.package
{
    class AddPackageOutputWS1
    {
        public ExtPackageVO extPackageVO { get; set; }
        public NonSenders nonSenders { get; set; }
        public int returnCode { get; set; }
    }

    public class ExtPackageVO
    {
        public string allowCollaboration { get; set; }
        public string createdBy { get; set; }
        public string dateCreated { get; set; }
        public string dateLastUpdated { get; set; }
        public string folderId { get; set; }
        public string lastActivityDate { get; set; }
        public string lastUpdatedBy { get; set; }
        public string latestPublishedVersion { get; set; }
        public string latestVersion { get; set; }
        public string limited { get; set; }
        public string packageId { get; set; }
        public string requesterIsOwner { get; set; }
        public string status { get; set; }
        public string validPrimaryOwnerCount { get; set; }
    }

    public class NonSenders
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
}
