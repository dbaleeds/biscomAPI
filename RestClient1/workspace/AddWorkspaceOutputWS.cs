using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class AddWorkspaceOutputWS
    {     

        // Instance variables

        /** The return code for the method call */
        public int returnCode { get; set; }
        /** The newly created workspace */
        public WorkspaceVOWS workspaceVO { get; set; }
        /** List of add document output */
        public List<AddDocumentOutputWS> listAddDocumentOutput = new List<AddDocumentOutputWS>();

        internal List<AddDocumentOutputWS> ListAddDocumentOutput
        {
            get { return listAddDocumentOutput; }
            set { listAddDocumentOutput = value; }
        }
        /** The list of inactive users ({@link UserVO}) specified as owners */
        public List<UserVOWS> inactiveUsers { get; set; }
        /** The list of invalid email addresses (data type {@link String}) specified as owners */
        public List<String> invalidEmails { get; set; }
        /** The list of users ({@link UserVO}) without Sender role */
        public List<UserVOWS> usersWithoutSenderRole { get; set; }
        /** The list of license exceeded users ({@link UserVO}) */
        public List<UserVOWS> usersLicenseExceeded { get; set; }
        /** The list of viewers instead collaborators ({@link UserVO}) */
        public List<UserVOWS> viewersInsteadColbrs = new List<UserVOWS>();

        public List<UserVOWS> ViewersInsteadColbrs
        {
            get { return viewersInsteadColbrs; }
            set { viewersInsteadColbrs = value; }
        }
        /** The list of non user emails (data type {@link String}) specified as managers */
        public List<String> nonUserManagerEmails { get; set; }

    }
}
