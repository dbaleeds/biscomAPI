using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class UserVOWS
    {
        // Instance variables
        /** The user's user id. */
        public int userId { get; set; }
        /** The user's status. */
        public string status { get; set; }
        /** The user's username. */
        public string username { get; set; }
        /** The internal name of the group */
        public string internalName { get; set; }
        /** The user's authentication method. */
        public string authenticationMethod { get; set; }
        /** The user's email address. */
        public string emailAddress { get; set; }
        /** The user's first name. */
        public string firstName { get; set; }
        /** The user's middle name. */
        public string middleName { get; set; }
        /** The user's last name. */
        public string lastName { get; set; }
        /** The user's display name. */
        public string displayName { get; set; }
        /** The user who created the record. */
        public int createdBy { get; set; }
        /** The date when the record was created. */
        public DateTime dateCreated { get; set; }
        /** The user who last updated the record. */
        public int lastUpdatedBy { get; set; }
        /** The date when the record was last updated. */
        public DateTime dateLastUpdated { get; set; }
        /** The date when signup was completed. */
        public DateTime signupCompletedDate { get; set; }
        /** The date when the user last signed in. */
        public DateTime lastSignInDate { get; set; }
        /** The user's title. */
        public string title { get; set; }
        /** The user's company. */
        public string company { get; set; }
        /** The first line of the user's address. */
        public string addressLine1 { get; set; }
        /** The second line of the user's address. */
        public string addressLine2 { get; set; }
        /** The user's city. */
        public string city { get; set; }
        /** The user's state. */
        public string state { get; set; }
        /** The user's zip code. */
        public string zipCode { get; set; }
        /** The user's country. */
        public string country { get; set; }
        /** The user's work phone number. */
        public string workPhoneNumber { get; set; }
        /** The user's home phone number. */
        public string homePhoneNumber { get; set; }
        /** The user's mobile phone number. */
        public string mobilePhoneNumber { get; set; }
        /** The user's other phone number. */
        public string otherPhoneNumber { get; set; }
        /** The user's fax number. */
        public string faxNumber { get; set; }
        /** The secret questions for reseting user password */
        public List<string> secretQuestions { get; set; }
        /** Flag to indicate if sign in is locked for the user */
        public Boolean signInLocked { get; set; }
        /** The number of times sign in attempt has failed */
        public int signInFailureCount { get; set; }
        /** The total number of times sign in attempt has failed */
        public int signInTotalFailureCount { get; set; }
        /** The latest date when sign in attempt failed */
        public DateTime signInLastFailureDate { get; set; }
        /** The number of times reset password attempt has failed */
        public int resetPasswordFailureCount { get; set; }
        /** The total number of times reset password attempt has failed */
        public int resetPasswordTotalFailureCount { get; set; }
        /** The latest date when reset password attempt failed */
        public DateTime resetPasswordLastFailureDate { get; set; }
        /** The list of recipients the user is allowed to send to */
        public string recipientInclusionList { get; set; }
        /** The list of recipients the user is not allowed to send to */
        public string recipientExclusionList { get; set; }
        /** Flag to indicate if SMTP input is allowed for this user */
        public Boolean allowSMTPInput { get; set; }

        /** The latest date when the password was reset */
        public DateTime lastPasswordResetDate { get; set; }
        /** Flag to indicate whether the password never expires or not */
        public Boolean passwordExpires { get; set; }
        /** Flag to indicate whether the user will be forced to reset the password on first log in */
        public Boolean forcePasswordReset { get; set; }
        /** Flag to indicate whether the user external or not */
        public Boolean externalUser { get; set; }
        /** Last signed in user name */
        public string lastSignInUserName { get; set; }
        /** Last signed in domain name of user*/
        public string lastSignInDomain { get; set; }
        /** Activation code for the new user*/
        public string activationCode { get; set; }
        /** Expiry date for a user*/
        public DateTime expiryDate { get; set; }
        /** Expired on date for a user*/
        public DateTime expiredOn { get; set; }
        /** Last activity date for a user*/
        public DateTime lastActivityDate { get; set; }
        /** Quota limit for a user*/
        public long quota { get; set; }
        /** Quota used by a user*/
        public long quotaUsed { get; set; }
        /** Terms of Service accepted by a user*/
        public Boolean tosAccepted { get; set; }
        /** Auto unlock count for a user */
        public long autoUnlockCount { get; set; }
        /** Is manual unlocking required for a user or not*/
        public Boolean manualUnlockRequired { get; set; }
        /** The IP address of the self registering user*/
        public string selfRegIPAddress { get; set; }
        /** The flag that determines user previously lost sender role for inactivity */
        public Boolean senderRoleExpired { get; set; }

        /**
	 * Returns the string representation of the object.
	 * 
	 * @return The string representation of the object.
	 */
        public string toString() {
        string NEW_LINE = "\n";

        StringBuilder thisString = new StringBuilder();
        thisString.Append("userId: ");
        thisString.Append(this.userId);
        thisString.Append(NEW_LINE);
        thisString.Append("status: ");
        thisString.Append((this.status != null) ? this.status : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("username: ");
        thisString.Append((this.username != null) ? this.username : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("authenticationMethod: ");
        thisString.Append((this.authenticationMethod != null) ? this.authenticationMethod : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("emailAddress: ");
        thisString.Append((this.emailAddress != null) ? this.emailAddress : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("firstName: ");
        thisString.Append((this.firstName != null) ? this.firstName : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("middleName: ");
        thisString.Append((this.middleName != null) ? this.middleName : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("lastName: ");
        thisString.Append((this.lastName != null) ? this.lastName : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("displayName: ");
        thisString.Append((this.displayName != null) ? this.displayName : "<null>");
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
        thisString.Append("signupCompletedDate: ");
        thisString.Append((this.signupCompletedDate != null) ? this.signupCompletedDate.ToString() : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("lastSignInDate: ");
        thisString.Append((this.lastSignInDate != null) ? this.lastSignInDate.ToString() : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("title: ");
        thisString.Append((this.title != null) ? this.title : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("company: ");
        thisString.Append((this.company != null) ? this.company : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("addressLine1: ");
        thisString.Append((this.addressLine1 != null) ? this.addressLine1 : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("addressLine2: ");
        thisString.Append((this.addressLine2 != null) ? this.addressLine2 : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("city: ");
        thisString.Append((this.city != null) ? this.city : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("state: ");
        thisString.Append((this.state != null) ? this.state : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("zipCode: ");
        thisString.Append((this.zipCode != null) ? this.zipCode : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("country: ");
        thisString.Append((this.country != null) ? this.country : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("workPhoneNumber: ");
        thisString.Append((this.workPhoneNumber != null) ? this.workPhoneNumber : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("homePhoneNumber: ");
        thisString.Append((this.homePhoneNumber != null) ? this.homePhoneNumber : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("mobilePhoneNumber: ");
        thisString.Append((this.mobilePhoneNumber != null) ? this.mobilePhoneNumber : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("otherPhoneNumber: ");
        thisString.Append((this.otherPhoneNumber != null) ? this.otherPhoneNumber : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("faxNumber: ");
        thisString.Append((this.faxNumber != null) ? this.faxNumber : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("secretQuestions: ");
        thisString.Append((this.secretQuestions != null) ? this.secretQuestions.ToString() : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("signInLocked: ");
        thisString.Append(this.signInLocked);
        thisString.Append(NEW_LINE);
        thisString.Append("signInFailureCount: ");
        thisString.Append(this.signInFailureCount);
        thisString.Append(NEW_LINE);
        thisString.Append("signInTotalFailureCount: ");
        thisString.Append(this.signInTotalFailureCount);
        thisString.Append(NEW_LINE);
        thisString.Append("signInLastFailureDate: ");
        thisString.Append((this.signInLastFailureDate != null) ? this.signInLastFailureDate.ToString() : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("resetPasswordFailureCount: ");
        thisString.Append(this.resetPasswordFailureCount);
        thisString.Append(NEW_LINE);
        thisString.Append("resetPasswordTotalFailureCount: ");
        thisString.Append(this.resetPasswordTotalFailureCount);
        thisString.Append(NEW_LINE);
        thisString.Append("resetPasswordLastFailureDate: ");
        thisString.Append((this.resetPasswordLastFailureDate != null) ? this.resetPasswordLastFailureDate.ToString() : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("recipientInclusionList: ");
        thisString.Append((this.recipientInclusionList != null) ? this.recipientInclusionList : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("recipientExclusionList: ");
        thisString.Append((this.recipientExclusionList != null) ? this.recipientExclusionList : "<null>");
        thisString.Append(NEW_LINE);
        thisString.Append("allowSMTPInput: ");
        thisString.Append(this.allowSMTPInput);
        thisString.Append(NEW_LINE);

        thisString.Append("lastPasswordResetDate: ");
        thisString.Append((this.lastPasswordResetDate == null) ? "<null>" : this.lastPasswordResetDate.ToString());
        thisString.Append(NEW_LINE);
        thisString.Append("passwordExpires: ");
        thisString.Append(this.passwordExpires);
        thisString.Append(NEW_LINE);
        thisString.Append("forcePasswordReset: ");
        thisString.Append(this.forcePasswordReset);
        thisString.Append(NEW_LINE);
        thisString.Append("externalUser: ");
        thisString.Append(this.externalUser);
        thisString.Append(NEW_LINE);   
        thisString.Append("lastSignInUserName: ");
        thisString.Append((this.lastSignInUserName == null) ? "<null>" : this.lastSignInUserName.ToString());
        thisString.Append(NEW_LINE);
        thisString.Append("lastSignInDomain: ");
        thisString.Append((this.lastSignInDomain == null) ? "<null>" : this.lastSignInDomain.ToString());
        thisString.Append(NEW_LINE);
        thisString.Append("activationCode: ");
        thisString.Append((this.activationCode == null) ? "<null>" : this.activationCode.ToString());
        thisString.Append(NEW_LINE);
        thisString.Append("expiryDate: ");
        thisString.Append((this.expiryDate == null) ? "<null>" : this.expiryDate.ToString());
        thisString.Append(NEW_LINE);
        thisString.Append("expiredOn: ");
        thisString.Append((this.expiredOn == null) ? "<null>" : this.expiredOn.ToString());
        thisString.Append(NEW_LINE);
        thisString.Append("lastActivityDate: ");
        thisString.Append((this.lastActivityDate == null) ? "<null>" : this.lastActivityDate.ToString());
        thisString.Append(NEW_LINE);
        thisString.Append("autoUnlockCount: ");
        thisString.Append(this.autoUnlockCount);
        thisString.Append(NEW_LINE);
        thisString.Append("manualUnlockRequired: ");
        thisString.Append(this.manualUnlockRequired);
        thisString.Append(NEW_LINE);
        thisString.Append("selfRegIPAddress: ");
        thisString.Append(this.selfRegIPAddress);
        thisString.Append(NEW_LINE);
        thisString.Append("senderRoleExpired: ");
        thisString.Append(this.senderRoleExpired);
        thisString.Append(NEW_LINE);
        
        return thisString.ToString();
    }

       

    }
}
