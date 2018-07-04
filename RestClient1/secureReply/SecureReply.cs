using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using Newtonsoft.Json;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace RestClient1.secureReply
{
    class SecureReply: BDSRESTClientBase
    {
        public SecureReply(string session) : base(session)
        {

        }

        /// <summary>
        /// Gets the reply.
        /// </summary>
        /// <param name="replyId">The reply identifier.</param>
        /// <param name="trackRequest">The track request.</param>
        public void getReply(string replyId, string trackRequest)
        {
            RestRequest request = new RestRequest("getReply", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("replyId", replyId);
            request.AddParameter("trackRequest", trackRequest);

            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //Util.log("getReply", response.Content.ToString());

                //GetReplyOutputWS output = new GetReplyOutputWS();
                //output = JsonConvert.DeserializeObject<GetReplyOutputWS>(response.Content);

                //int returnCode = output.returnCode;

                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));
                int totalRowCount = Convert.ToInt32((string)o.SelectToken("totalRowCount"));
                var replies = o.SelectToken("replyVO");

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                StringBuilder message = new StringBuilder();
                switch (returnCode)
                {
                    case 0: errorMessage = "Reply retrieved successfully"; 
                                message.AppendLine(Environment.NewLine);
                                String createdBy = (string)replies.SelectToken("createdBy");
                                message.AppendLine("createdBy :" + createdBy);
                                String dateCreated = (string)replies.SelectToken("dateCreated");
                                message.AppendLine("dateCreated :" + dateCreated);
                                String dateLastUpdated = (string)replies.SelectToken("dateLastUpdated");
                                message.AppendLine("dateLastUpdated :" + dateLastUpdated);
                                String lastUpdatedBy = (string)replies.SelectToken("lastUpdatedBy");
                                message.AppendLine("lastUpdatedBy :" + lastUpdatedBy);
                                String read = (string)replies.SelectToken("read");
                                message.AppendLine("read :" + read);
                                //String replyId = (string)replies.SelectToken("replyId");
                                message.AppendLine("replyId :" + replyId);
                                String replyMessage = (string)replies.SelectToken("replyMessage");
                                message.AppendLine("replyMessage :" + replyMessage);
                                String replyNum = (string)replies.SelectToken("replyNum");
                                message.AppendLine("replyNum :" + replyNum);
                                String replySubject = (string)replies.SelectToken("replySubject");
                                message.AppendLine("replySubject :" + replySubject);
                                String replySystemMessage = (string)replies.SelectToken("replySystemMessage");
                                message.AppendLine("replySystemMessage :" + replySystemMessage);
                                String status = (string)replies.SelectToken("status");
                                message.AppendLine("status :" + status);
                                String topicId = (string)replies.SelectToken("topicId");
                                message.AppendLine("replyNum :" + topicId);
                                String totalViewed = (string)replies.SelectToken("totalViewed");
                                message.AppendLine("totalViewed :" + totalViewed);
                        break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "Reply not found."; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Failed to retrieve reply."; break;

                }
                Console.Out.WriteLine("Return Code: " + returnCode + ". " + errorMessage + "\n"+message.ToString());
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from getReply() method: " + e.Message);
            }

        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the replies.
        /// </summary>
        public void getReplies()
        {
            RestRequest request = new RestRequest("getReplies", Method.POST);
            request.AddParameter("sessionId", this.sessionId);

            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //Util.log("getReplies", response.Content.ToString());

                //GetRepliesOutputWS output = new GetRepliesOutputWS();
                //output = JsonConvert.DeserializeObject<GetRepliesOutputWS>(response.Content);
                //int returnCode = output.returnCode;
                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));
                int totalRowCount = Convert.ToInt32((string)o.SelectToken("totalRowCount"));
                var replies = o.SelectToken("replies");

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                StringBuilder message = new StringBuilder();
                switch (returnCode)
                {
                    case 0: errorMessage = "Replies retrieved successfully";
                        if (replies != null)
                        {
                            if (totalRowCount > 1)
                            {
                                for (int i = 0; i < replies.Count(); i++)
                                {
                                    message.AppendLine(Environment.NewLine + (i + 1).ToString() + ".");
                                    String createdBy = (string)replies[i].SelectToken("createdBy");
                                    message.AppendLine("createdBy :" + createdBy);
                                    String dateCreated = (string)replies[i].SelectToken("dateCreated");
                                    message.AppendLine("dateCreated :" + dateCreated);
                                    String dateLastUpdated = (string)replies[i].SelectToken("dateLastUpdated");
                                    message.AppendLine("dateLastUpdated :" + dateLastUpdated);
                                    String lastUpdatedBy = (string)replies[i].SelectToken("lastUpdatedBy");
                                    message.AppendLine("lastUpdatedBy :" + lastUpdatedBy);
                                    String read = (string)replies[i].SelectToken("read");
                                    message.AppendLine("read :" + read);
                                    String replyId = (string)replies[i].SelectToken("replyId");
                                    message.AppendLine("replyId :" + replyId);
                                    String replyMessage = (string)replies[i].SelectToken("replyMessage");
                                    message.AppendLine("replyMessage :" + replyMessage);
                                    String replyNum = (string)replies[i].SelectToken("replyNum");
                                    message.AppendLine("replyNum :" + replyNum);
                                    String replySubject = (string)replies[i].SelectToken("replySubject");
                                    message.AppendLine("replySubject :" + replySubject);
                                    String replySystemMessage = (string)replies[i].SelectToken("replySystemMessage");
                                    message.AppendLine("replySystemMessage :" + replySystemMessage);
                                    String status = (string)replies[i].SelectToken("status");
                                    message.AppendLine("status :" + status);
                                    String topicId = (string)replies[i].SelectToken("topicId");
                                    message.AppendLine("replyNum :" + topicId);
                                    String totalViewed = (string)replies[i].SelectToken("totalViewed");
                                    message.AppendLine("totalViewed :" + totalViewed);
                                }
                            }

                            else if (totalRowCount == 1)
                            {
                                message.AppendLine(Environment.NewLine + "1.");
                                String createdBy = (string)replies.SelectToken("createdBy");
                                message.AppendLine("createdBy :" + createdBy);
                                String dateCreated = (string)replies.SelectToken("dateCreated");
                                message.AppendLine("dateCreated :" + dateCreated);
                                String dateLastUpdated = (string)replies.SelectToken("dateLastUpdated");
                                message.AppendLine("dateLastUpdated :" + dateLastUpdated);
                                String lastUpdatedBy = (string)replies.SelectToken("lastUpdatedBy");
                                message.AppendLine("lastUpdatedBy :" + lastUpdatedBy);
                                String read = (string)replies.SelectToken("read");
                                message.AppendLine("read :" + read);
                                String replyId = (string)replies.SelectToken("replyId");
                                message.AppendLine("replyId :" + replyId);
                                String replyMessage = (string)replies.SelectToken("replyMessage");
                                message.AppendLine("replyMessage :" + replyMessage);
                                String replyNum = (string)replies.SelectToken("replyNum");
                                message.AppendLine("replyNum :" + replyNum);
                                String replySubject = (string)replies.SelectToken("replySubject");
                                message.AppendLine("replySubject :" + replySubject);
                                String replySystemMessage = (string)replies.SelectToken("replySystemMessage");
                                message.AppendLine("replySystemMessage :" + replySystemMessage);
                                String status = (string)replies.SelectToken("status");
                                message.AppendLine("status :" + status);
                                String topicId = (string)replies.SelectToken("topicId");
                                message.AppendLine("replyNum :" + topicId);
                                String totalViewed = (string)replies.SelectToken("totalViewed");
                                message.AppendLine("totalViewed :" + totalViewed);
                            }
                        }
                        else
                        {
                            message.AppendLine("No reply found for the user");
                        }
                        
                        break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Failed to retrieve replies."; break;

                }
                Console.Out.WriteLine("Return Code: " + returnCode + ". " + errorMessage + "\n");
                Console.Out.WriteLine(message.ToString());
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from getReplies() method: " + e.Message);
            }

        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Adds the reply.
        /// </summary>
        /// <param name="topicId">The topic identifier.</param>
        /// <param name="replySubject">The reply subject.</param>
        /// <param name="replyMessage">The reply message.</param>
        /// <param name="replySystemMessage">The reply system message.</param>
        /// <param name="file">The file.</param>
        public void addReply(string topicId, string replySubject, string replyMessage, string replySystemMessage, MyFile file)
        {
            RestRequest request = new RestRequest("addReply", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("topicId", topicId);
            request.AddParameter("replySubject", replySubject);
            request.AddParameter("replyMessage", replyMessage);
            request.AddParameter("replySystemMessage", replySystemMessage);
            request.AddFile(file.fileName, file.filePath);

            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //Util.log("addReply", response.Content.ToString());

                //AddReplyOutputWS output = new AddReplyOutputWS();
                //output = JsonConvert.DeserializeObject<AddReplyOutputWS>(response.Content);

                //int returnCode = output.returnCode;

                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0: errorMessage = "Reply added successfully"; break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "Reply with the same name already exists."; break;
                    case -3: errorMessage = "Folder not found."; break;
                    case -4: errorMessage = "Sufficient storage not available for adding reply."; break;
                    case -5: errorMessage = "Reply added but reply object could not be retrieved."; break;
                    case -6: errorMessage = "Document could not be added as it has restricted pattern."; break;
                    case -7: errorMessage = "Sufficient quota is not available for some or all owners to create package or add document."; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Failed to add reply."; break;

                }
                Console.Out.WriteLine("Return Code: " + returnCode + ". " + errorMessage);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from addReply() method: " + e.Message);
            }
        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary>
        /// Gets the reply documents.
        /// </summary>
        /// <param name="replyId">The reply identifier.</param>
        /// <param name="includeDeletedItems">The include deleted items.</param>
        public void getReplyDocuments(string replyId, string includeDeletedItems)
        {
            RestRequest request = new RestRequest("getReplyDocuments", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("replyId", replyId);
            request.AddParameter("includeDeletedItems", includeDeletedItems);

            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //Util.log("getReplyDocuments", response.Content.ToString());

                string json = response.Content.ToString();
                
                JObject o = JObject.Parse(json);
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));
                int rows = Convert.ToInt32((string)o.SelectToken("totalRowCount"));
                var replyDocumentVOs = o.SelectToken("replyDocumentVOs");

                //If replyDocumentVOs is empty
                if (rows == 0)
                {
                    Console.Out.WriteLine("\nNo documents found in the reply.");
                }

                else
                {
                    if (rows == 1)
                    {
                        //JObject replyDocumentVOs = (JObject)o.SelectToken("replyDocumentVOs");
                        //string str = Regex.Replace(replyDocumentVOs.ToString(), @"\s+", "");
                        //json = json.Replace(str, "[" + str + "]");
                        json = "{\"replyDocumentVOs\":[" + replyDocumentVOs.ToString() + "] ,\"returnCode\":\"" + (string)o.SelectToken("returnCode") + "\",\"totalRowCount\":\"" + (string)o.SelectToken("totalRowCount") + "\"}";
                        JObject j = JObject.Parse(json);
                        replyDocumentVOs = j.SelectToken("replyDocumentVOs");
                    }                 
                                                            
                    //GetReplyDocumentsOutputWS output = new GetReplyDocumentsOutputWS();
                    //output = JsonConvert.DeserializeObject<GetReplyDocumentsOutputWS>(json);
                    //int returnCode = output.returnCode;

                    //Message according to the return code. Only most frequent cases are shown
                    string errorMessage = "";
                    StringBuilder message = new StringBuilder();

                    switch (returnCode)
                    {
                        case 0: errorMessage = "Reply document(s) retrieved successfully\n"+"Number of documents: "+rows+"\n\n";
                            if (replyDocumentVOs != null)
                            {
                                for (int i = 0; i < replyDocumentVOs.Count(); i++)
                                {
                                    message.AppendLine(Environment.NewLine + (i + 1).ToString() + ".");
                                    String type = (string)replyDocumentVOs[i].SelectToken("@type");
                                    message.AppendLine("type :" + type);
                                    String createdBy = (string)replyDocumentVOs[i].SelectToken("createdBy");
                                    message.AppendLine("createdBy :" + createdBy);
                                    String dataFileId = (string)replyDocumentVOs[i].SelectToken("dataFileId");
                                    message.AppendLine("dataFileId :" + dataFileId);
                                    String dateCreated = (string)replyDocumentVOs[i].SelectToken("dateCreated");
                                    message.AppendLine("dateCreated :" + dateCreated);
                                    String dateLastUpdated = (string)replyDocumentVOs[i].SelectToken("dateLastUpdated");
                                    message.AppendLine("dateLastUpdated :" + dateLastUpdated);
                                    String hashValue = (string)replyDocumentVOs[i].SelectToken("hashValue");
                                    message.AppendLine("hashValue :" + hashValue);
                                    String isDownloadable = (string)replyDocumentVOs[i].SelectToken("isDownloadable");
                                    message.AppendLine("isDownloadable :" + isDownloadable);
                                    String lastUpdatedBy = (string)replyDocumentVOs[i].SelectToken("lastUpdatedBy");
                                    message.AppendLine("lastUpdatedBy :" + lastUpdatedBy);
                                    String name = (string)replyDocumentVOs[i].SelectToken("name");
                                    message.AppendLine("name :" + name);
                                    String replyDocumentId = (string)replyDocumentVOs[i].SelectToken("replyDocumentId");
                                    message.AppendLine("replyDocumentId :" + replyDocumentId);
                                    String size = (string)replyDocumentVOs[i].SelectToken("size");
                                    message.AppendLine("size :" + size);
                                    //String replyId = (string)replyDocumentVOs[i].SelectToken("replyId");
                                    message.AppendLine("replyId :" + replyId);
                                    String status = (string)replyDocumentVOs[i].SelectToken("status");
                                    message.AppendLine("status :" + status);
                                }
                            }
                            break;
                        case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                        case -2: errorMessage = " ReplyDocument not found."; break;
                        case -99: errorMessage = "System error occurred."; break;
                        default: errorMessage = "Failed to retrieve reply documents."; break;
                    }
                    Console.Out.WriteLine("\n"+errorMessage);
                    Console.Out.WriteLine(message.ToString());
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from getReplyDocuments() method: " + e.Message);
            }
        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/
    }
}