using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using Newtonsoft.Json;
using System.IO;
using RestClient1.dataFile;
using Newtonsoft.Json.Linq;

namespace RestClient1
{
    class DataFile : BDSRESTClientBase
    {
        public DataFile(string session)
            : base(session)
        {
        }

        /// <summary>
        /// Initiates the data file upload.
        /// </summary>
        /// <param name="uploadFileSize">Size of the upload file.</param>
        public InitiateDataFileUploadOutputWS initiateDataFileUpload(long uploadFileSize)
        {
            RestRequest request = new RestRequest("initiateDataFileUpload", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("uploadFileSize", uploadFileSize);


            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                InitiateDataFileUploadOutputWS output = new InitiateDataFileUploadOutputWS();
                //output = JsonConvert.DeserializeObject<InitiateDataFileUploadOutputWS>(response.Content);
                //int returnCode = output.returnCode;
                
                string json = response.Content.ToString();
                JObject o = JObject.Parse(json);
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0:
                        output.dataFileId = Convert.ToInt32((string)o.SelectToken("dataFileId"));
                        output.chunkSize = Convert.ToInt32((string)o.SelectToken("chunkSize"));
                        output.returnCode = returnCode;
                        errorMessage = "Successfully initiated data file upload.\n"
                        + "dataFileId: " + output.dataFileId + "\n"
                        + "chunkSize: " + output.chunkSize + "\n"
                        ; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Failed to initiate data file upload."; break;

                }
                Console.Out.WriteLine("Return Code: " + returnCode + ". " + errorMessage);
                return output;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from InitiateDataFileUpload() method: " + e.Message);
                return null;
            }
        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Updates the data file.
        /// </summary>
        /// <param name="dataFileId">The data file identifier.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="length">The length.</param>
        /// <param name="sourceIS">The source is.</param>
        /// <returns></returns>
        public UpdateDataFileUploadOutputWS updateDataFileUpload(int dataFileId, int offset, int length, byte[] sourceIS, string fileName)
        {
            RestRequest request = new RestRequest("updateDataFileUpload", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("dataFileId", dataFileId);
            request.AddParameter("offset", offset);
            request.AddParameter("length", length);
            //request.AddParameter("sourceIS", sourceIS);
            //request.AddParameter("", sourceIS, ParameterType.RequestBody);
            request.AddFile("fileName", sourceIS, "");

            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                UpdateDataFileUploadOutputWS output = new UpdateDataFileUploadOutputWS();
                //output = JsonConvert.DeserializeObject<UpdateDataFileUploadOutputWS>(response.Content);
                //int returnCode = output.returnCode;

                string json = response.Content.ToString();
                JObject o = JObject.Parse(json);
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0:
                        output.returnCode = returnCode;
                        errorMessage = "Successfully updated data file upload.\n"; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Failed to update data file upload."; break;
                }
                Console.Out.WriteLine("Return Code: " + returnCode + ". " + errorMessage);
                return output;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception occured from updateDataFileUpload() method: " + e.Message);
                return null;
            }
        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Completes the data file upload.
        /// </summary>
        /// <param name="dataFileId">The data file identifier.</param>
        /// <returns></returns>
        public CompleteDataFileUploadOutputWS completeDataFileUpload(int dataFileId)
        {
            RestRequest request = new RestRequest("completeDataFileUpload", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("dataFileId", dataFileId);

            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                CompleteDataFileUploadOutputWS output = new CompleteDataFileUploadOutputWS();
                //output = JsonConvert.DeserializeObject<CompleteDataFileUploadOutputWS>(response.Content);
                //int returnCode = output.returnCode;
                //Util.log("DataFile.completeDataFileUpload", response.Content.ToString());

                string json = response.Content.ToString();
                JObject o = JObject.Parse(json);
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0:
                        output.returnCode = returnCode;
                        var dfvows = o.SelectToken("dataFileVO");
                        output.DataFileVO = dfvows.ToObject<DataFileVOWS>();
                        output.ScanRequestId = Convert.ToInt32((string)o.SelectToken("scanRequestId"));
                        errorMessage = "Successfully completed data file upload.\n"; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Failed to complete data file upload."; break;
                }
                Console.Out.WriteLine("Return Code: " + returnCode + ". " + errorMessage);
                return output;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception occured from completeDataFileUpload() method: " + e.Message);
                return null;
            }
        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the data file chunk Input Stream.
        /// </summary>
        /// <param name="dataFileId">The data file identifier.</param>
        /// <param name="referenceDocumentId">The reference document identifier.</param>
        /// <param name="referenceDocumentType">Type of the reference document.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="chunkSize">Size of the chunk.</param>
        /// <param name="checksumFlag">if set to <c>true</c> [checksum flag].</param>
        /// <param name="downloadLocation">The file download location.</param>
        /// <returns></returns>
        public GetDataFileChunkISOutputWS getDataFileChunkIS(int dataFileId, int referenceDocumentId, int referenceDocumentType, long offset, int chunkSize, Boolean checksumFlag, string downloadLocation)
        {
            RestRequest request = new RestRequest("getDataFileChunkIS", Method.POST);

            request.AddHeader("Accept", "multipart/form-data");
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("dataFileId", dataFileId);
            request.AddParameter("referenceDocumentId", referenceDocumentId);
            request.AddParameter("referenceDocumentType", referenceDocumentType);
            request.AddParameter("offset", offset);
            request.AddParameter("chunkSize", chunkSize);
            request.AddParameter("checksumFlag", checksumFlag);


            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                string json = response.Headers.ElementAt(0).Value.ToString();

                GetDataFileChunkISOutputWS output = new GetDataFileChunkISOutputWS();
                output = JsonConvert.DeserializeObject<GetDataFileChunkISOutputWS>(json);
                int returnCode = output.returnCode;

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0: errorMessage = "Successfully retrieved data file chunk IS.\n";
                        
                        /*
                        for (int i = 0; i < response.Headers.Count; i++)
                        {
                            errorMessage = errorMessage + Environment.NewLine + response.Headers.ElementAt(i).Name.ToString() + ": " + response.Headers.ElementAt(i).Value.ToString();
                        }*/
                        
                        // Append the response stream to the specified location
                        byte[] byteArray = response.RawBytes;
                        MemoryStream stream = new MemoryStream(byteArray);
                        CopyStream(stream, downloadLocation);
                        break;
                    case -1: errorMessage = "Requester doesn't have sufficient privileges."; break;
                    case -2: errorMessage = "Data File not found"; break;
                    case -3: errorMessage = "Invalid chunk size"; break;
                    case -4: errorMessage = "Invalid offset"; break;

                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Failed to retrieve data file chunk IS."; break;
                }
                Console.Out.WriteLine("Return Code: " + returnCode + ". " + errorMessage);
                return output;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception occured from getDataFileChunkIS() method: " + e.Message);
                return null;
            }

        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Copies the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="destPath">The dest path.</param>
        public void CopyStream(Stream stream, string destPath)
        {
            using (var fileStream = new FileStream(destPath, FileMode.Append, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }
        }
    }
}
