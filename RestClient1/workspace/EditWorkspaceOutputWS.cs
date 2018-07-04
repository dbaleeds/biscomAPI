using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace RestClient1
{
    class EditWorkspaceOutputWS
    {
        // Instance variables

        /** The return code for the method call */
        public int returnCode { get; set; }

        
        
        /** The edited workspace */
        public WorkspaceVOWS workspaceVOWS { get; set; }
        /** List of add document output */
        public List<AddDocumentOutputWS> listAddDocumentOutput = new List<AddDocumentOutputWS>();

        internal List<AddDocumentOutputWS> ListAddDocumentOutput
        {
            get { return listAddDocumentOutput; }
            set { listAddDocumentOutput = value; }
        }
        /** List of delete document output */
        public List<DeleteDocumentOutputWS> listDeleteDocumentOutput = new List<DeleteDocumentOutputWS>();

        internal List<DeleteDocumentOutputWS> ListDeleteDocumentOutput
        {
            get { return listDeleteDocumentOutput; }
            set { listDeleteDocumentOutput = value; }
        }
        /** The list of inactive users ({@link UserVO}) specified as owners */
        public List<UserVOWS> inactiveUsers = new List<UserVOWS>();

        internal List<UserVOWS> InactiveUsers
        {
            get { return inactiveUsers; }
            set { inactiveUsers = value; }
        }
        /** The list of invalid email addresses (data type {@link String}) specified as owners */
        public List<String> invalidEmails = new List<String>();

        public List<String> InvalidEmails
        {
            get { return invalidEmails; }
            set { invalidEmails = value; }
        }
        /** The list of users ({@link UserVO}) without Sender role */
        public List<UserVOWS> usersWithoutSenderRole = new List<UserVOWS>();

        internal List<UserVOWS> UsersWithoutSenderRole
        {
            get { return usersWithoutSenderRole; }
            set { usersWithoutSenderRole = value; }
        }
        /** The list of license exceeded users ({@link UserVO}) */
        public List<UserVOWS> usersLicenseExceeded = new List<UserVOWS>();

        internal List<UserVOWS> UsersLicenseExceeded
        {
            get { return usersLicenseExceeded; }
            set { usersLicenseExceeded = value; }
        }
        /** The list of viewers instead collaborators ({@link UserVO}) */
        public List<UserVOWS> viewersInsteadColbrs = new List<UserVOWS>();

        internal List<UserVOWS> ViewersInsteadColbrs
        {
            get { return viewersInsteadColbrs; }
            set { viewersInsteadColbrs = value; }
        }
        /** The list of non user emails (data type {@link String}) specified as managers */
        public List<String> nonUserManagerEmails = new List<String>();

        public List<String> NonUserManagerEmails
        {
            get { return nonUserManagerEmails; }
            set { nonUserManagerEmails = value; }
        }

        
    }
}
