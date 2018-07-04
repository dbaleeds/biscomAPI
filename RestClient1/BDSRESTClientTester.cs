using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography;
using RestClient1.secureReply;
using RestClient1.document;
using RestClient1.dataFile;

namespace RestClient1
{
    /// <summary>
    /// This class demonstrates the sample functionalities of some web services of BDSRESTWebService 
    /// </summary>
    class BDSRESTClientTester
    {
        public static String url = Resources.URL;
        private static RestClient client;


        // Creates and return a RestClient instance
        public static RestClient getClient()
        {
            if (client == null)
            {
                client = new RestClient(url);
            }
            return client;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="BDSRESTClientTester"/> class.
        /// </summary>
        public BDSRESTClientTester()
        {
            String SessionId = signIn();           


            /*---------- Workspace related APIs ---------- */
            //addWorkspace(SessionId);
            //addDocumentsInWorkspace(SessionId);
            //deleteWorkspace(SessionId);
            //editWorkspaceInfo(SessionId);
            //editWorkspaceUsers(SessionId);
            //addWorkspaceComment(SessionId);
            //lockWorkspace(SessionId);
            //addDirectory(SessionId);            
            //getWorkspaceComment(SessionId);
            //getWorkspaceActivities(SessionId);
            //getWorkspaceTransactions(SessionId);            
            //getUserWorkspaces(SessionId);
            //saveWorkspaceUserSettings(SessionId);
            //getSoleManagerWorkspaces(SessionId);
            //getWorkspace(SessionId);
            //getWorkspaceUserSettings(SessionId);


            /*---------- User Administration related APIs ---------- */
            //addUser(SessionId);
            //deleteUser(SessionId);
            //updateUser(SessionId);


            /*---------- Package related APIs ---------- */
            //addPackage(SessionId);
            //addPackageDocuments(SessionId);
            //deletePackage(SessionId);
            //editPackage(SessionId);
            //getPackage(SessionId);
            //getPackageDeliveries(SessionId);
            //getPackageOwners(SessionId);
            //getPackageSenders(SessionId);
            //getUserPackages(SessionId);



            /*---------- Delivery related APIs ---------- */
            //addExpressDelivery(SessionId);
            //addDelivery(SessionId);
            //deleteDelivery(SessionId);
            //editDelivery(SessionId);
            //getDelivery(SessionId);
            //getUserDeliveries(SessionId);
            //deleteRecipientDelivery(SessionId);
            //getDeliveryTransactions(SessionId);
            //getDeliveryDocuments(SessionId);

            /*---------- Data file related APIs ---------- */
            //uploadFileByChunk(SessionId, @"C:\file.mp4");
            //addExpressDeliveryWithDataFileId(SessionId);
            //addExpressDeliveryWithDataFileIdExt(SessionId);
            //compareHash();
            //downloadFileByChunk(SessionId);

            /*---------- Secure reply related APIs ---------- */
            //getReply(SessionId);
            //getReplies(SessionId);
            //addReply(SessionId);
            //getReplyDocuments(SessionId);


            /*---------- Document related APIs ---------- */
            //getDocument(SessionId);
            //getDocuments(SessionId);
            //editDocuement(SessionId);
            //deleteDocuement(SessionId);

            /*---------- Init property related APIs -------*/
            //getInitProperty(SessionId);

            signOut(SessionId);

            Console.ReadKey();

        }



        /*----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Signs in.
        /// </summary>
        /// <returns></returns>
        private String signIn()
        {
            var request = new RestRequest("signin", Method.POST);
            request.AddParameter("username", Resources.USER_NAME); // adds to POST or URL querystring based on Method
            request.AddParameter("password", Resources.PASSWORD);

            // execute the request
            try
            {
                RestResponse response = (RestResponse)BDSRESTClientTester.getClient().Execute(request);
                SignInOutputWS signInOutputWs = JsonConvert.DeserializeObject<SignInOutputWS>(response.Content);
                String SessionId = signInOutputWs.SessionId;
                int returnCode = signInOutputWs.ReturnCode;

                //Message according to the return code. Only most frequent cases are shown
                switch (returnCode)
                {
                    case 0: Console.Out.WriteLine("Logged in successfully."); break;
                    case -1: Console.Out.WriteLine("Invalid username specified."); break;
                    case -2: Console.Out.WriteLine("Invalid password specified."); break;
                    case -3: Console.Out.WriteLine("Too many invalid sign in attempts."); break;
                    case -99: Console.Out.WriteLine("System error occurred."); break;
                    default: Console.Out.WriteLine("Please provide a valid username and password."); break;
                }

                Console.Out.WriteLine("Session ID: " + SessionId + "\n");
                return SessionId;

            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception occured in signIn() method! :" + e.Message);
                return null;
            }
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Signs out.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        public static void signOut(String sessionId)
        {
            RestRequest request = new RestRequest("signout", Method.POST);
            request.AddParameter("sessionId", sessionId);

            // execute the request
            try
            {
                RestResponse response = (RestResponse)BDSRESTClientTester.getClient().Execute(request);
                SignOutOutputWS signInOutputWs = JsonConvert.DeserializeObject<SignOutOutputWS>(response.Content);
                int returnCode = signInOutputWs.returnCode;

                //Message according to the return code. Only most frequent cases are shown
                switch (returnCode)
                {
                    case 0: Console.Out.WriteLine("\nLogged out successfully.\n"); break;
                    default: Console.Out.WriteLine("\nLogged out unseccessfull\n"); break;
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception occured in signOut() method! :" + e.Message);
            }


        }


        /*----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Adds the express delivery.
        /// </summary>
        /// <param name="SessionId">The session identifier.</param>
        private void addExpressDelivery(String SessionId)
        {
            String deliveryName = "API Test Delivery from Client";
            String secureMessage = "";
            String message = "";
            String password = "";

            //Delegate delivery
            //String deliveryTo = "from: raine1@nilavodev.com, raine2@nilavodev.com";

            //Normal delivery
            //String deliveryTo = "raine2@nilavodev.com";
            String deliveryTo = "d.batty@leeds.ac.uk";
            String deliveryCc = "";
            String deliveryBcc = "";
            String sendNotificationEmail = "true";
            String requireSignIn = "false";
            String notifyWhenRecipientDeletes = "true";
            //String notificationEmailList = "raine1@nilavodev.com";
            String notificationEmailList = "d.batty2@leeds.ac.uk";
            String notifyOnDeliveryViewSetting = "FT";
            String notifyOnFileDownloadSetting = "FT";
            String deliveryDateExpires = "10/01/2016 01:01 AM";
            String autoPackageDeletionDate = "10/03/2017 01:01 AM";
            String autoPackageDelReminderDate = "10/02/2017 01:01 AM";
            String allowCollaboration = "true";

            //Provide the file name and path
            MyFile myFile1 = new MyFile("file1.jpg", "C:\\Users\\meddbat\\Desktop\\file1.jpg");
            MyFile myFile2 = new MyFile("file2.jpg", "C:\\Users\\meddbat\\Desktop\\file2.jpg");

            List<MyFile> fileList = new List<MyFile>();

            //Add files to fileList
            fileList.Add(myFile1);
            fileList.Add(myFile2);

            Console.Out.WriteLine("Files to attach: " + fileList.Count);

            Delivery delivery = new Delivery(SessionId);
            delivery.addExpressDelivery(deliveryTo, deliveryCc, deliveryBcc, deliveryName, requireSignIn, secureMessage, message, sendNotificationEmail, notifyWhenRecipientDeletes, notifyOnDeliveryViewSetting,
                notifyOnFileDownloadSetting, autoPackageDeletionDate, autoPackageDelReminderDate, fileList, allowCollaboration, deliveryDateExpires, password, notificationEmailList);
        }

        /*----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Adds the express delivery with data file identifier.
        /// </summary>
        /// <param name="SessionId">The session identifier.</param>
        private void addExpressDeliveryWithDataFileId(String SessionId)
        {
            String deliveryName = "Test Express delivery with data file id";
            String secureMessage = "secure message";
            String deliveryMessage = "Notification message";
            String deliveryPassword1 = "";
            String deliveryTo = "raine2@nilavodev.com";
            String deliveryCc = "";
            String deliveryBcc = "";
            String sendNotificationEmailStr = "true";
            String requireSignInStr = "true";
            String notifyWhenRecipientDeletesStr = "true";
            String notificationEmailList = "raine1@nilavodev.com, raine3@nilavodev.com";
            String notifyOnDeliveryViewSetting = "FT";
            String notifyOnFileDownloadSetting = "FT";            
            String documentNameList = "";
            String dataFileIdList = "";
            String deliveryDateExpiresStr = "10/01/2017 01:01 AM";
            String packageAutoDeleteDateStr = "10/03/2017 01:01 AM";
            String packageAutoDelReminderDateStr = "10/02/2017 01:01 AM";
            String allowCollaboration = "true";

            //Provide the file name and path
            MyFile myFile1 = new MyFile("file1.jpg", "G:\\file1.jpg");
            MyFile myFile2 = new MyFile("file2.jpg", "G:\\file2.jpg");

            List<MyFile> fileList = new List<MyFile>();

            //Add files to fileList
            fileList.Add(myFile1);
            fileList.Add(myFile2);


            foreach (MyFile myFile in fileList)
            {
                CompleteDataFileUploadOutputWS cdfu = uploadFileByChunk(SessionId, myFile.filePath);
                if (cdfu != null && cdfu.returnCode == 0)
                {
                    dataFileIdList = dataFileIdList + ":" + cdfu.DataFileVO.dataFileId;
                    documentNameList = documentNameList + ":" + myFile.fileName;
                }                
            }

            Delivery delivery = new Delivery(SessionId);
            delivery.addExpressDeliveryWithDataFileId(deliveryTo, deliveryCc, deliveryBcc, deliveryName, requireSignInStr, dataFileIdList,
                documentNameList, secureMessage, deliveryMessage, sendNotificationEmailStr, notifyWhenRecipientDeletesStr, notifyOnDeliveryViewSetting, notifyOnFileDownloadSetting, packageAutoDeleteDateStr,
                packageAutoDelReminderDateStr, deliveryDateExpiresStr, deliveryPassword1, notificationEmailList, allowCollaboration);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Adds the express delivery with data file identifier. It additionally returns the delivery information.
        /// </summary>
        /// <param name="SessionId">The session identifier.</param>
        private void addExpressDeliveryWithDataFileIdExt(String SessionId)
        {
            String deliveryName = "Test Express delivery with data file id Ext";
            String secureMessage = "secure message";
            String deliveryMessage = "Notification message";
            String deliveryPassword1 = "";
            String deliveryTo = "raine2@nilavodev.com, raine5@nilavodev.com";
            String deliveryCc = "";
            String deliveryBcc = "";
            String sendNotificationEmailStr = "true";
            String requireSignInStr = "true";
            String notifyWhenRecipientDeletesStr = "true";
            String notificationEmailList = "raine1@nilavodev.com, raine3@nilavodev.com, raine6@nilavodev.com";
            String notifyOnDeliveryViewSetting = "FT";
            String notifyOnFileDownloadSetting = "FT";
            String documentNameList = "";
            String dataFileIdList = "";
            String deliveryDateExpiresStr = "10/01/2015 01:01 AM";
            String packageAutoDeleteDateStr = "10/03/2015 01:01 AM";
            String packageAutoDelReminderDateStr = "10/02/2015 01:01 AM";
            String allowCollaboration = "true";
            String returnDeliveryLinks = "true";

            //Provide the file name and path
            MyFile myFile1 = new MyFile("file1.jpg", "G:\\file1.jpg");
            MyFile myFile2 = new MyFile("file2.jpg", "G:\\file2.jpg");

            List<MyFile> fileList = new List<MyFile>();

            //Add files to fileList
            fileList.Add(myFile1);
            fileList.Add(myFile2);


            foreach (MyFile myFile in fileList)
            {
                CompleteDataFileUploadOutputWS cdfu = uploadFileByChunk(SessionId, myFile.filePath);
                if (cdfu != null && cdfu.returnCode == 0)
                {
                    dataFileIdList = dataFileIdList + ":" + cdfu.DataFileVO.dataFileId;
                    documentNameList = documentNameList + ":" + myFile.fileName;
                }
            }

            Delivery delivery = new Delivery(SessionId);
            delivery.addExpressDeliveryWithDataFileIdExt(deliveryTo, deliveryCc, deliveryBcc, deliveryName, requireSignInStr, dataFileIdList,
                documentNameList, secureMessage, deliveryMessage, sendNotificationEmailStr, notifyWhenRecipientDeletesStr, notifyOnDeliveryViewSetting, notifyOnFileDownloadSetting, packageAutoDeleteDateStr,
                packageAutoDelReminderDateStr, deliveryDateExpiresStr, deliveryPassword1, notificationEmailList, allowCollaboration, returnDeliveryLinks);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Adds the workspace.
        /// </summary>
        /// <param name="SessionId">The session identifier.</param>
        private void addWorkspace(string SessionId)
        {

            string name = "Test Workspace from BDSRESTClient";
            string description = "secure message";
            string tags = "secure message";
            string hideActivity = "false";
            string autoDelDate = "08 Jun 2016: 12:06 PM";
            string autoDelReminderDate = "02 Jun 2016: 12:06 PM";
            string managers = "raine2@nilavodev.com";
            string collaborators = "";
            string viewers = "";

            MyFile myFile1 = new MyFile("water.jpg", "c:\\water.jpg");
            MyFile myFile2 = new MyFile("water1.jpg", "c:\\water1.jpg");
            MyFile myFile3 = new MyFile("water2.jpg", "c:\\water2.jpg");

            List<MyFile> fileList = new List<MyFile>();

            fileList.Add(myFile1);
            //fileList.Add(myFile2);
            //fileList.Add(myFile3);

            Workspace workspace = new Workspace(SessionId);

            workspace.addWorkspace(name, description, tags, hideActivity, autoDelDate, autoDelReminderDate, managers,
            collaborators, viewers, fileList);


        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Adds the documents in workspace.
        /// </summary>
        /// <param name="SessionId">The session identifier.</param>
        private void addDocumentsInWorkspace(string SessionId)
        {
            // ID of the workspace where to add the documents.
            string workspaceId = "2781";
            //ID of the sub-folder where to add the documents. Keep it empty to add documents in the root directory of the workspace.
            string parentDirectoryId = "";
            //Filename and path
            MyFile myFile1 = new MyFile("water3.jpg", "c:\\water3.jpg");
            MyFile myFile2 = new MyFile("water4.jpg", "c:\\water4.jpg");
            MyFile myFile3 = new MyFile("water5.jpg", "c:\\water5.jpg");

            List<MyFile> fileList = new List<MyFile>();
            fileList.Add(myFile1);
            fileList.Add(myFile2);
            fileList.Add(myFile3);

            Workspace workspace = new Workspace(SessionId);
            workspace.addDocumentsInWorkspace(workspaceId, parentDirectoryId, fileList);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Deletes the workspace.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void deleteWorkspace(string sessionId)
        {
            //ID of the workspace to delete
            string workspaceId = "2781";

            Workspace workspace = new Workspace(sessionId);
            workspace.deleteWorkspace(workspaceId);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Edits the workspace information.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void editWorkspaceInfo(string sessionId)
        {

            string workspaceId = "2782";
            string workspaceName = "New Workspace Name1";
            string description = "New description";
            string label = "New label";

            Workspace workspace = new Workspace(sessionId);
            workspace.editWorkspaceInfo(workspaceId, workspaceName, description, label);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Edits the workspace users.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void editWorkspaceUsers(string sessionId)
        {

            string workspaceId = "1181";
            string managers = "raine1@nilavodev.com; raine2@nilavodev.com; raine3@nilavodev.com";
            string collaborators = "";
            string viewers = "";

            Workspace workspace = new Workspace(sessionId);
            workspace.editWorkspaceUsers(workspaceId, managers, collaborators, viewers);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Adds the workspace comment.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void addWorkspaceComment(string sessionId)
        {
            string workspaceId = "2901";
            string topicId = "1";
            string commentMessage = "This is a test comment";

            Workspace workspace = new Workspace(sessionId);
            workspace.addWorkspaceComment(workspaceId, topicId, commentMessage);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Locks the workspace.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void lockWorkspace(string sessionId)
        {
            string workspaceId = "3001";
            Boolean Lock = false;
            Workspace workspace = new Workspace(sessionId);
            workspace.lockWorkspace(workspaceId, Lock);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Adds the directory.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void addDirectory(string sessionId)
        {
            //name of the new directory
            string name = "New Folder";
            string description = "";
            //The parent directory ID of the new directory
            string parentDirectoryIdStr = "2901";
            string isWorkspace = "true";
            Workspace workspace = new Workspace(sessionId);
            workspace.addDirectory(name, description, parentDirectoryIdStr, isWorkspace);
        }

        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the workspace.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void getWorkspace(string sessionId)
        {
            string workspaceId = "401";
            Workspace workspace = new Workspace(sessionId);
            workspace.getWorkspace(workspaceId);
        }

        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the workspace comment.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void getWorkspaceComment(string sessionId)
        {
            string workspaceId = "3001";
            Workspace workspace = new Workspace(sessionId);
            workspace.getWorkspaceComment(workspaceId);

        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the workspace activities.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void getWorkspaceActivities(string sessionId)
        {
            string workspaceId = "3001";
            Workspace workspace = new Workspace(sessionId);
            workspace.getWorkspaceActivities(workspaceId);

        }

        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the workspace transactions.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void getWorkspaceTransactions(string sessionId)
        {
            string workspaceId = "3001";
            Workspace workspace = new Workspace(sessionId);
            workspace.getWorkspaceTransactions(workspaceId);

        }

        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the workspace user settings.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void getWorkspaceUserSettings(string sessionId)
        {
            string workspaceId = "3001";
            Workspace workspace = new Workspace(sessionId);
            workspace.getWorkspaceUserSettings(workspaceId);

        }

        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the user workspaces.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void getUserWorkspaces(string sessionId)
        {
            //string workspaceId = "1181";
            Workspace workspace = new Workspace(sessionId);
            workspace.getUserWorkspaces();

        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Saves the workspace user settings.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void saveWorkspaceUserSettings(string sessionId)
        {
            string packageId = "3001";
            Boolean newFileUpload = true;
            Boolean fileDownload = true;
            Boolean fileUpdate = true;
            Boolean fileDelete = true;
            Boolean commentAdd = true;
            Boolean userAdd = true;
            Boolean userDelete = true;
            Boolean workspaceDelete = true;
            Boolean userSelfRemove = true;
            Boolean otherChanges = true;

            Workspace workspace = new Workspace(sessionId);
            workspace.saveWorkspaceUserSettings(packageId, newFileUpload, fileDownload, fileUpdate, fileDelete, commentAdd, userAdd, userDelete,
                workspaceDelete, userSelfRemove, otherChanges);

        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the sole manager workspaces.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void getSoleManagerWorkspaces(string sessionId)
        {
            int userId = 1241;
            Workspace workspace = new Workspace(sessionId);
            workspace.getSoleManagerWorkspaces(userId);
        }

        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void addUser(string sessionId)
        {
            string emailAddress = "raine39@nilavodev.com";
            string displayAs = "raine37@nilavodev.com";
            string password = "1";
            string quota = "20";
            // Roles: recipient, sender, usr_admin, sys_admin, admin, compliance
            string roles = "sender,recipient";

            User user = new User(sessionId);
            user.addUser(emailAddress, displayAs, password, quota, roles);
        }

        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void deleteUser(string sessionId)
        {
            string userId = "1301";

            User user = new User(sessionId);
            user.deleteUser(userId);
        }

        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void updateUser(string sessionId)
        {
            string userId = "1241";
            string displayName = "Vlar Morgulis";
            string roleRecipient = "true";
            string roleSender = "true";
            string anyAdminRole = "true";

            //USR_ADMIN = User administrator , SYS_ADMIN = System administrator, ADMIN = Super user
            string roleAdmin = "SYS_ADMIN";

            // "D" = Disabled, "V" = Active
            string status = "V";

            User user = new User(sessionId);
            user.updateUser(userId, displayName, roleRecipient, roleSender, anyAdminRole, roleAdmin, status);
        }

        /*----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Adds the package.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void addPackage(string sessionId)
        {
            string name = "Test Package from REST Client";
            string description = "desc desc";
            string label = "test label";
            string owners = "raine1@nilavodev.com";
            string senders = "raine1@nilavodev.com";
            string autoDelDate = "10/03/2017 01:01 AM";
            string autoDelReminderDate = "10/02/2015 01:01 AM";

            MyFile myFile1 = new MyFile("file1.jpg", "G:\\file1.jpg");
            MyFile myFile2 = new MyFile("file2.jpg", "G:\\file2.jpg");

            List<MyFile> fileList = new List<MyFile>();

            fileList.Add(myFile1);
            fileList.Add(myFile2);
            //fileList.Add(myFile3);

            Console.Out.WriteLine("Number of attached files: " + fileList.Count);
            Package package = new Package(sessionId);
            package.addPackage(name, description, label, owners, senders, autoDelDate, autoDelReminderDate, fileList);

        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Adds the package documents.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void addPackageDocuments(string sessionId)
        {
            string packageId = "2421";

            MyFile myFile1 = new MyFile("file1.jpg", "G:\\file1.jpg");
            //MyFile myFile2 = new MyFile("jersey1.jpg", "c:\\jersey1.jpg");

            List<MyFile> fileList = new List<MyFile>();
            fileList.Add(myFile1);
            //fileList.Add(myFile2);

            Package package = new Package(sessionId);
            package.addPackageDocuments(packageId, fileList);

        }

        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Deletes the package.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void deletePackage(string sessionId)
        {
            string packageId = "2421";
            Package package = new Package(sessionId);
            package.deletePackage(packageId);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Edits the package.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void editPackage(string sessionId)
        {
            string packageId = "2441";
            string packageName = "New Package Name";
            string description = "New description";
            string label = "New label";
            string ownerEmails = "raine1@nilavodev.com, raine2@nilavodev.com";
            string senderEmails = "raine3@nilavodev.com, raine4@nilavodev.com";
            string autoPackDel = "10/03/2015 01:01 AM";
            string autoPackDelReminder = "10/02/2015 01:01 AM";

            Package package = new Package(sessionId);
            package.editPackage(packageId, packageName, description, label, ownerEmails, senderEmails, autoPackDel, autoPackDelReminder);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the package.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void getPackage(string sessionId)
        {
            string packageId = "1881";

            Package package = new Package(sessionId);
            package.getPackage(packageId);
        }

        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the package deliveries.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void getPackageDeliveries(string sessionId)
        {
            string packageId = "2801";

            Package package = new Package(sessionId);
            package.getPackageDeliveries(packageId);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the package owners.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void getPackageOwners(string sessionId)
        {
            string packageId = "961";

            Package package = new Package(sessionId);
            package.getPackageOwners(packageId);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the package senders.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void getPackageSenders(string sessionId)
        {
            string packageId = "2061";

            Package package = new Package(sessionId);
            package.getPackageSenders(packageId);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the user packages.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void getUserPackages(string sessionId)
        {
            Package package = new Package(sessionId);
            package.getUserPackages();
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Adds the delivery.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void addDelivery(string sessionId)
        {
            string packageId = "1861";
            string to = "raine2@nilavodev.com, raine4@nilavodev.com, raine5@nilavodev.com";
            string deliveryName = "Delivery from BDSRESTClient";
            string cc = "";
            string bcc = "";
            string secureMessage = "A test delivery.";
            Delivery delivery = new Delivery(sessionId);
            delivery.addDelivery(packageId, to, deliveryName, cc, bcc, secureMessage);

        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Deletes the delivery.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void deleteDelivery(string sessionId)
        {
            string deliveryId = "2352";
            Delivery delivery = new Delivery(sessionId);
            delivery.deleteDelivery(deliveryId);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Edits the delivery.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void editDelivery(string sessionId)
        {
            string deliveryId = "2361";
            string packageId = "2501";
            string recipientsToStr = "raine3@nilavodev.com, raine5@nilavodev.com, raine60@nilavodev.com";
            string recipientsCcStr = "";
            string recipientsBccStr = "";
            string deliveryName = "Edited delivery";
            string secureMessage = "Edited secure message";
            string dateAvailable = "";
            string dateExpires = "10/03/2016 01:01 AM";

            Delivery delivery = new Delivery(sessionId);
            delivery.editDelivery(deliveryId, packageId, recipientsToStr, recipientsCcStr, recipientsBccStr, deliveryName, secureMessage, dateAvailable, dateExpires);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the delivery.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void getDelivery(string sessionId)
        {
            string deliveryId = "2821";
            string returnDeliveryAccessList = "true";
            string accessByRecipient = "false";
            Delivery delivery = new Delivery(sessionId);
            delivery.getDelivery(deliveryId, returnDeliveryAccessList, accessByRecipient);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the user deliveries.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void getUserDeliveries(string sessionId)
        {
            Delivery delivery = new Delivery(sessionId);
            delivery.getUserDeliveries();
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Deletes the recipient delivery.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void deleteRecipientDelivery(string sessionId)
        {
            string deliveryId = "2361";
            Delivery delivery = new Delivery(sessionId);
            delivery.deleteRecipientDelivery(deliveryId);
        }

        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the transactions of a delivery.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void getDeliveryTransactions(string sessionId)
        {
            string deliveryId = "21";
            Delivery delivery = new Delivery(sessionId);
            string transactionLevel = "5";
            string searchText = "";
            string matchType = "co";
            string wordMatchType = "nw";
            string sortOrder = "desc";
            string numOfItemsToReturn = "20";
            string startItemNo = "1";
            string dateFrom = "";
            string dateTo = "";
            string channelType = "";
            string complianceTransactions = "false";
            string onlyComplianceTransactions = "false";
            
            delivery.getDeliveryTransactions(deliveryId, transactionLevel, searchText, matchType, wordMatchType, sortOrder,
                numOfItemsToReturn, startItemNo, dateFrom,dateTo, channelType, complianceTransactions, onlyComplianceTransactions);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Uploads the file by chunk.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private CompleteDataFileUploadOutputWS uploadFileByChunk(string sessionId, string filePath)
        {
            if(File.Exists(filePath))
            {
                //Initiate data file upload
                Console.Out.WriteLine("Initiate data file upload: ");
                DateTime saveNow = DateTime.Now;
                //append("# "+saveNow.ToString()+Environment.NewLine); //append() function rights to log file
                //append("Initiate data file upload: " + Environment.NewLine);

                FileInfo fileInfo = new FileInfo(filePath);
                long uploadFileSize = fileInfo.Length;
                string fileName = fileInfo.Name;

                Console.Out.WriteLine("File Name: " + fileName);
                Console.Out.WriteLine("File Size: " + uploadFileSize);
                //append("File Name: " + fileName + Environment.NewLine);
                //append("File Size: " + uploadFileSize + Environment.NewLine);

                DataFile dataFile = new DataFile(sessionId);
                InitiateDataFileUploadOutputWS idfu = dataFile.initiateDataFileUpload(uploadFileSize);

                //If data file upload initiation is successful, start updating data file upload
                if (idfu.returnCode == 0)
                {
                    Console.Out.WriteLine("Update data file upload:");
                    //append("Update data file upload:");

                    //position of bytes to read
                    int offset = 0;
                    //Number of bytes to read at once
                    int chunkSize = idfu.chunkSize;
                    int dataFileId = idfu.dataFileId;

                    //append("chunkSize: " + chunkSize + Environment.NewLine);
                    //append("dataFileId: " + dataFileId + Environment.NewLine);

                    // Determine the number of iterations needed to upload a file by chunk
                    long remainder = uploadFileSize % chunkSize;
                    long loops = 0;

                    if (remainder == 0)
                    {
                        loops = uploadFileSize / chunkSize;
                    }
                    else
                    {
                        loops = uploadFileSize / chunkSize + 1;
                    }

                    //Console.Out.WriteLine("\nLoops:" + loops);
                    //append("\nLoops:" + loops + Environment.NewLine);

                    try
                    {
                        Console.Out.WriteLine("\nUpdating data file upload...");
                        for (int i = 0; i < loops; i++)
                        {
                            if (i != loops - 1)
                            {
                                //append("offset:" + offset + Environment.NewLine);
                                byte[] chunk = new byte[chunkSize];
                                using (BinaryReader reader = new BinaryReader(new FileStream(filePath, FileMode.Open)))
                                {
                                    reader.BaseStream.Seek(offset, SeekOrigin.Begin);
                                    reader.Read(chunk, 0, chunkSize);
                                }
                                UpdateDataFileUploadOutputWS udfu = dataFile.updateDataFileUpload(dataFileId, offset, chunkSize, chunk, fileName);
                                //append("\nReturn Code: " + udfu.returnCode + Environment.NewLine);

                                //Update the offset
                                offset = offset + chunkSize;
                            }
                            //For the last chunk
                            else
                            {
                                //append("offset:" + offset + Environment.NewLine);
                                long def = uploadFileSize - offset;
                                //append("def: "+def+Environment.NewLine);

                                byte[] chunk = new byte[(int)def];

                                using (BinaryReader reader = new BinaryReader(new FileStream(filePath, FileMode.Open)))
                                {
                                    reader.BaseStream.Seek(offset, SeekOrigin.Begin);
                                    reader.Read(chunk, 0, (int)def);
                                }
                                UpdateDataFileUploadOutputWS udfu = dataFile.updateDataFileUpload(dataFileId, offset, (int)def, chunk, fileName);
                                Console.Out.WriteLine("Completed updating data file upload.");
                                //append("\nReturn Code: " + udfu.returnCode + Environment.NewLine);
                            }
                        }

                        Console.Out.WriteLine("\nComplete data file upload: ");
                        //append("\nComplete data file upload: " + Environment.NewLine);

                        CompleteDataFileUploadOutputWS cdfu = dataFile.completeDataFileUpload(dataFileId);
                        Console.Out.WriteLine("Uploaded file size: " + cdfu.DataFileVO.size);
                        Console.Out.WriteLine("Data file id: " + cdfu.DataFileVO.dataFileId+"\n");
                        return cdfu;
                        //append("\nReturn Code: " + cdfu.returnCode + Environment.NewLine);
                        //append("\nFile Size: " + cdfu.DataFileVO.size + Environment.NewLine);
                    }
                    catch (Exception e)
                    {
                        Console.Out.WriteLine("\nException occured while updating data file upload. Error: " + e.ToString());
                        //append("\nException occured while updating data file upload. Error: " + e.ToString() + Environment.NewLine);
                        return null;
                    }
                }
                else
                {
                    Console.Out.WriteLine("Initiation failed");
                    //append("Initiation failed" + Environment.NewLine);
                    return null;
                }
            }
            else
            {
                Console.Out.WriteLine("Couldn't find the file specified.\n");
                //append("Couldn't find the file specified." + Environment.NewLine);
                return null;
            }
        }

        /*----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Appends the specified string to the log file.
        /// </summary>
        /// <param name="str">The string.</param>
        private void append(string str)
        {
            string logFile = "c:\\log.txt";
            System.IO.File.AppendAllText(logFile, str);
        }

        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the hash.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static string GetHash(string filePath)
        {
            using (FileStream stream = File.OpenRead(filePath))
            {
                SHA256Managed sha = new SHA256Managed();
                byte[] hash = sha.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Compares the hash.
        /// </summary>
        public static void compareHash()
        {
            string a = GetHash(@"C:\file_672MB.rar");
            string b = GetHash(@"C:\Users\Raine\Desktop\bigFile.mp4");
            if (a == b) Console.Out.WriteLine("Files are identical");
            else Console.Out.WriteLine("Files are not identical");

        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Gets the reply.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void getReply(string sessionId)
        {
            string replyId = "81";
            string trackRequest = "false";

            SecureReply secureReply = new SecureReply(sessionId);
            secureReply.getReply(replyId, trackRequest);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the replies.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void getReplies(string sessionId)
        {
            SecureReply secureReply = new SecureReply(sessionId);
            secureReply.getReplies();
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Adds the reply.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void addReply(string sessionId)
        {
            string topicId = "81";
            string replySubject = "Test reply subject";
            string replyMessage = "Test reply message";
            string replySystemMessage = "Test system message";
            MyFile file = new MyFile("test.txt", @"G:\test.txt");
            SecureReply secureReply = new SecureReply(sessionId);
            secureReply.addReply(topicId, replySubject, replyMessage, replySystemMessage, file);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the reply documents.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void getReplyDocuments(string sessionId)
        {
            string replyId = "134";
            string includeDeletedItems = "true";

            SecureReply secureReply = new SecureReply(sessionId);
            secureReply.getReplyDocuments(replyId, includeDeletedItems);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the document.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void getDocument(string sessionId)
        {
            string documentId = "1481";
            string calculateHashIfNeeded = "false";

            Document document = new Document(sessionId);
            document.getDocument(documentId, calculateHashIfNeeded);

        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the documents.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void getDocuments(string sessionId)
        {
            string directoryId = "2982";
            string includeDeletedItems = "false";

            Document document = new Document(sessionId);
            document.getDocuments(directoryId, includeDeletedItems);

        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Edits the docuement.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void editDocuement(string sessionId)
        {
            string documentId = "1461";
            string name = "New name";
            string description = "New description";
            Document document = new Document(sessionId);
            document.editDocument(documentId, name, description);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Deletes the docuement.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void deleteDocuement(string sessionId)
        {
            string documentId = "1442";

            Document document = new Document(sessionId);
            document.deleteDocument(documentId);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Downloads the file by chunk.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void downloadFileByChunk(string sessionId)
        {
            int dataFileId = 2661;
            int referenceDocumentId = 2161;
            int referenceDocumentType = 2;
            long offset = 0;
            int chunkSize = 10240;
            Boolean checksumFlag = false;
            //Specify the file download location
            string downloadLocation = @"C:";

            if (Directory.Exists(downloadLocation))
            {
                //get the fileName
                Document document = new Document(sessionId);
                GetDocumentOutputWS gdows = document.getDocument(referenceDocumentId.ToString(), "false");
                string filename = gdows.documentVO.name;
                downloadLocation = downloadLocation + "\\" + filename;

                // Get data file chunk by chunk
                DataFile dataFile = new DataFile(sessionId);
                GetDataFileChunkISOutputWS output = dataFile.getDataFileChunkIS(dataFileId, referenceDocumentId, referenceDocumentType, offset, chunkSize, checksumFlag, downloadLocation);

                if (output.returnCode == 0)
                {
                    int bytesRead = output.bytesRead;
                    //append("Bytes Read: "+bytesRead.ToString()+Environment.NewLine);

                    while (!(bytesRead < chunkSize))
                    {
                        offset = offset + chunkSize;
                        //append("Offset: "+offset+", chunkSize: "+chunkSize+Environment.NewLine);
                        output = dataFile.getDataFileChunkIS(dataFileId, referenceDocumentId, referenceDocumentType, offset, chunkSize, checksumFlag, downloadLocation);
                        if (output.returnCode == 0)
                        {
                            bytesRead = output.bytesRead;
                            //append("Bytes Read: " + bytesRead.ToString() + Environment.NewLine);
                            if (bytesRead < chunkSize) Console.Out.WriteLine("File downloaded successfully.");
                        }
                    }
                }
            }
            else Console.Out.WriteLine("Invalid location specified.");
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the delivery documents.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void getDeliveryDocuments(string sessionId)
        {
            string deliveryId = "2821";            
            string sortOrder = "asc";
            string sortAttribute = "do";
            string numOfItemsToReturn ="20";
            string startItemNo = "1";
            string returnFileDownloadLinks = "true";
            Delivery delivery = new Delivery(sessionId);
            delivery.getDeliveryDocuments(deliveryId, sortOrder, sortAttribute, numOfItemsToReturn, startItemNo, returnFileDownloadLinks);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/
        // <summary>
        /// Gets the init property.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        private void getInitProperty(string sessionId)
        {
            string propertyName = "linkReceivedDeliveries";
            Delivery delivery = new Delivery(sessionId);
            delivery.getInitProperty(propertyName);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/

        public static void Main(String[] arg)
        {
            BDSRESTClientTester tester = new BDSRESTClientTester();
        }

    }
}
