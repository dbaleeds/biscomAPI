using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using System.Web.Script.Serialization;


namespace RestClient1
{
    /**
     * This class demonstrates the "Workspace" related web services. It extends BDSRESTClientBase class      
     */
    class Workspace : BDSRESTClientBase
    {
        //Constructs an object with a sessionId and a client
        public Workspace(string session)
            : base(session)
        {

        }


        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Adds a workspace.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="tags">The tags.</param>
        /// <param name="hideActivity">The hide activity.</param>
        /// <param name="autoDelDate">The automatic delete date.</param>
        /// <param name="autoDelReminderDate">The automatic delete reminder date.</param>
        /// <param name="managers">The managers.</param>
        /// <param name="collaborators">The collaborators.</param>
        /// <param name="viewers">The viewers.</param>
        /// <param name="fileList">The file list.</param>
        public void addWorkspace(string name, string description, string tags, string hideActivity, string autoDelDate,
            string autoDelReminderDate, string managers, string collaborators, string viewers, List<MyFile> fileList)
        {
            String cn = "Workspace.addWorkspace()";
            RestRequest request = new RestRequest("addWorkspace", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("name", name);
            request.AddParameter("description", description);
            request.AddParameter("tags", tags);
            request.AddParameter("hideActivity", hideActivity);
            request.AddParameter("autoDelDate", autoDelDate);
            request.AddParameter("autoDelReminderDate", autoDelReminderDate);
            request.AddParameter("managers", managers);
            request.AddParameter("collaborators", collaborators);
            request.AddParameter("viewers", viewers);

            // Adds all the files to request
            if (fileList.Count() > 0) // If fileList is not empty
            {
                foreach (MyFile myFile in fileList)
                {
                    request.AddFile(myFile.fileName, myFile.filePath);
                }
            }

            // execute the request            
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //Util.log(cn, response.Content.ToString());
                
                //AddWorkspaceOutputWS output = new AddWorkspaceOutputWS();
                //output = JsonConvert.DeserializeObject<AddWorkspaceOutputWS>(response.Content);
                //int returnCode = output.returnCode;
                
                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0: errorMessage = "Workspace added successfully"; break;
                    case 1: errorMessage = "User not accepted."; break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case 2: errorMessage = "sender license exceeded."; break;
                    case -2: errorMessage = "package with the same name already exists."; break;
                    case 3: errorMessage = "collaborator license limit exceeded."; break;
                    case -6: errorMessage = "Sufficient quota is not available for some or all owners to create package or add document"; break;
                    case -7: errorMessage = "Package delete reminder date is after auto delete date. "; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Couldn't add workspace."; break;
                }

                Console.Out.WriteLine(errorMessage);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from addWorkspace() method: " + e.Message);
            }


        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Adds documents in a workspace.
        /// </summary>
        /// <param name="workspaceId">The workspace identifier.</param>
        /// <param name="parentDirectoryId">The parent directory identifier.</param>
        /// <param name="fileList">The file list.</param>
        public void addDocumentsInWorkspace(string workspaceId, string parentDirectoryId, List<MyFile> fileList)
        {
            RestRequest request = new RestRequest("addDocumentsInWorkspace", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("workspaceId", workspaceId);
            request.AddParameter("parentDirectoryId", parentDirectoryId);

            // Adds all the files to request
            if (fileList.Count() > 0) // If fileList is not empty
            {
                foreach (MyFile myFile in fileList)
                {
                    request.AddFile(myFile.fileName, myFile.filePath);
                }
            }

            // execute the request            
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //EditWorkspaceOutputWS output = new EditWorkspaceOutputWS();
                //output = JsonConvert.DeserializeObject<EditWorkspaceOutputWS>(response.Content);
                //int returnCode = output.returnCode;

                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0: errorMessage = "Added documents in workspace successfully"; break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "Workspace not found"; break;
                    case -7: errorMessage = "Package delete reminder date is after auto delete date. "; break;
                    case -8: errorMessage = "Invalid parameter"; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Couldn't add documents to workspace."; break;
                }
                Console.Out.WriteLine(errorMessage);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from addDocumentsInWorkspace() method: " + e.Message);
            }

        }

        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Deletes a workspace.
        /// </summary>
        /// <param name="workspaceId">The workspace identifier.</param>
        public void deleteWorkspace(string workspaceId)
        {
            RestRequest request = new RestRequest("deleteWorkspace", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("packageId", workspaceId);

            // execute the request            
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //DeleteWorkspaceOutputWS output = new DeleteWorkspaceOutputWS();
                //output = JsonConvert.DeserializeObject<DeleteWorkspaceOutputWS>(response.Content);
                //int returnCode = output.returnCode;
                
                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));
                
