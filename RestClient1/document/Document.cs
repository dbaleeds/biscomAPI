using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace RestClient1.document
{
    class Document : BDSRESTClientBase
    {
        public Document(string session)
            : base(session)
        {

        }

        /// <summary>
        /// Gets the document.
        /// </summary>
        /// <param name="documentId">The document identifier.</param>
        /// <param name="calculateHashIfNeeded">The calculate hash if needed.</param>
        public GetDocumentOutputWS getDocument(string documentId, string calculateHashIfNeeded)
        {
            RestRequest request = new RestRequest("getDocument", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("documentId", documentId);
            request.AddParameter("calculateHashIfNeeded", calculateHashIfNeeded);

            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //Util.log("getDocument", response.Content.ToString());
                GetDocumentOutputWS output = new GetDocumentOutputWS();
                //output = JsonConvert.DeserializeObject<GetDocumentOutputWS>(response.Content);
                //int returnCode = output.returnCode;

                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));
                int totalRowCount = Convert.ToInt32((string)o.SelectToken("totalRowCount"));
                var documentVO = o.SelectToken("documentVO");

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0: errorMessage = "Document retrieved successfully" + "\n\n";
                        if (documentVO != null)
                        {
                            String status = (string) ((documentVO.SelectToken("status") == null) ? "<null>" : documentVO.SelectToken("status"));
                            String name = (string)((documentVO.SelectToken("name") == null) ? "<null>" : documentVO.SelectToken("name"));
                            String description = (string)((documentVO.SelectToken("description") == null) ? "<null>" : documentVO.SelectToken("description"));
                            long size = Convert.ToInt64((string)((documentVO.SelectToken("size") == null) ? "0" : documentVO.SelectToken("size")));
                            int directoryId = Convert.ToInt32((string)((documentVO.SelectToken("directoryId") == null) ? "0" : documentVO.SelectToken("directoryId")));
                            int dataFileId = Convert.ToInt32((string)((documentVO.SelectToken("dataFileId") == null) ? "0" : documentVO.SelectToken("dataFileId")));
                            int createdBy = Convert.ToInt32((string)((documentVO.SelectToken("createdBy") == null) ? "0" : documentVO.SelectToken("createdBy")));
                            DateTime dateCreated = Convert.ToDateTime((string)((documentVO.SelectToken("dateCreated") == null) ? "0" : documentVO.SelectToken("dateCreated")));
                            int lastUpdatedBy = Convert.ToInt32((string)((documentVO.SelectToken("lastUpdatedBy") == null) ? "0" : documentVO.SelectToken("lastUpdatedBy")));
                            DateTime dateLastUpdated = Convert.ToDateTime((string)((documentVO.SelectToken("dateLastUpdated") == null) ? "0" : documentVO.SelectToken("dateLastUpdated")));
                            int displayOrder = Convert.ToInt32((string)((documentVO.SelectToken("displayOrder") == null) ? "0" : documentVO.SelectToken("displayOrder")));
                            Boolean isDownloadable = Convert.ToBoolean((string)((documentVO.SelectToken("isDownloadable") == null) ? "false" : documentVO.SelectToken("isDownloadable")));
                            Boolean isEncrypted = Convert.ToBoolean((string)((documentVO.SelectToken("isEncrypted") == null) ? "false" : documentVO.SelectToken("isEncrypted")));
                            String hashValue = (string)((documentVO.SelectToken("hashValue") == null) ? "<null>" : documentVO.SelectToken("hashValue"));
                            String lastScanStatus = (string)((documentVO.SelectToken("lastScanStatus") == null) ? "<null>" : documentVO.SelectToken("lastScanStatus"));
                            String fileDownloadLinks = (string)((documentVO.SelectToken("lastScanStatus") == null) ? "<null>" : documentVO.SelectToken("lastScanStatus"));
                            DocumentVOWS documentVOWS = new DocumentVOWS(Convert.ToInt32(documentId), status, name, description, size, directoryId, 
                                dataFileId, createdBy, dateCreated, lastUpdatedBy, dateLastUpdated, displayOrder, isDownloadable, isEncrypted, hashValue, 
                                lastScanStatus, fileDownloadLinks);
                            output = new GetDocumentOutputWS(returnCode, documentVOWS);
                            errorMessage = errorMessage + output.toString();
                        }
                        break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "Document not found."; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Couldn't retrieve document."; break;
                }
                Console.Out.WriteLine(errorMessage);
                return output;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception occured from getDocument() method: " + e.Message);
                return null;
            }
        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the documents.
        /// </summary>
        /// <param name="directoryId">The directory identifier.</param>
        /// <param name="includeDeletedItems">Include deleted items or not.</param>
        public void getDocuments(string directoryId, string includeDeletedItems)
        {
            RestRequest request = new RestRequest("getDocuments", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("directoryId", directoryId);
            request.AddParameter("includeDeletedItems", includeDeletedItems);

            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);

                string json = response.Content.ToString();
                //Util.log("getDocuments", json);

                JObject o = JObject.Parse(json);
                string totalRowCount = (string)o.SelectToken("totalRowCount");
                int rows = Convert.ToInt32(totalRowCount);
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));
                var documentVOs = o.SelectToken("documentVOs");
                if (rows == 0)
                {
                    Console.Out.WriteLine("\nNo documents found.");
                }

                else
                {
                    if (rows == 1)
                    {
                        json = "{\"documentVOs\":[" + documentVOs.ToString() + "] ,\"returnCode\":\"" + (string)o.SelectToken("returnCode") + "\",\"totalRowCount\":\"" + (string)o.SelectToken("totalRowCount") + "\"}";
                        JObject j = JObject.Parse(json);
                        documentVOs = j.SelectToken("documentVOs");
                    }

                    //GetDocumentsOutputWS output = new GetDocumentsOutputWS();
                    //output = JsonConvert.DeserializeObject<GetDocumentsOutputWS>(json);
                    //int returnCode = output.returnCode;


                    //Message according to the return code. Only most frequent cases are shown
                    string errorMessage = "";
                    StringBuilder message = new StringBuilder();
                    switch (returnCode)
                    {
                        case 0: errorMessage = "Documents retrieved successfully" + "\n" + "Number of documents retrieved: " + totalRowCount + "\n\n";
                            if (documentVOs != null)
                            {
                                for (int i = 0; i < documentVOs.Count(); i++)
                                {
                                    message.AppendLine(Environment.NewLine + (i + 1).ToString() + ".");
                                    String name = (string)documentVOs[i].SelectToken("name");
                                    message.AppendLine("Document Name :" + name);
                                    String size = (string)documentVOs[i].SelectToken("size");
                                    message.AppendLine("Size :" + size);
                                    String dateCreated = (string)documentVOs[i].SelectToken("dateCreated");
                                    message.AppendLine("Date created :" + dateCreated);
                                    String createdBy = (string)documentVOs[i].SelectToken("createdBy");
                                    message.AppendLine("Created By :" + createdBy);
                                    String dataFileId = (string)documentVOs[i].SelectToken("dataFileId");
                                    message.AppendLine("Date file ID :" + dataFileId);
                                    String documentId = (string)documentVOs[i].SelectToken("documentId");
                                    message.AppendLine("Document ID :" + documentId);
                                    String status = (string)documentVOs[i].SelectToken("status");
                                    message.AppendLine("Status :" + status);
                                }
                            }
                            else
                            {
                                message.AppendLine("No documents found");
                            }
                            break;
                        case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                        case -2: errorMessage = "Document not found."; break;
                        case -99: errorMessage = "System error occurred."; break;
                        default: errorMessage = "Couldn't retrieve documents."; break;
                    }
                    Console.Out.WriteLine(errorMessage);
                    Console.Out.WriteLine(message.ToString());
                }

            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception occured from getDocuments() method: " + e.Message);
            }
        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Edits the document.
        /// </summary>
        /// <param name="documentId">The document identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        public void editDocument(string documentId, string name, string description)
        {
            RestRequest request = new RestRequest("editDocument", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("documentId", documentId);
            request.AddParameter("name", name);
            request.AddParameter("description", description);

            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                
                //EditDocumentOutputWS output = new EditDocumentOutputWS();
                //output = JsonConvert.DeserializeObject<EditDocumentOutputWS>(response.Content);
                //int returnCode = output.returnCode;

                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0: errorMessage = "Documents edited successfully."; break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "Document with same name already exists."; break;
                    case -3: errorMessage = "Document not found."; break;
                    case -4: errorMessage = "Blocked file extension"; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Couldn't edit document."; break;
                }
                Console.Out.WriteLine(errorMessage);
            }


            catch (Exception e)
            {
                Console.Out.WriteLine("Exception occured from editDocument() method: " + e.Message);
            }
        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Deletes the document.
        /// </summary>
        /// <param name="documentId">The document identifier.</param>
        public void deleteDocument(string documentId)
        {
            RestRequest request = new RestRequest("deleteDocument", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("documentId", documentId);

            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //DeleteDocumentOutputWS output = new DeleteDocumentOutputWS();
                //output = JsonConvert.DeserializeObject<DeleteDocumentOutputWS>(response.Content);
                //int returnCode = output.returnCode;
                
                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0: errorMessage = "Document deleted successfully."; break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "Document not found."; break;
                    case -3: errorMessage = "Document is frozen."; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Couldn't delete document."; break;
                }
                Console.Out.WriteLine(errorMessage);
            }


            catch (Exception e)
            {
                Console.Out.WriteLine("Exception occured from deleteDocument() method: " + e.Message);
            }
        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/
    }
}
