using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestClient1.package;
using System.Text.RegularExpressions;
using System.IO;

namespace RestClient1
{
    class Package : BDSRESTClientBase
    {
        public Package(string session)
            : base(session)
        {

        }

        /// <summary>
        /// Adds a package.
        /// </summary>
        /// <param name="name">The name of the package.</param>
        /// <param name="description">The description.</param>
        /// <param name="label">The label.</param>
        /// <param name="owners">The owners.</param>
        /// <param name="senders">The senders.</param>
        /// <param name="autoDelDate">The automatic deletion date.</param>
        /// <param name="autoDelReminderDate">The automatic deletion reminder date.</param>
        /// <param name="fileList">The file list.</param>
        public void addPackage(string name, string description, string label, string owners, string senders, string autoDelDate, string autoDelReminderDate, List<MyFile> fileList)
        {
            RestRequest request = new RestRequest("addPackage", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("name", name);
            request.AddParameter("description", description);
            request.AddParameter("label", label);
            request.AddParameter("owners", owners);
            request.AddParameter("senders", senders);
            request.AddParameter("autoDelDate", autoDelDate);
            request.AddParameter("autoDelReminderDate", autoDelReminderDate);

            if (fileList != null && fileList.Count() > 0) // If fileList is not empty
            {
                // Adds all the files to request
                foreach (MyFile myFile in fileList)
                {
                    request.AddFile(myFile.fileName, myFile.filePath);
                }
            }

            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                System.IO.File.WriteAllText(@"C:\Users\Raine\Desktop\output.txt", response.Content.ToString());
                //AddPackageOutputWS output = new AddPackageOutputWS();
                //output = JsonConvert.DeserializeObject<AddPackageOutputWS>(response.Content);
                //int returnCode = output.returnCode;

                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0: errorMessage = "Package created successfully"; break;
                    case 1: errorMessage = "Package created successfully. Warning: Owner not accepted."; break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "Package with the same name already exists."; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Package creation unsuccessful."; break;
                }
                Console.Out.WriteLine("Return code: " + returnCode + ". " + errorMessage);

            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from addPackage() method: " + e.Message);
            }
        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Adds documents to a package.
        /// </summary>
        /// <param name="packageId">The package identifier.</param>
        /// <param name="fileList">The file list.</param>
        public void addPackageDocuments(string packageId, List<MyFile> fileList)
        {
            RestRequest request = new RestRequest("addPackageDocuments", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("packageId", packageId);

            if (fileList != null && fileList.Count() > 0) // If fileList is not empty
            {
                // Adds all the files to request
                foreach (MyFile myFile in fileList)
                {
                    request.AddFile(myFile.fileName, myFile.filePath);
                }
            }

            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                System.IO.File.WriteAllText(@"C:\Users\Raine\Desktop\output.txt", response.Content.ToString());
                
                //AddPacakageDocumentsOutputWS output = new AddPacakageDocumentsOutputWS();
                //output = JsonConvert.DeserializeObject<AddPacakageDocumentsOutputWS>(response.Content);
                //int returnCode = output.returnCode;

                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0: errorMessage = "Added documents successfully"; break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "Document already exists."; break;
                    case -3: errorMessage = "Directory nor found!"; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Adding documents to the package unsuccessful."; break;
                }
                Console.Out.WriteLine("Return code: " + returnCode + ". " + errorMessage);

            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from addPackageDocuments() method: " + e.Message);
            }

        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Deletes a package.
        /// </summary>
        /// <param name="packageId">The package identifier.</param>
        public void deletePackage(string packageId)
        {
            RestRequest request = new RestRequest("deletePackage", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("packageId", packageId);

            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //DeletePackageOutputWS output = new DeletePackageOutputWS();
                //output = JsonConvert.DeserializeObject<DeletePackageOutputWS>(response.Content);
                //int returnCode = output.returnCode;
                
                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0: errorMessage = "Package deleted successfully"; break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "Package not found."; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Package deletion unsuccessfull."; break;
                }
                Console.Out.WriteLine("Return code: " + returnCode + ". " + errorMessage);

            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from deletePackageDocuments() method: " + e.Message);
            }

        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Edits a package.
        /// </summary>
        /// <param name="packageId">The package identifier.</param>
        /// <param name="packageName">Name of the package.</param>
        /// <param name="description">The description.</param>
        /// <param name="label">The label.</param>
        /// <param name="ownerEmails">The owner emails.</param>
        /// <param name="senderEmails">The sender emails.</param>
        /// <param name="autoPackDel">The automatic pack delete.</param>
        /// <param name="autoPackDelReminder">The automatic pack delete reminder.</param>
        public void editPackage(string packageId, string packageName, string description, string label, string ownerEmails, string senderEmails, string autoPackDel, string autoPackDelReminder)
        {
            RestRequest request = new RestRequest("editPackage", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("packageId", packageId);
            request.AddParameter("packageName", packageName);
            request.AddParameter("description", description);
            request.AddParameter("label", label);
            request.AddParameter("ownerEmails", ownerEmails);
            request.AddParameter("senderEmails", senderEmails);
            request.AddParameter("autoPackDel", autoPackDel);
            request.AddParameter("autoPackDelReminder", autoPackDelReminder);

            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);

                //EditPackageOutputWS output = new EditPackageOutputWS();
                //output = JsonConvert.DeserializeObject<EditPackageOutputWS>(response.Content);
                //int returnCode = output.returnCode;
                
                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0: errorMessage = "Package edited successfully"; break;
                    case 1: errorMessage = "Package edited with warning! Owner not accepted."; break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case 2: errorMessage = "Requester is no longer a package owner."; break;
                    case -2: errorMessage = "Package not found."; break;
                    case -3: errorMessage = "Cannot remove all package owners."; break;
                    case -4: errorMessage = "Parameter value is not valid."; break;
                    case -5: errorMessage = "One of the package's delivery expire date is after package auto deletion date ."; break;
                    case -6: errorMessage = "Package delete reminder date is after auto delete date."; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Package edition unsuccessfull."; break;
                }
                Console.Out.WriteLine("Return code: " + returnCode + ". " + errorMessage);

            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from editPackage() method: " + e.Message);
            }

        }

        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets a package.
        /// </summary>
        /// <param name="packageId">The package identifier.</param>
        public void getPackage(string packageId)
        {
            RestRequest request = new RestRequest("getPackage", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("packageId", packageId);

            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                
                //GetPackageOutputWS output = new GetPackageOutputWS();
                //output = JsonConvert.DeserializeObject<GetPackageOutputWS>(response.Content);
                //int returnCode = output.returnCode;
                //System.IO.File.WriteAllText(@"C:\Users\Raine\Desktop\output.txt", response.Content.ToString());

                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));

                //Message according to the return code. Only most frequent cases are shown
                StringBuilder message = new StringBuilder();
                switch (returnCode)
                {
                    case 0:
                        message.AppendLine("The package is retrieved successfully.");
                        var extPackageVOJSON = o.SelectToken("extPackageVO");
                        if (extPackageVOJSON != null)
                        {
                            message.AppendLine("Package VO : ");
                            ExtPackageVOWS packageVOWS = extPackageVOJSON.ToObject<ExtPackageVOWS>();
                            message.AppendLine(packageVOWS.toString());
                        }

                        break;
                    case -1: message.AppendLine("Requester does not have sufficient privileges."); break;
                    case -2: message.AppendLine("Package not found."); break;
                    case -99: message.AppendLine("System error occurred."); break;
                    default: message.AppendLine("Couldn't retrieve package."); break;
                }
                Console.Out.WriteLine("Return code: " + returnCode + ". " + message.ToString());

            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from getPackage() method: " + e.Message);
            }

        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Gets the package deliveries.
        /// </summary>
        /// <param name="packageId">The package identifier.</param>
        public void getPackageDeliveries(string packageId)
        {
            RestRequest request = new RestRequest("getPackageDeliveries", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("packageId", packageId);

            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                System.IO.File.WriteAllText(@"C:\Users\Raine\Desktop\output.txt", response.Content.ToString());
                string json = response.Content;

                JObject o = JObject.Parse(json);
                string totalRowCount = (string)o.SelectToken("totalRowCount");
                int rows = Convert.ToInt32(totalRowCount);

                if (rows == 0)
                {
                    Console.Out.WriteLine("\nNo deliveries found in the package.");
                }

                else
                {
                    if (rows == 1)
                    {
                        JObject deliveryVOs = (JObject)o.SelectToken("deliveryVOs");
                        json = "{\"deliveryVOs\":[" + deliveryVOs.ToString() + "] ,\"returnCode\":\"" + (string)o.SelectToken("returnCode") + "\",\"totalRowCount\":\"" + (string)o.SelectToken("totalRowCount")+"\"}";
                        //System.IO.File.AppendAllText(@"C:\json.txt", json + Environment.NewLine);
                    }
                    
                    GetPackageDeliveriesOutputWS output = new GetPackageDeliveriesOutputWS();
                    output = JsonConvert.DeserializeObject<GetPackageDeliveriesOutputWS>(json);
                    int returnCode = output.returnCode;

                    //Message according to the return code. Only most frequent cases are shown
                    string errorMessage = "";
                    switch (returnCode)
                    {
                        case 0:
                            {
                                foreach (DeliveryVOWS delivery in output.deliveryVOs)
                                {
                                    errorMessage = errorMessage + "\n" + delivery.toString();
                                }
                            }; break;
                        case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                        case -2: errorMessage = "Package not found."; break;
                        case -99: errorMessage = "System error occurred."; break;
                        default: errorMessage = "Couldn't retrieve package deliveries."; break;
                    }
                    Console.Out.WriteLine("Return code: " + returnCode + ". " + errorMessage);
                }

            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from getPackageDeliveries() method: " + e.Message + " Or No deliveries found in this package.");
            }

        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Gets the package owners.
        /// </summary>
        /// <param name="packageId">The package identifier.</param>
        public void getPackageOwners(string packageId)
        {
            RestRequest request = new RestRequest("getPackageOwners", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("packageId", packageId);

            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);

                string json = response.Content.ToString();

                JObject o = JObject.Parse(json);
                string totalRowCount = (string)o.SelectToken("totalRowCount");
                int rows = Convert.ToInt32(totalRowCount);
                //System.IO.File.AppendAllText(@"G:\Projects\RestClient1\log.txt", "No of owners: " + rows + " JSON: " + json+Environment.NewLine);

                if (rows == 1)
                {
                    JObject owners = (JObject)o.SelectToken("owners");
                    //string str = Regex.Replace(owners.ToString(), @"\s+", "");
                    //json = json.Replace(str, "[" + str + "]");
                    json = "{\"owners\":[" + owners.ToString() + "] ,\"returnCode\":\"" + (string)o.SelectToken("returnCode") + "\",\"totalRowCount\":\"" + (string)o.SelectToken("totalRowCount") + "\"}";
                }

                GetPackageOwnersOutputWS output = new GetPackageOwnersOutputWS();
                output = JsonConvert.DeserializeObject<GetPackageOwnersOutputWS>(json);
                int returnCode = output.returnCode;

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0:
                        {
                            errorMessage = "Got package owners successfully.\nNumber of package owners: "+output.totalRowCount+"\n";
                            foreach (UserVOWS owner in output.Owners)
                            {
                                errorMessage = errorMessage + "\n" + owner.toString();
                            }
                        }; break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "Package not found."; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Couldn't retrieve package owners."; break;
                }
                Console.Out.WriteLine("\nReturn code: " + returnCode);
                Console.Out.WriteLine(errorMessage);


            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from getPackageOwners() method: " + e.Message);
            }

        }

        /*---------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Gets the package senders.
        /// </summary>
        /// <param name="packageId">The package identifier.</param>
        public void getPackageSenders(string packageId)
        {
            RestRequest request = new RestRequest("getPackageSenders", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("packageId", packageId);

            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);

                string json = response.Content.ToString();

                JObject o = JObject.Parse(json);
                string totalRowCount = (string)o.SelectToken("totalRowCount");
                int rows = Convert.ToInt32(totalRowCount);

                if (rows == 1)
                {
                    JObject senders = (JObject)o.SelectToken("senders");
                    json = "{\"senders\":[" + senders.ToString() + "] ,\"returnCode\":\"" + (string)o.SelectToken("returnCode") + "\",\"totalRowCount\":\"" + (string)o.SelectToken("totalRowCount") + "\"}";
                }

                GetPackageSendersOutputWS output = new GetPackageSendersOutputWS();
                output = JsonConvert.DeserializeObject<GetPackageSendersOutputWS>(json);
                int returnCode = output.returnCode;

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0:
                        {
                            errorMessage = "Got package senders successfully.\nNumber of senders: "+output.totalRowCount+"\n";
                            foreach (UserVOWS owner in output.Senders)
                            {
                                errorMessage = errorMessage + "\n" + owner.toString();
                            }
                        }; break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "Package not found."; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Couldn't retrieve package senders."; break;
                }
                Console.Out.WriteLine("\nReturn code: " + returnCode);
                Console.Out.WriteLine(errorMessage);


            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from getPackageSenders() method: " + e.Message);
            }

        }

        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the packages of a user.
        /// </summary>
        public void getUserPackages()
        {
            String contextName = "Package.getUserPackages()";
            RestRequest request = new RestRequest("getUserPackages", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //Util.log(contextName, response.Content.ToString());
                
                //GetUserPackagesOutputWS output = new GetUserPackagesOutputWS();
                //output = JsonConvert.DeserializeObject<GetUserPackagesOutputWS>(response.Content);
                //int returnCode = output.returnCode;

                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));
                int totalRowCount = Convert.ToInt32((string)o.SelectToken("totalRowCount"));

                //Message according to the return code. Only most frequent cases are shown
                string message = "";
                switch (returnCode)
                {
                    case 0:
                        {
                            // If the user has no packages
                            if (totalRowCount < 1)
                            {
                                message = "The user has no packages.";
                            }

                            else
                            {
                                message = "Got user packages successfully.\n";


                                var extPackageVOJSON = o.SelectToken("extPackageVOWss");
                                if (extPackageVOJSON != null)
                                {
                                    // If the user has one package
                                    if (totalRowCount == 1)
                                    {
                                        ExtPackageVOWS packageVOWS = extPackageVOJSON.ToObject<ExtPackageVOWS>();
                                        message = message + "\n" + packageVOWS.toString();
                                    }

                                    // If the user has multiple packages
                                    else
                                    {
                                        List<ExtPackageVOWS> extPackageVOWss = JsonConvert.DeserializeObject<List<ExtPackageVOWS>>(extPackageVOJSON.ToString());
                                        foreach (ExtPackageVOWS package in extPackageVOWss)
                                        {
                                            message = message + "\n" + package.toString();
                                        }
                                    }
                                }
                            }

                        }; break;
                    case -1: message = "Requester does not have sufficient privileges."; break;
                    case -2: message = "User not found."; break;
                    case -99: message = "System error occurred."; break;
                    default: message = "Couldn't retrieve packages of the user."; break;
                }
                Console.Out.WriteLine("\nReturn code: " + returnCode);
                Console.Out.WriteLine(message);


            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from getUserPackages() method: " + e.Message);
            }

        }

        /*---------------------------------------------------------------------------------------------------------------------------------*/
    }
}