                Console.Out.WriteLine("Return code:" + returnCode);
                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {

                    case 0: errorMessage = "Workspace deleted successful"; break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "Package not found"; break;
                    case -3: errorMessage = "Invalid parameter"; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Couldn't delete workspace."; break;
                }
                Console.Out.WriteLine(errorMessage);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from deleteWorkspace() method: " + e.Message);
            }

        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Edits the information of a workspace.
        /// </summary>
        /// <param name="workspaceId">The workspace identifier.</param>
        /// <param name="workspaceName">Name of the workspace.</param>
        /// <param name="description">The description.</param>
        /// <param name="label">The label.</param>
        public void editWorkspaceInfo(string workspaceId, String workspaceName, String description, String label)
        {
            RestRequest request = new RestRequest("editWorkspaceInfo", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("workspaceId", workspaceId);
            request.AddParameter("workspaceName", workspaceName);
            request.AddParameter("description", description);
            request.AddParameter("label", label);

            // execute the request            
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //Util.log("editWorkspaceInfo", response.Content.ToString());
                //EditWorkspaceOutputWS output = new EditWorkspaceOutputWS();
                //output = JsonConvert.DeserializeObject<EditWorkspaceOutputWS>(response.Content);
                //int returnCode = output.returnCode;

                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));

                Console.Out.WriteLine("Return code:" + returnCode);
                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0: errorMessage = "Workspace info edited successfully"; break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "Workspace not found"; break;
                    case -7: errorMessage = "Package delete reminder date is after auto delete date. "; break;
                    case -8: errorMessage = "Invalid parameter"; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Couldn't edit workspace info."; break;
                }
                Console.Out.WriteLine(errorMessage);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from editWorkspaceInfo() method: " + e.Message);
            }
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/


        /// <summary>
        /// Edits the workspace users.
        /// </summary>
        /// <param name="workspaceId">The workspace identifier.</param>
        /// <param name="managers">The managers.</param>
        /// <param name="collaborators">The collaborators.</param>
        /// <param name="viewers">The viewers.</param>
        public void editWorkspaceUsers(string workspaceId, String managers, String collaborators, String viewers)
        {
            RestRequest request = new RestRequest("editWorkspaceUsers", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("workspaceId", workspaceId);
            request.AddParameter("managers", managers);
            request.AddParameter("collaborators", collaborators);
            request.AddParameter("viewers", viewers);

            // execute the request            
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //EditWorkspaceOutputWS output = new EditWorkspaceOutputWS();
                //output = JsonConvert.DeserializeObject<EditWorkspaceOutputWS>(response.Content);

                string json = response.Content.ToString();
                JObject o = JObject.Parse(json);
                string returnCodeStr = (string)o.SelectToken("returnCode");
                int returnCode = Convert.ToInt32(returnCodeStr);
                
                //int returnCode = output.returnCode;
                Console.Out.WriteLine("Return code:" + returnCode);
                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0: errorMessage = "Workspace users edited successfully"; break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "Workspace not found"; break;
                    case -7: errorMessage = "Package delete reminder date is after auto delete date. "; break;
                    case -8: errorMessage = "Invalid parameter"; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Couldn't edit workspace users."; break;
                }
                Console.Out.WriteLine(errorMessage);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from editWorkspaceUsers() method: " + e.Message);
            }
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Adds comment to a workspace.
        /// </summary>
        /// <param name="workspaceId">The workspace identifier.</param>
        /// <param name="topicId">The topic identifier.</param>
        /// <param name="commentMessage">The comment message.</param>
        public void addWorkspaceComment(string workspaceId, string topicId, string commentMessage)
        {
            RestRequest request = new RestRequest("addWorkspaceComment", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("workspaceId", workspaceId);
            request.AddParameter("topicId", workspaceId);
            request.AddParameter("commentMessage", commentMessage);

            // execute the request            
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                
                //AddCommentOutputWS output = new AddCommentOutputWS();
                //output = JsonConvert.DeserializeObject<AddCommentOutputWS>(response.Content);
                //int returnCode = output.returnCode;
                
                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));
                
                Console.Out.WriteLine("Return code:" + returnCode);
                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0: errorMessage = "Added comment to workspace successfully"; break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Couldn't add comment to workspace."; break;
                }
                Console.Out.WriteLine(errorMessage);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from addWorkspaceComment() method: " + e.Message);
            }

        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Locks a workspace.
        /// </summary>
        /// <param name="workspaceId">The workspace identifier.</param>
        /// <param name="Lock">if set to <c>true</c> [lock].</param>
        public void lockWorkspace(string workspaceId, Boolean Lock)
        {
            RestRequest request = new RestRequest("lockWorkspace", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("packageId", workspaceId);
            request.AddParameter("lock", Lock);

            // execute the request            
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //LockWorkspaceOutputWS output = new LockWorkspaceOutputWS();            
                //output = JsonConvert.DeserializeObject<LockWorkspaceOutputWS>(response.Content);
                //int returnCode = output.returnCode;

                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));

                Console.Out.WriteLine("Return code:" + returnCode);
                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0: if (Lock == true) { errorMessage = "Workspace locked successfully"; } else { errorMessage = "Workspace unlocked successfully"; } break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "Package not found."; break;
                    case -3: errorMessage = "Workspace already locked."; break;
                    case -4: errorMessage = "Workspace already locked."; break;
                    case -5: errorMessage = "Invalid parameter"; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: if (Lock == true) { errorMessage = "Couldn't lock the workspace"; } else { errorMessage = "Couldn't unlock the workspace"; } break;
                }
                Console.Out.WriteLine(errorMessage);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from addWorkspaceComment() method: " + e.Message);
            }

        }



        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Adds directory to a workspace.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="parentDirectoryIdStr">The parent directory identifier string.</param>
        /// <param name="isWorkspace">The is workspace.</param>
        public void addDirectory(string name, string description, string parentDirectoryIdStr, string isWorkspace)
        {
            RestRequest request = new RestRequest("addDirectory", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("name", name);
            request.AddParameter("description", description);
            request.AddParameter("parentDirectoryId", parentDirectoryIdStr);
            request.AddParameter("isWorkspace", isWorkspace);

            // execute the request
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //AddDirectoryOutputWS adows = JsonConvert.DeserializeObject<AddDirectoryOutputWS>(response.Content);
                //int returnCode = adows.returnCode;
                
                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));
                Console.Out.WriteLine("Return code:" + returnCode);

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0: errorMessage = "Directory added successfully"; break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "Directory already exists"; break;
                    case -3: errorMessage = "Parent directory not found."; break;
                    case -4: errorMessage = "Sufficient storage not available for adding folder."; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Couldn't add directory."; break;
                }
                Console.Out.WriteLine(errorMessage);

            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from addDirectory() method: " + e.Message);
            }

        }

        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the workspace.
        /// </summary>
        /// <param name="packageId">The package identifier.</param>
        public void getWorkspace(string packageId)
        {
            RestRequest request = new RestRequest("getWorkspace", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("packageId", packageId);


            // execute the request
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //GetWorkspaceOutputWS output = JsonConvert.DeserializeObject<GetWorkspaceOutputWS>(response.Content);
                //GetWorkspaceOutputWS1 output1 = JsonConvert.DeserializeObject<GetWorkspaceOutputWS1>(response.Content);
                //Util.log("Get Workspace", response.Content.ToString());
                string json = response.Content.ToString();
                JObject o = JObject.Parse(json);
                string returnCodeStr = (string)o.SelectToken("returnCode");
                int returnCode = Convert.ToInt32(returnCodeStr);
                Console.Out.WriteLine("Return code:" + returnCode);

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0: errorMessage = "Workspace is retrieved successfully";
                        //Console.Out.WriteLine(output.workspaceVOWS.toString());

                        string NEW_LINE = "\n";
                        StringBuilder thisString = new StringBuilder();

                        thisString.Append(NEW_LINE);
                        thisString.Append("Workspace Name: ");
                        thisString.Append(o.SelectToken("workspaceVOWS.name"));
                        thisString.Append(NEW_LINE);

                        thisString.Append("Package ID: ");
                        thisString.Append(o.SelectToken("workspaceVOWS.packageId"));
                        thisString.Append(NEW_LINE);

                        thisString.Append("Root directory ID: ");
                        thisString.Append(o.SelectToken("workspaceVOWS.rootDirectoryId"));
                        thisString.Append(NEW_LINE);
                        
                        thisString.Append("Size: ");
                        thisString.Append(o.SelectToken("workspaceVOWS.size"));
                        thisString.Append(NEW_LINE);

                        thisString.Append("Status: ");
                        thisString.Append(o.SelectToken("workspaceVOWS.status"));
                        thisString.Append(NEW_LINE);

                        thisString.Append("Created by: ");
                        thisString.Append(o.SelectToken("workspaceVOWS.createdBy"));
                        thisString.Append(NEW_LINE);

                        thisString.Append("Created by display name: ");
                        thisString.Append(o.SelectToken("workspaceVOWS.createdByDisplayName"));
                        thisString.Append(NEW_LINE);

                        thisString.Append("Date created: ");
                        thisString.Append(o.SelectToken("workspaceVOWS.dateCreated"));
                        thisString.Append(NEW_LINE);

                        thisString.Append("Date last updated: ");
                        thisString.Append(o.SelectToken("workspaceVOWS.dateLastUpdated"));
                        thisString.Append(NEW_LINE);

                        thisString.Append("Description: ");
                        thisString.Append(o.SelectToken("workspaceVOWS.description"));
                        thisString.Append(NEW_LINE);

                        thisString.Append("Workspace Users: ");
                        thisString.Append(NEW_LINE);
                        thisString.Append(o.SelectToken("workspaceVOWS.workspaceUsers"));
                        thisString.Append(NEW_LINE);

                        errorMessage = errorMessage + "\n\n" + thisString;

                        break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "Package not found"; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Couldn't retrieve workspace."; break;
                }
                Console.Out.WriteLine(errorMessage);

            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from getWorkspace() method: " + e.Message);
            }

        }

        /*----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Gets the workspace comment.
        /// </summary>
        /// <param name="packageId">The package identifier.</param>
        public void getWorkspaceComment(string packageId)
        {
            RestRequest request = new RestRequest("getWorkspaceComments", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("packageId", packageId);

            // execute the request
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //Util.log("GetWorkspaceComments", response.Content.ToString());
                //GetWorkspaceCommentsOutputWS output = JsonConvert.DeserializeObject<GetWorkspaceCommentsOutputWS>(response.Content);
                //int returnCode = output.returnCode;

                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));
                var commentInfoList = o.SelectToken("commentInfoList");
               

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                string comments = "";
                switch (returnCode)
                {
                    case 0: errorMessage = "Workspace comments are retrieved successfully";
                        //Console.Out.WriteLine("Workspace Name: "+output.workspaceVOWS.name);
                        if (commentInfoList != null)
                        {
                            comments = commentInfoList.ToString();
                        }
                        else
                        {
                            comments = "No comments in the workspace so far.";
                        }                        
                        break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Couldn't retrieve workspace comment."; break;
                }
                Console.Out.WriteLine(errorMessage);
                Console.Out.WriteLine(comments);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from getWorkspaceComment() method: " + e.Message);
            }
        }

        /*----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Gets the workspace activities.
        /// </summary>
        /// <param name="packageId">The package identifier.</param>
        public void getWorkspaceActivities(string packageId)
        {
            RestRequest request = new RestRequest("getWorkspaceActivities", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("packageId", packageId);

            // execute the request
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //Util.log("Get Workspace Activities", response.Content.ToString());
                
                //GetWorkspaceNotificationsOutputWS output = JsonConvert.DeserializeObject<GetWorkspaceNotificationsOutputWS>(response.Content);
                //int returnCode = output.returnCode;

                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));
                var workspaceNotifications = o.SelectToken("workspaceNotifications");
               
                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                StringBuilder message = new StringBuilder();
                
                switch (returnCode)
                {
                    case 0: errorMessage = "Workspace activity is retrieved successfully";
                        //Console.Out.WriteLine("Workspace Name: "+output.workspaceVOWS.name);
                        //comments = output.toString();
                        if (workspaceNotifications != null) 
                        {
                            message.AppendLine(workspaceNotifications.ToString());
                        }
                        break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "Package not found"; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Couldn't retrieve workspace activity."; break;
                }
                Console.Out.WriteLine(errorMessage);
                Console.Out.WriteLine(message);

            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from getWorkspaceActivities() method: " + e.Message);
            }


        }

        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the workspace transactions.
        /// </summary>
        /// <param name="packageId">The package identifier.</param>
        public void getWorkspaceTransactions(string packageId)
        {
            RestRequest request = new RestRequest("getWorkspaceTransactions", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("packageId", packageId);

            // execute the request
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //Util.log("getWorkspaceTransactions", response.Content.ToString());
                //GetWorkspaceTransactionsOutputWS output = JsonConvert.DeserializeObject<GetWorkspaceTransactionsOutputWS>(response.Content);
                //int returnCode = output.returnCode;

                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));
                int totalRowCount = Convert.ToInt32((string)o.SelectToken("totalRowCount"));
                var workspaceTransactionVOs = o.SelectToken("workspaceTransactionVOs");

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                StringBuilder message = new StringBuilder();
                switch (returnCode)
                {
                    case 0: errorMessage = "Workspace transaction is retrieved successfully";
                        //Console.Out.WriteLine("Workspace Name: "+output.workspaceVOWS.name);

                        // For multiple transactions, workspaceTransactionVOs array. We need to parse it accordingly.
                        if (totalRowCount > 1)
                        {
                            for (int i = 0; i < totalRowCount; i++)
                            {
                                message.AppendLine(Environment.NewLine + (i + 1).ToString() + ".");
                                String transactionId = (string)workspaceTransactionVOs[i].SelectToken("transactionId");
                                message.AppendLine("Transaction ID :" + transactionId);
                                String logEntry = (string)workspaceTransactionVOs[i].SelectToken("logEntry");
                                message.AppendLine("Log Entry :" + logEntry);
                                String action = (string)workspaceTransactionVOs[i].SelectToken("action");
                                message.AppendLine("Action :" + action);
                                String target = (string)workspaceTransactionVOs[i].SelectToken("target");
                                message.AppendLine("Target :" + target);
                                String category = (string)workspaceTransactionVOs[i].SelectToken("category");
                                message.AppendLine("Category :" + category);
                                String channelType = (string)workspaceTransactionVOs[i].SelectToken("channelType");
                                message.AppendLine("Channel type :" + channelType);
                                String ipAddress = (string)workspaceTransactionVOs[i].SelectToken("ipAddress");
                                message.AppendLine("IP Address :" + ipAddress);
                                String level = (string)workspaceTransactionVOs[i].SelectToken("level");
                                message.AppendLine("Level :" + level);
                                String parsedTransactionDate = (string)workspaceTransactionVOs[i].SelectToken("parsedTransactionDate");
                                message.AppendLine("Parsed transaction date :" + parsedTransactionDate);
                                String status = (string)workspaceTransactionVOs[i].SelectToken("status");
                                message.AppendLine("Status :" + status);
                                String transactionDate = (string)workspaceTransactionVOs[i].SelectToken("transactionDate");
                                message.AppendLine("Transaction Date :" + transactionDate);
                                String type = (string)workspaceTransactionVOs[i].SelectToken("type");
                                message.AppendLine("Type :" + type);
                                String userId = (string)workspaceTransactionVOs[i].SelectToken("userId");
                                message.AppendLine("User ID :" + userId);
                                String version = (string)workspaceTransactionVOs[i].SelectToken("version");
                                message.AppendLine("Version :" + version);
                                
                            }
                        }

                        // For single transaction, workspaceTransactionVOs is not an array. We need to parse it accordingly.
                        else if (totalRowCount == 1)
                        {
                            message.AppendLine(Environment.NewLine + "1.");
                            String transactionId = (string)workspaceTransactionVOs.SelectToken("transactionId");
                            message.AppendLine("Transaction ID :" + transactionId);
                            String logEntry = (string)workspaceTransactionVOs.SelectToken("logEntry");
                            message.AppendLine("Log Entry :" + logEntry);
                            String action = (string)workspaceTransactionVOs.SelectToken("action");
                            message.AppendLine("Action :" + action);
                            String target = (string)workspaceTransactionVOs.SelectToken("target");
                            message.AppendLine("Target :" + target);
                            String category = (string)workspaceTransactionVOs.SelectToken("category");
                            message.AppendLine("Category :" + category);
                            String channelType = (string)workspaceTransactionVOs.SelectToken("channelType");
                            message.AppendLine("Channel type :" + channelType);
                            String ipAddress = (string)workspaceTransactionVOs.SelectToken("ipAddress");
                            message.AppendLine("IP Address :" + ipAddress);
                            String level = (string)workspaceTransactionVOs.SelectToken("level");
                            message.AppendLine("Level :" + level);
                            String parsedTransactionDate = (string)workspaceTransactionVOs.SelectToken("parsedTransactionDate");
                            message.AppendLine("Parsed transaction date :" + parsedTransactionDate);
                            String status = (string)workspaceTransactionVOs.SelectToken("status");
                            message.AppendLine("Status :" + status);
                            String transactionDate = (string)workspaceTransactionVOs.SelectToken("transactionDate");
                            message.AppendLine("Transaction Date :" + transactionDate);
                            String type = (string)workspaceTransactionVOs.SelectToken("type");
                            message.AppendLine("Type :" + type);
                            String userId = (string)workspaceTransactionVOs.SelectToken("userId");
                            message.AppendLine("User ID :" + userId);
                            String version = (string)workspaceTransactionVOs.SelectToken("version");
                            message.AppendLine("Version :" + version);

                        }
                        // No transaction found
                        else
                        {
                            message.AppendLine("No transaction found for the workspace");
                        }  
                        break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "Package not found"; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Couldn't retrieve workspace transaction."; break;
                }
                Console.Out.WriteLine(errorMessage);
                Console.Out.WriteLine(message.ToString());

            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from getWorkspaceTransactions() method: " + e.Message);
            }


        }

        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the workspace user settings.
        /// </summary>
        /// <param name="packageId">The package identifier.</param>
        public void getWorkspaceUserSettings(string packageId)
        {
            RestRequest request = new RestRequest("getWorkspaceUserSettings", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("packageId", packageId);

            // execute the request
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //Util.log("getWorkspaceUserSettings", response.Content.ToString());

                //GetWorkspaceUserSettingsOutputWS1 output = JsonConvert.DeserializeObject<GetWorkspaceUserSettingsOutputWS1>(response.Content);
                //int returnCode = output.returnCode;

                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));
                var settingMap = o.SelectToken("settingMap.entry");

                string errorMessage = "";
                StringBuilder message = new StringBuilder();
                switch (returnCode)
                {
                    case 0: errorMessage = "Workspace user settings is retrieved successfully";
                        if (settingMap != null)
                        {
                            for (int i = 0; i < settingMap.Count(); i++)
                            {
                                String key = (string)settingMap[i].SelectToken("key");
                                String value = (string)settingMap[i].SelectToken("value");
                                message.AppendLine(key + ":" + value);
                            }
                        }
                        else
                        {
                            message.AppendLine("No settings found for the user.");
                        }
                        break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "Package not found"; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Couldn't retrieve workspace user settings."; break;
                }
                Console.Out.WriteLine(errorMessage);
                Console.Out.WriteLine(message.ToString());
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from getWorkspaceUserSettings() method: " + e.Message);
            }


        }

        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the workspaces of a user.
        /// </summary>
        public void getUserWorkspaces()
        {
            RestRequest request = new RestRequest("getUserWorkspaces", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            //request.AddParameter("packageId", packageId);

            // execute the request
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //Util.log("getUserWorkspaces()", response.Content.ToString());


                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));
                int totalRowCount = Convert.ToInt32((string)o.SelectToken("totalRowCount"));
                var workspaceVOWSs = o.SelectToken("workspaceVOWSs");
                 
                //GetUserWorkspacesOutputWS output = JsonConvert.DeserializeObject<GetUserWorkspacesOutputWS>(response.Content);
                //int returnCode = output.returnCode;

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                StringBuilder message = new StringBuilder();
                switch (returnCode)
                {
                    case 0: errorMessage = "Successfully retrieved the workspaces of the user!";
                        
                        // For multiple workspaces, workspaceVOWSs is an array. We need to parse it accordingly.
                        if (totalRowCount > 1)
                        {
                            for (int i = 0; i < totalRowCount; i++)
                            {
                                message.AppendLine(Environment.NewLine + (i + 1).ToString() + ".");
                                String workspaceName = (string)workspaceVOWSs[i].SelectToken("name");
                                message.AppendLine("Workspace Name :" + workspaceName);
                                String createdByDisplayName = (string)workspaceVOWSs[i].SelectToken("createdByDisplayName");
                                message.AppendLine("Created By :" + createdByDisplayName);
                                String dateCreated = (string)workspaceVOWSs[i].SelectToken("dateCreated");
                                message.AppendLine("Date created :" + dateCreated);
                            }
                        }
                        
                        // For single workspace, workspaceVOWSs is not an array. We need to parse it accordingly.
                        else if (totalRowCount == 1)
                        {
                            message.AppendLine(Environment.NewLine + "1.");
                            String workspaceName = (string)workspaceVOWSs.SelectToken("name");
                            message.AppendLine("Workspace Name :" + workspaceName);
                            String createdByDisplayName = (string)workspaceVOWSs.SelectToken("createdByDisplayName");
                            message.AppendLine("Created By :" + createdByDisplayName);
                            String dateCreated = (string)workspaceVOWSs.SelectToken("dateCreated");
                            message.AppendLine("Date created :" + dateCreated);

                        }
                        // No workspace found
                        else
                        {
                            message.AppendLine("No workspace found for the user");
                        }                       
                        break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "user not found"; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "getUserWorkspaces unsuccessfull."; break;
                }
                Console.Out.WriteLine(errorMessage);
                Console.Out.WriteLine(message.ToString());
            }

            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from getUserWorkspaces() method: " + e.Message);
            }


        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Saves the workspace user settings.
        /// </summary>
        /// <param name="packageId">The package identifier.</param>
        /// <param name="newFileUpload">if set to <c>true</c> [new file upload].</param>
        /// <param name="fileDownload">if set to <c>true</c> [file download].</param>
        /// <param name="fileUpdate">if set to <c>true</c> [file update].</param>
        /// <param name="fileDelete">if set to <c>true</c> [file delete].</param>
        /// <param name="commentAdd">if set to <c>true</c> [comment add].</param>
        /// <param name="userAdd">if set to <c>true</c> [user add].</param>
        /// <param name="userDelete">if set to <c>true</c> [user delete].</param>
        /// <param name="workspaceDelete">if set to <c>true</c> [workspace delete].</param>
        /// <param name="userSelfRemove">if set to <c>true</c> [user self remove].</param>
        /// <param name="otherChanges">if set to <c>true</c> [other changes].</param>
        public void saveWorkspaceUserSettings(string packageId, Boolean newFileUpload, Boolean fileDownload, Boolean fileUpdate, Boolean fileDelete,
            Boolean commentAdd, Boolean userAdd, Boolean userDelete, Boolean workspaceDelete, Boolean userSelfRemove, Boolean otherChanges)
        {
            RestRequest request = new RestRequest("saveWorkspaceUserSettings", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("packageId", packageId);
            request.AddParameter("newFileUpload", newFileUpload);
            request.AddParameter("fileDownload", fileDownload);
            request.AddParameter("fileUpdate", fileUpdate);
            request.AddParameter("fileDelete", fileDelete);

            request.AddParameter("commentAdd", commentAdd);
            request.AddParameter("userAdd", userAdd);
            request.AddParameter("userDelete", userDelete);
            request.AddParameter("workspaceDelete", workspaceDelete);
            request.AddParameter("userSelfRemove", userSelfRemove);
            request.AddParameter("otherChanges", otherChanges);

            // execute the request
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //Util.log("saveWorkspaceUserSettings", response.Content.ToString());
                //SaveWorkspaceUserSettingsOutputWS output = JsonConvert.DeserializeObject<SaveWorkspaceUserSettingsOutputWS>(response.Content);
                //int returnCode = output.returnCode;
                
                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0: errorMessage = "Workspace user settings is saved successfully"; break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "Package not found"; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Couldn't save workspace user settings."; break;
                }
                Console.Out.WriteLine(errorMessage);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from saveWorkspaceUserSettings() method: " + e.Message);
            }


        }

        /*----------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the sole manager workspaces.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        public void getSoleManagerWorkspaces(int userId)
        {

            RestRequest request = new RestRequest("getSoleManagerWorkspaces", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("userId", userId);

            // execute the request
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //GetSoleManagerWorkspacesOutputWS output = JsonConvert.DeserializeObject<GetSoleManagerWorkspacesOutputWS>(response.Content);
                //int returnCode = output.returnCode;

                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));
                string workspaceNames = (string)o.SelectToken("workspaceNames");
                int soleManagerCount = Convert.ToInt32((string)o.SelectToken("soleManagerCount"));

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0: errorMessage = "Get sole manager workspaces successfull\nWorkspace Names: " + workspaceNames + "\nNumber of sole manaders: " + soleManagerCount; break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "User not found"; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "getSoleManagerWorkspaces unsuccessfull."; break;
                }
                Console.Out.WriteLine(errorMessage);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from getSoleManagerWorkspaces() method: " + e.Message);
            }

        }

    }
}
