using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using Newtonsoft.Json;
using System.IO;
using RestClient1.delivery;
using Newtonsoft.Json.Linq;

namespace RestClient1
{
    /**
     * This class demonstrates the "Delivery" related web services. It extends BDSRESTClientBase class      
     */
    class Delivery : BDSRESTClientBase
    {

        //Constructs an object with a sessionId and a client
        public Delivery(string session)
            : base(session)
        {

        }

        /// <summary>
        /// Adds the express delivery.
        /// </summary>
        /// <param name="DeliveryTo">The delivery to.</param>
        /// <param name="DeliveryCc">The delivery cc.</param>
        /// <param name="DeliveryBcc">The delivery BCC.</param>
        /// <param name="DeliveryName">Name of the delivery.</param>
        /// <param name="requireSignIn">The require sign in.</param>
        /// <param name="DeliveryDesc">The delivery desc.</param>
        /// <param name="SecureMessage">The secure message.</param>
        /// <param name="Message">The message.</param>
        /// <param name="sendNotificationEmail">The send notification email.</param>
        /// <param name="notifyWhenRecipientDeletes">The notify when recipient deletes.</param>
        /// <param name="notifyOnDeliveryViewSetting">The notify on delivery view setting.</param>
        /// <param name="notifyOnFileDownloadSetting">The notify on file download setting.</param>
        /// <param name="autoPackageDeletionDate">The automatic package deletion date.</param>
        /// <param name="autoPackageDelReminderDate">The automatic package delete reminder date.</param>
        /// <param name="fileList">The file list.</param>
        /// <param name="allowCollaboration">The allow collaboration.</param>
        /// <param name="deliveryDateExpires">The delivery date expires.</param>
        
        public void addExpressDelivery(String DeliveryTo, String DeliveryCc, String DeliveryBcc, String DeliveryName, String requireSignIn,
            String SecureMessage, String Message, String sendNotificationEmail, String notifyWhenRecipientDeletes,
            String notifyOnDeliveryViewSetting, String notifyOnFileDownloadSetting, String autoPackageDeletionDate, String autoPackageDelReminderDate,
            List<MyFile> fileList, String allowCollaboration, String deliveryDateExpires, String password, String notificationEmailList)
        {

            RestRequest request = new RestRequest("addExpressDelivery", Method.POST);
            
            request.AlwaysMultipartFormData = true;
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("deliveryTo", DeliveryTo);
            request.AddParameter("deliveryCc", DeliveryCc);
            request.AddParameter("deliveryBcc", DeliveryBcc);
            request.AddParameter("deliveryName", DeliveryName);
            request.AddParameter("requireSignIn", requireSignIn);
            request.AddParameter("secureMessage", SecureMessage);
            request.AddParameter("message", Message);
            request.AddParameter("notificationEmailList", notificationEmailList);
            request.AddParameter("sendNotificationEmail", sendNotificationEmail);
            request.AddParameter("notifyWhenRecipientDeletes", notifyWhenRecipientDeletes);
            request.AddParameter("notifyOnDeliveryViewSetting", notifyOnDeliveryViewSetting);
            request.AddParameter("notifyOnFileDownloadSetting", notifyOnFileDownloadSetting);
            request.AddParameter("autoPackageDeletionDate", autoPackageDeletionDate);
            request.AddParameter("autoPackageDelReminderDate", autoPackageDelReminderDate);
            request.AddParameter("allowCollaboration", allowCollaboration);
            request.AddParameter("deliveryDateExpires", deliveryDateExpires);
            request.AddParameter("deliveryPassword1", password);

            if (fileList.Count() > 0) // If fileList is not empty
            {
                
                // Adds all the files to request
                foreach (MyFile myFile in fileList)
                {
                    if (File.Exists(myFile.filePath))
                    {
                        request.AddFile(myFile.fileName, myFile.filePath);
                    }
                    else
                    {
                        Console.Out.WriteLine("Couldn't find the file " + myFile.fileName);
                    }
                    
                }
            }
            


            // execute the request            
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //Util.log("addExpressDelivery", response.Content.ToString());
                
                /*AddExpressDeliveryOutputWS output = new AddExpressDeliveryOutputWS();
                output = JsonConvert.DeserializeObject<AddExpressDeliveryOutputWS>(response.Content);
                int returnCode = output.ReturnCode;*/
                
                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));

                //Message according to the return code. Only most frequent cases are shown
                switch (returnCode)
                {
                    case 0: Console.Out.WriteLine("Add express delivery successful"); break;
                    case -1: Console.Out.WriteLine("Requester does not have sufficient privileges."); break;
                    case -10: Console.Out.WriteLine("Package was not added."); break;
                    case -6: Console.Out.WriteLine("DataFile not valid"); break;
                    case -99: Console.Out.WriteLine("System error occurred."); break;
                    default: Console.Out.WriteLine("Add express delivery unsuccessful."); break;
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from addExpressDelivery() method: " + e.Message);
            }

        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Adds the express delivery with data file identifier.
        /// </summary>
        /// <param name="deliveryTo">The delivery to.</param>
        /// <param name="deliveryCc">The delivery cc.</param>
        /// <param name="deliveryBcc">The delivery BCC.</param>
        /// <param name="deliveryName">Name of the delivery.</param>
        /// <param name="requireSignInStr">The require sign in string.</param>
        /// <param name="dataFileIdList">The data file identifier list.</param>
        /// <param name="docNameList">The document name list.</param>
        /// <param name="secureMessage">The secure message.</param>
        /// <param name="deliveryMessage">The delivery message.</param>
        /// <param name="sendNotificationEmailStr">The send notification email string.</param>
        /// <param name="notifyWhenRecipientDeletesStr">The notify when recipient deletes string.</param>
        /// <param name="packageAutoDeleteDateStr">The package automatic delete date string.</param>
        /// <param name="packageAutoDelReminderDateStr">The package automatic delete reminder date string.</param>
        /// <param name="deliveryDateExpiresStr">The delivery date expires string.</param>
        public void addExpressDeliveryWithDataFileId(String deliveryTo, String deliveryCc, String deliveryBcc, String deliveryName, String requireSignInStr,
            String dataFileIdList, String documentNameList, String secureMessage, String deliveryMessage, String sendNotificationEmailStr, String notifyWhenRecipientDeletesStr,
            String notifyOnDeliveryViewSetting, String notifyOnFileDownloadSetting, String packageAutoDeleteDateStr, String packageAutoDelReminderDateStr, String deliveryDateExpiresStr, String deliveryPassword1, String notificationEmailList, String allowCollaboration)
        {
            RestRequest request = new RestRequest("addExpressDeliveryWithDataFileIds", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("deliveryTo", deliveryTo);
            request.AddParameter("deliveryCc", deliveryCc);
            request.AddParameter("deliveryBcc", deliveryBcc);
            request.AddParameter("deliveryName", deliveryName);
            request.AddParameter("requireSignIn", requireSignInStr);
            request.AddParameter("dataFileIdList", dataFileIdList);
            request.AddParameter("documentNameList", documentNameList);
            request.AddParameter("secureMessage", secureMessage);
            request.AddParameter("deliveryMessage", deliveryMessage);
            request.AddParameter("sendNotificationEmail", sendNotificationEmailStr);
            request.AddParameter("notifyWhenRecipientDeletes", notifyWhenRecipientDeletesStr);
            request.AddParameter("notifyOnDeliveryViewSetting", notifyOnDeliveryViewSetting);
            request.AddParameter("notifyOnFileDownloadSetting", notifyOnFileDownloadSetting);
            request.AddParameter("autoPackageDeletionDate", packageAutoDeleteDateStr);
            request.AddParameter("autoPackageDelReminderDate", packageAutoDelReminderDateStr);
            request.AddParameter("deliveryDateExpires", deliveryDateExpiresStr);
            request.AddParameter("deliveryPassword1", deliveryPassword1);
            request.AddParameter("notificationEmailList", notificationEmailList);
            request.AddParameter("allowCollaboration", allowCollaboration);            

            // execute the request            
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //AddExpressDeliveryOutputWS output = new AddExpressDeliveryOutputWS();
                //output = JsonConvert.DeserializeObject<AddExpressDeliveryOutputWS>(response.Content);
                //int returnCode = output.ReturnCode; 
                //Util.log("addExpressDeliveryWithDataFileIds :", response.Content.ToString());

                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));
                
                switch (returnCode)
                {
                    case 0: Console.Out.WriteLine("Add express delivery successful"); break;
                    case 1: Console.Out.WriteLine("Add express delivery successful with warning, some recipients are not accepted."); break;
                    case -1: Console.Out.WriteLine("Requester does not have sufficient privileges."); break;
                    case -10: Console.Out.WriteLine("Package was not added."); break;
                    case -6: Console.Out.WriteLine("DataFile not valid"); break;
                    case -99: Console.Out.WriteLine("System error occurred."); break;
                    default: Console.Out.WriteLine("Add express delivery unsuccessful."); break;
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from addExpressDeliveryWithDataFileIds() method: " + e.Message);
            }

        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/

        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Adds the express delivery with data file identifier.
        /// </summary>
        /// <param name="deliveryTo">The delivery to.</param>
        /// <param name="deliveryCc">The delivery cc.</param>
        /// <param name="deliveryBcc">The delivery BCC.</param>
        /// <param name="deliveryName">Name of the delivery.</param>
        /// <param name="requireSignInStr">The require sign in string.</param>
        /// <param name="dataFileIdList">The data file identifier list.</param>
        /// <param name="docNameList">The document name list.</param>
        /// <param name="secureMessage">The secure message.</param>
        /// <param name="deliveryMessage">The delivery message.</param>
        /// <param name="sendNotificationEmailStr">The send notification email string.</param>
        /// <param name="notifyWhenRecipientDeletesStr">The notify when recipient deletes string.</param>
        /// <param name="notifyOnDeliveryViewSetting">The flag to notify on delivery view</param>
        /// <param name="packageAutoDeleteDateStr">The package automatic delete date string.</param>
        /// <param name="packageAutoDelReminderDateStr">The package automatic delete reminder date string.</param>
        /// <param name="deliveryDateExpiresStr">The delivery date expires string.</param>
        /// <param name="deliveryDateExpiresStr">The delivery date expires string.</param>
        /// <param name="deliveryPassword1"> The password of the delivery.</param>
        /// <param name="notificationEmailList"> The email list whom the notification should be sent.</param>
        /// <param name="allowCollaboration"> The flag to allow collaboration.</param>
        /// <param name="returnDeliveryLinks"> The flag to return the delivery links in the DeliveryVOWS.</param>
        public void addExpressDeliveryWithDataFileIdExt(String deliveryTo, String deliveryCc, String deliveryBcc, String deliveryName, String requireSignInStr,
            String dataFileIdList, String documentNameList, String secureMessage, String deliveryMessage, String sendNotificationEmailStr, String notifyWhenRecipientDeletesStr,
            String notifyOnDeliveryViewSetting, String notifyOnFileDownloadSetting, String packageAutoDeleteDateStr, String packageAutoDelReminderDateStr, 
            String deliveryDateExpiresStr, String deliveryPassword1, String notificationEmailList, String allowCollaboration, String returnDeliveryLinks)
        {
            RestRequest request = new RestRequest("addExpressDeliveryWithDataFileIdsExt", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("deliveryTo", deliveryTo);
            request.AddParameter("deliveryCc", deliveryCc);
            request.AddParameter("deliveryBcc", deliveryBcc);
            request.AddParameter("deliveryName", deliveryName);
            request.AddParameter("requireSignIn", requireSignInStr);
            request.AddParameter("dataFileIdList", dataFileIdList);
            request.AddParameter("documentNameList", documentNameList);
            request.AddParameter("secureMessage", secureMessage);
            request.AddParameter("deliveryMessage", deliveryMessage);
            request.AddParameter("sendNotificationEmail", sendNotificationEmailStr);
            request.AddParameter("notifyWhenRecipientDeletes", notifyWhenRecipientDeletesStr);
            request.AddParameter("notifyOnDeliveryViewSetting", notifyOnDeliveryViewSetting);
            request.AddParameter("notifyOnFileDownloadSetting", notifyOnFileDownloadSetting);
            request.AddParameter("autoPackageDeletionDate", packageAutoDeleteDateStr);
            request.AddParameter("autoPackageDelReminderDate", packageAutoDelReminderDateStr);
            request.AddParameter("deliveryDateExpires", deliveryDateExpiresStr);
            request.AddParameter("deliveryPassword1", deliveryPassword1);
            request.AddParameter("notificationEmailList", notificationEmailList);
            request.AddParameter("allowCollaboration", allowCollaboration);
            request.AddParameter("returnDeliveryLinks", returnDeliveryLinks);

            // execute the request            
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //System.IO.File.WriteAllText(@"G:\report.txt", response.Content);

                JObject o = JObject.Parse(response.Content.ToString());
                var deliveryVOWSJSON = o.SelectToken("deliveryVOWS");
                DeliveryVOWS deliveryVOWS = deliveryVOWSJSON.ToObject<DeliveryVOWS>();
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));
                
                //Message according to the return code. Only most frequent cases are shown
                switch (returnCode)
                {
                    case 0: Console.Out.WriteLine("Add express delivery successful");
                        //Show the delivery VO
                        Console.Out.WriteLine("DeliveryVO: "+deliveryVOWS.toString1()); break;
                    case 1: Console.Out.WriteLine("Add express delivery successful with warning, some recipients are not accepted.");
                        //Show the delivery VO
                        Console.Out.WriteLine("DeliveryVO: " + deliveryVOWS.toString1());

                        //Show the non-user email(s) if available
                        var nonUserEmails = o.SelectToken("nonUserEmails");
                        if (nonUserEmails != null)
                        {
                            Console.Out.WriteLine("Non-user emails: ");
                            String nonUserEmailsStr = nonUserEmails.ToObject<String>();
                            Console.Out.WriteLine(nonUserEmailsStr);
                        }

                        //Show the inactive user(s) if available
                        var inactiveUsers = o.SelectToken("inactiveUsers");
                        if (inactiveUsers != null)
                        {
                            Console.Out.WriteLine("Inactive users: ");
                            try
                            {
                                UserVOWS userVOWS = null;
                                userVOWS = inactiveUsers.ToObject<UserVOWS>();
                                Console.Out.WriteLine(userVOWS.toString());
                            }
                            catch (Exception e)
                            {
                                List<UserVOWS> userVOWSList = null;
                                userVOWSList = inactiveUsers.ToObject<List<UserVOWS>>();
                                foreach (UserVOWS currentUserVO in userVOWSList)
                                {
                                    Console.Out.WriteLine(currentUserVO.toString());
                                }
                            }
                        }

                        //Show the non-recipient(s) if available
                        var nonRecipients = o.SelectToken("nonRecipients");
                        if (nonRecipients != null)
                        {
                            Console.Out.WriteLine("Non-recipients: ");
                            try
                            {
                                UserVOWS userVOWS = null;
                                userVOWS = nonRecipients.ToObject<UserVOWS>();
                                Console.Out.WriteLine(userVOWS.toString());
                            }
                            catch (Exception e)
                            {
                                List<UserVOWS> userVOWSList = null;
                                userVOWSList = nonRecipients.ToObject<List<UserVOWS>>();
                                foreach (UserVOWS currentUserVO in userVOWSList)
                                {
                                    Console.Out.WriteLine(currentUserVO.toString());
                                }
                            }
                        }

                        //Show the invalid email(s) if available
                        var invalidEmails = o.SelectToken("invalidEmails");
                        if (invalidEmails != null)
                        {
                            Console.Out.WriteLine("Invalid emails: ");
                            String invalidEmailsStr = invalidEmails.ToObject<String>();
                            Console.Out.WriteLine(invalidEmailsStr);
                        }

                        //Show the rejected email(s) if available
                        var rejectedEmails = o.SelectToken("nonUserEmails ");
                        if (rejectedEmails != null)
                        {
                            Console.Out.WriteLine("Rejected emails: ");
                            String rejectedEmailsStr = rejectedEmails.ToObject<String>();
                            Console.Out.WriteLine(rejectedEmailsStr);
                        }
                        
                        break;
                    case -1: Console.Out.WriteLine("Requester does not have sufficient privileges."); break;
                    case -10: Console.Out.WriteLine("Package was not added."); break;
                    case -6: Console.Out.WriteLine("DataFile not valid"); break;
                    case -99: Console.Out.WriteLine("System error occurred."); break;
                    default: Console.Out.WriteLine("Add express delivery unsuccessful."); break;
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from addExpressDeliveryWithDataFileIdsExt() method: " + e.Message);
            }

        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Adds the delivery.
        /// </summary>
        /// <param name="packageId">The package identifier.</param>
        /// <param name="to">To.</param>
        /// <param name="deliveryName">Name of the delivery.</param>
        /// <param name="cc">The cc.</param>
        /// <param name="bcc">The BCC.</param>
        /// <param name="secureMessage">The secure message.</param>
        public void addDelivery(string packageId, string to, string deliveryName, string cc, string bcc, string secureMessage)
        {
            RestRequest request = new RestRequest("addDelivery", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("packageId", packageId);
            request.AddParameter("to", to);
            request.AddParameter("cc",cc);
            request.AddParameter("bcc", bcc);
            request.AddParameter("deliveryName", deliveryName);
            request.AddParameter("secureMessage", secureMessage);

            // execute the request            
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                
                // Deserialize the JSON automatically using class
                /*AddDeliveryOutputWS output = new AddDeliveryOutputWS();
                output = JsonConvert.DeserializeObject<AddDeliveryOutputWS>(response.Content);
                int returnCode = output.returnCode;*/
                
                // Parse the JSON manually (better than auto deserialization to avoid exception for future changes)
                JObject o = JObject.Parse(response.Content.ToString());
                var deliveryVOWSJSON = o.SelectToken("deliveryVOWS");
                DeliveryVOWS deliveryVOWS = deliveryVOWSJSON.ToObject<DeliveryVOWS>();
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));

                //Message according to the return code. Only most frequent cases are shown
                switch (returnCode)
                {
                    case 0: Console.Out.WriteLine("Delivery created successfully\n");
                        //Show the delivery VO
                        Console.Out.WriteLine("DeliveryVO: \n" + deliveryVOWS.toString1()); break;
                    case 1: Console.Out.WriteLine("Delivery created successfully but at least one recipient was not accepted.");
                        //Show the delivery VO
                        Console.Out.WriteLine("DeliveryVO: " + deliveryVOWS.toString1());

                        //Show the non-user email(s) if available
                        var nonUserEmails = o.SelectToken("nonUserEmails");
                        if (nonUserEmails != null)
                        {
                            Console.Out.WriteLine("Non-user emails: ");
                            String nonUserEmailsStr = nonUserEmails.ToObject<String>();
                            Console.Out.WriteLine(nonUserEmailsStr);
                        }

                        //Show the inactive user(s) if available
                        var inactiveUsers = o.SelectToken("inactiveUsers");
                        if (inactiveUsers != null)
                        {
                            Console.Out.WriteLine("Inactive users: ");
                            try
                            {
                                UserVOWS userVOWS = null;
                                userVOWS = inactiveUsers.ToObject<UserVOWS>();
                                Console.Out.WriteLine(userVOWS.toString());
                            }
                            catch (Exception e)
                            {
                                List<UserVOWS> userVOWSList = null;
                                userVOWSList = inactiveUsers.ToObject<List<UserVOWS>>();
                                foreach (UserVOWS currentUserVO in userVOWSList)
                                {
                                    Console.Out.WriteLine(currentUserVO.toString());
                                }
                            }
                        }

                        //Show the non-recipient(s) if available
                        var nonRecipients = o.SelectToken("nonRecipients");
                        if (nonRecipients != null)
                        {
                            Console.Out.WriteLine("Non-recipients: ");
                            try
                            {
                                UserVOWS userVOWS = null;
                                userVOWS = nonRecipients.ToObject<UserVOWS>();
                                Console.Out.WriteLine(userVOWS.toString());
                            }
                            catch (Exception e)
                            {
                                List<UserVOWS> userVOWSList = null;
                                userVOWSList = nonRecipients.ToObject<List<UserVOWS>>();
                                foreach (UserVOWS currentUserVO in userVOWSList)
                                {
                                    Console.Out.WriteLine(currentUserVO.toString());
                                }
                            }
                        }

                        //Show the invalid email(s) if available
                        var invalidEmails = o.SelectToken("invalidEmails");
                        if (invalidEmails != null)
                        {
                            Console.Out.WriteLine("Invalid emails: ");
                            String invalidEmailsStr = invalidEmails.ToObject<String>();
                            Console.Out.WriteLine(invalidEmailsStr);
                        }

                        //Show the rejected email(s) if available
                        var rejectedEmails = o.SelectToken("nonUserEmails ");
                        if (rejectedEmails != null)
                        {
                            Console.Out.WriteLine("Rejected emails: ");
                            String rejectedEmailsStr = rejectedEmails.ToObject<String>();
                            Console.Out.WriteLine(rejectedEmailsStr);
                        }
                        break;
                    case -1: Console.Out.WriteLine("Requester does not have sufficient privileges."); break;
                    case -2: Console.Out.WriteLine("Delivery with the same name already exists."); break;
                    case -3: Console.Out.WriteLine("Package not found."); break;
                    case -5: Console.Out.WriteLine("Delivery added but delivery object could not be retrieved."); break;
                    case -99: Console.Out.WriteLine("System error occurred."); break;
                    default: Console.Out.WriteLine("Couldn't create delivery."); break;
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from addDelivery() method: " + e.Message);
            }

        }

        /*---------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Deletes the delivery.
        /// </summary>
        /// <param name="deliveryId">The delivery identifier.</param>
        public void deleteDelivery(string deliveryId)
        {
            RestRequest request = new RestRequest("deleteDelivery", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("deliveryId", deliveryId);

            // execute the request            
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                
                //DeleteDeliveryOutputWS output = new DeleteDeliveryOutputWS();
                //output = JsonConvert.DeserializeObject<DeleteDeliveryOutputWS>(response.Content);
                //int returnCode = output.returnCode;
                
                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));


                //Message according to the return code. Only most frequent cases are shown
                switch (returnCode)
                {
                    case 0: Console.Out.WriteLine("Delivery deleted successfully"); break;
                    case -1: Console.Out.WriteLine("Requester does not have sufficient privileges."); break;
                    case -2: Console.Out.WriteLine("Delivery nor found."); break;
                    case -99: Console.Out.WriteLine("System error occurred."); break;
                    default: Console.Out.WriteLine("Couldn't delete delivery."); break;
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from deleteDelivery() method: " + e.Message);
            }

        }

        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Edits the delivery.
        /// </summary>
        /// <param name="deliveryId">The delivery identifier.</param>
        /// <param name="packageId">The package identifier.</param>
        /// <param name="recipientsToStr">The recipients to string.</param>
        /// <param name="recipientsCcStr">The recipients cc string.</param>
        /// <param name="recipientsBccStr">The recipients BCC string.</param>
        /// <param name="deliveryName">Name of the delivery.</param>
        /// <param name="secureMessage">The secure message.</param>
        /// <param name="dateAvailable">The date available.</param>
        /// <param name="dateExpires">The date expires.</param>
        public void editDelivery(string deliveryId, string packageId, string recipientsToStr, string recipientsCcStr, string recipientsBccStr,
            string deliveryName, string secureMessage, string dateAvailable, string dateExpires)
        {
            RestRequest request = new RestRequest("editDelivery", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("deliveryId", deliveryId);
            request.AddParameter("packageId", packageId);
            request.AddParameter("recipientsToStr", recipientsToStr);
            request.AddParameter("recipientsCcStr", recipientsCcStr);
            request.AddParameter("recipientsBccStr", recipientsBccStr);
            request.AddParameter("deliveryName", deliveryName);
            request.AddParameter("secureMessage", secureMessage);
            request.AddParameter("dateAvailable", dateAvailable);
            request.AddParameter("dateExpires", dateExpires);

            // execute the request            
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);

                //EditDeliveryOutputWS output = new EditDeliveryOutputWS();
                //output = JsonConvert.DeserializeObject<EditDeliveryOutputWS>(response.Content);
                //int returnCode = output.returnCode;

                JObject o = JObject.Parse(response.Content.ToString());
                var deliveryVOWSJSON = o.SelectToken("deliveryVO");
                DeliveryVOWS deliveryVOWS = deliveryVOWSJSON.ToObject<DeliveryVOWS>();
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));


                //Message according to the return code. Only most frequent cases are shown
                switch (returnCode)
                {
                    case 0: Console.Out.WriteLine("Delivery edited successfully");
                        //Show the delivery VO
                        Console.Out.WriteLine("DeliveryVO: " + deliveryVOWS.toString1()); break;
                    case 1: Console.Out.WriteLine("Warning! Some recipient are not accepted.");
                        //Show the delivery VO
                        Console.Out.WriteLine("DeliveryVO: " + deliveryVOWS.toString1());

                        //Show the non-user email(s) if available
                        var nonUserEmails = o.SelectToken("nonUserEmails");
                        if (nonUserEmails != null)
                        {
                            Console.Out.WriteLine("Non-user emails: ");
                            String nonUserEmailsStr = nonUserEmails.ToObject<String>();
                            Console.Out.WriteLine(nonUserEmailsStr);
                        }

                        //Show the inactive user(s) if available
                        var inactiveUsers = o.SelectToken("inactiveUsers");
                        if (inactiveUsers != null)
                        {
                            Console.Out.WriteLine("Inactive users: ");
                            try
                            {
                                UserVOWS userVOWS = null;
                                userVOWS = inactiveUsers.ToObject<UserVOWS>();
                                Console.Out.WriteLine(userVOWS.toString());
                            }
                            catch (Exception e)
                            {
                                List<UserVOWS> userVOWSList = null;
                                userVOWSList = inactiveUsers.ToObject<List<UserVOWS>>();
                                foreach (UserVOWS currentUserVO in userVOWSList)
                                {
                                    Console.Out.WriteLine(currentUserVO.toString());
                                }
                            }
                        }

                        //Show the non-recipient(s) if available
                        var nonRecipients = o.SelectToken("nonRecipients");
                        if (nonRecipients != null)
                        {
                            Console.Out.WriteLine("Non-recipients: ");
                            try
                            {
                                UserVOWS userVOWS = null;
                                userVOWS = nonRecipients.ToObject<UserVOWS>();
                                Console.Out.WriteLine(userVOWS.toString());
                            }
                            catch (Exception e)
                            {
                                List<UserVOWS> userVOWSList = null;
                                userVOWSList = nonRecipients.ToObject<List<UserVOWS>>();
                                foreach (UserVOWS currentUserVO in userVOWSList)
                                {
                                    Console.Out.WriteLine(currentUserVO.toString());
                                }
                            }
                        }

                        //Show the invalid email(s) if available
                        var invalidEmails = o.SelectToken("invalidEmails");
                        if (invalidEmails != null)
                        {
                            Console.Out.WriteLine("Invalid emails: ");
                            String invalidEmailsStr = invalidEmails.ToObject<String>();
                            Console.Out.WriteLine(invalidEmailsStr);
                        }

                        //Show the rejected email(s) if available
                        var rejectedEmails = o.SelectToken("nonUserEmails ");
                        if (rejectedEmails != null)
                        {
                            Console.Out.WriteLine("Rejected emails: ");
                            String rejectedEmailsStr = rejectedEmails.ToObject<String>();
                            Console.Out.WriteLine(rejectedEmailsStr);
                        }
                        break;
                    case -1: Console.Out.WriteLine("Requester does not have sufficient privileges."); break;
                    case -2: Console.Out.WriteLine(" Delivery with same name already exists."); break;
                    case -3: Console.Out.WriteLine("Delivery not found."); break;
                    case -99: Console.Out.WriteLine("System error occurred."); break;
                    default: Console.Out.WriteLine("Couldn't edit delivery."); break;
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from editDelivery() method: " + e.Message);
            }

        }

        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the delivery.
        /// </summary>
        /// <param name="deliveryId">The delivery identifier.</param>
        public void getDelivery(string deliveryId, string returnDeliveryAccessList, string accessByRecipient)
        {
            RestRequest request = new RestRequest("getDelivery", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("deliveryId", deliveryId);
            request.AddParameter("returnDeliveryAccessList", returnDeliveryAccessList);
            request.AddParameter("accessByRecipient", accessByRecipient);
            String cn = "Delivery.getDelivery()";

            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //Console.Out.WriteLine(response.Content.ToString());
                //Util.log("getDelivery", response.Content.ToString());
                //GetDeliveryOutputWS output = new GetDeliveryOutputWS();
                //output = JsonConvert.DeserializeObject<GetDeliveryOutputWS>(response.Content);
                //int returnCode = output.returnCode;

                JObject o = JObject.Parse(response.Content.ToString());
                
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));
                                
                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0: 
                        var deliveryVOWSJSON = o.SelectToken("deliveryVO");
                        ExtDeliveryVOWS deliveryVOWS = deliveryVOWSJSON.ToObject<ExtDeliveryVOWS>();
                        errorMessage = "Delivery retrieved successfully. \n" + deliveryVOWS.toString(); break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "Delivery not found."; break;
                    case -3: errorMessage = "Delivery requires password."; break;
                    case -4: errorMessage = "Incorrect delivery password specified."; break;
                    case -5: errorMessage = "Delivery not available yet."; break;
                    case -6: errorMessage = "Delivery has expired."; break;
                    case -7: errorMessage = "Delivery requires payment."; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Couldn't retrieve the delivery."; break;
                }
                Console.Out.WriteLine("\nReturn code: " + returnCode + ". " + errorMessage);

            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from getDelivery() method: " + e.Message);
            }

        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the user deliveries.
        /// </summary>
        public void getUserDeliveries()
        {
            RestRequest request = new RestRequest("getUserDeliveries", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                
                //GetUserDeliveriesOutputWS output = new GetUserDeliveriesOutputWS();
                //output = JsonConvert.DeserializeObject<GetUserDeliveriesOutputWS>(response.Content);
                //int returnCode = output.returnCode;

                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));
                
                //Message according to the return code. Only most frequent cases are shown
                StringBuilder message = new StringBuilder();
                
                switch (returnCode)
                {
                    case 0:
                        message.AppendLine("Got user deliveries successfully.");
                        int totalRowCount = Convert.ToInt32((string)o.SelectToken("totalRowCount"));

                        // If there are atleast one delivery 
                        if (totalRowCount > 0)
                        {
                            var deliveryVOWSJSON = o.SelectToken("extDeliveryVOWSs");

                            // If the user has multiple deliveries, deserialize it as a list of ExtDeliveryVOWS objects
                            if (totalRowCount > 1)
                            {
                                List<ExtDeliveryVOWS> deliveryVOWS = JsonConvert.DeserializeObject<List<ExtDeliveryVOWS>>(deliveryVOWSJSON.ToString());
                                foreach (ExtDeliveryVOWS delivery in deliveryVOWS)
                                {
                                    message.AppendLine(delivery.toString());
                                }
                            }

                            // If the user has only one delivery, deserialize it as an object of ExtDeliveryVOWS class
                            else
                            {
                                ExtDeliveryVOWS deliveryVOWS = JsonConvert.DeserializeObject<ExtDeliveryVOWS>(deliveryVOWSJSON.ToString());
                                message.AppendLine(deliveryVOWS.toString());
                            }
                        }

                        // If there is no delivery for the user
                        else
                        {
                            message.AppendLine("The user has no deliveries.");
                        }
                        break;
                    case -1: message.AppendLine("Requester does not have sufficient privileges."); break;
                    case -2: message.AppendLine("User not found."); break;
                    case -99: message.AppendLine("System error occurred."); break;
                    default: message.AppendLine("Couldn't retrieve deliveries of the user."); break;
                }
                Console.Out.WriteLine("\nReturn code: " + returnCode);
                Console.Out.WriteLine(message);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from getUserDeliveries() method: " + e.Message);
            }

        }

        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Deletes the recipient delivery.
        /// </summary>
        /// <param name="deliveryId">The delivery identifier.</param>
        public void deleteRecipientDelivery(string deliveryId)
        {
            RestRequest request = new RestRequest("deleteRecipientDelivery", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("deliveryId", deliveryId);
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                
                //DeleteRecipientDeliveryOutputWS output = new DeleteRecipientDeliveryOutputWS();
                //output = JsonConvert.DeserializeObject<DeleteRecipientDeliveryOutputWS>(response.Content);
                //int returnCode = output.returnCode;

                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0: errorMessage = "Received delivery deleted successfully"; break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "Delivery not found."; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Couldn't delete received delivery."; break;
                }
                Console.Out.WriteLine("\nReturn code: " + returnCode);
                Console.Out.WriteLine(errorMessage);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from deleteRecipientDelivery() method: " + e.Message);
            }

        }

        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the transactions of a delivery.
        /// </summary>
        /// <param name="deliveryId">The delivery identifier.</param>
        public void getDeliveryTransactions(string deliveryId, string transactionLevel,
            string searchText, string matchType, string wordMatchType, string sortOrder,
            string numOfItemsToReturn, string startItemNo, string dateFrom, string dateTo,
            string channelType, string complianceTransactions, string onlyComplianceTransactions)
        {
            RestRequest request = new RestRequest("getDeliveryTransactions", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("deliveryId", deliveryId);
            request.AddParameter("transactionLevel",transactionLevel);
            request.AddParameter("q", searchText);
            request.AddParameter("mt", matchType);
            request.AddParameter("wm", wordMatchType);
            request.AddParameter("so", sortOrder);
            request.AddParameter("numOfItemsToReturn", numOfItemsToReturn);
            request.AddParameter("itemOffset", startItemNo);
            request.AddParameter("dateFrom", dateFrom);
            request.AddParameter("dateTo", dateTo);
            request.AddParameter("channelType", channelType);
            request.AddParameter("complianceTransactions", complianceTransactions);
            request.AddParameter("onlyComplianceTransactions", onlyComplianceTransactions);
            
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                System.IO.File.WriteAllText(@"C:\Users\Raine\Desktop\output.txt", response.Content.ToString());

                // Deserialize
                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));
                int totalRowCount = Convert.ToInt32((string)o.SelectToken("totalRowCount"));

                //Message according to the return code. Only most frequent cases are shown
                StringBuilder message = new StringBuilder();
                switch (returnCode)
                {
                    case 0: message.Append("Transactions of the delivery retrieved successfully");
                        var transactionVOWSJSON = o.SelectToken("deliveryTransactionVOs");

                        if (transactionVOWSJSON != null)
                        {
                            message.AppendLine(Environment.NewLine);
                            message.AppendLine("Delivery Transaction VOs: ");
                            message.Append(Environment.NewLine);

                            int numOfItems = Convert.ToInt32(numOfItemsToReturn);
                            if (totalRowCount > 1 && numOfItems > 1)
                            {
                                List<TransactionVOWS> transactionVOWSList = transactionVOWSJSON.ToObject<List<TransactionVOWS>>();
                                foreach (TransactionVOWS tvows in transactionVOWSList)
                                {
                                    message.AppendLine(tvows.toString());
                                }
                            }
                            else
                            {
                                TransactionVOWS transactionVOWS = transactionVOWSJSON.ToObject<TransactionVOWS>();
                                message.AppendLine(transactionVOWS.toString());
                            }
                        }
                        break;
                    case -2: message.Append("Delivery not found."); break;
                    case -99: message.Append("System error occurred."); break;
                    default: message.Append("Couldn't retrieve the transactions of the delivery."); break;
                }
                Console.Out.WriteLine("\nReturn code: " + returnCode);
                Console.Out.WriteLine(message);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from deleteRecipientDelivery() method: " + e.Message);
            }

        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the delivery documents.
        /// </summary>
        /// <param name="deliveryId">The delivery identifier.</param>
        public void getDeliveryDocuments(string deliveryId, string sortOrder, string sortAttribute,
            string numOfItemsToReturn, string startItemNo, string returnFileDownloadLinks)
        {
            RestRequest request = new RestRequest("getDeliveryDocuments", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("deliveryId", deliveryId);
            request.AddParameter("so", sortOrder);
            request.AddParameter("sa", sortAttribute);
            request.AddParameter("numOfItemsToReturn", numOfItemsToReturn);
            request.AddParameter("itemOffset", startItemNo);
            request.AddParameter("returnFileDownloadLinks", returnFileDownloadLinks);


            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //Util.log("getDeliveryDocuments()", response.Content.ToString());
                //GetDeliveryOutputWS output = new GetDeliveryOutputWS();
                //output = JsonConvert.DeserializeObject<GetDeliveryOutputWS>(response.Content);
                //int returnCode = output.returnCode;

                //Message according to the return code. Only most frequent cases are shown

                // Deserialize
                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));
                int totalRowCount = Convert.ToInt32((string)o.SelectToken("totalRowCount"));
                int numOfItems = Convert.ToInt32(numOfItemsToReturn);
                Boolean returnLinks = Convert.ToBoolean(returnFileDownloadLinks);
                string message = "";
                StringBuilder additionalMessage = new StringBuilder();
                switch (returnCode)
                {
                    case 0: var documentVOWSJSON = o.SelectToken("documentVOs");
                        if (documentVOWSJSON != null)
                        {
                            if (totalRowCount > 1 && numOfItems > 1)
                            {
                                List<DocumentVOWS> documentVOWSList = documentVOWSJSON.ToObject<List<DocumentVOWS>>();
                                foreach (DocumentVOWS dvows in documentVOWSList)
                                {
                                    additionalMessage.AppendLine(dvows.toString());
                                    if (returnLinks)
                                    {
                                        var documentlinksJSON = dvows.fileDownloadLinks;
                                        try
                                        {
                                            List<ObjectLink> documentLinkList = JsonConvert.DeserializeObject<List<ObjectLink>>(documentlinksJSON);
                                            foreach (ObjectLink documentLink in documentLinkList)
                                            {
                                                additionalMessage.AppendLine(documentLink.toString());
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            ObjectLink documentLink = JsonConvert.DeserializeObject<ObjectLink>(documentlinksJSON);
                                            additionalMessage.AppendLine(documentLink.toString());
                                        }

                                    }
                                }
                            }
                            else
                            {
                                DocumentVOWS documentVOWS = documentVOWSJSON.ToObject<DocumentVOWS>();
                                additionalMessage.AppendLine(documentVOWS.toString());
                                
                                if (returnLinks)
                                {
                                    var documentlinksJSON = documentVOWS.fileDownloadLinks;
                                    try
                                    {
                                        List<ObjectLink> documentLinkList = JsonConvert.DeserializeObject<List<ObjectLink>>(documentlinksJSON);
                                        foreach (ObjectLink documentLink in documentLinkList)
                                        {
                                            additionalMessage.AppendLine(documentLink.toString());
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        ObjectLink documentLink = JsonConvert.DeserializeObject<ObjectLink>(documentlinksJSON);
                                        additionalMessage.AppendLine(documentLink.toString());
                                    }

                                }
                            }

                            message = "Document of the delivery retrieved successfully.";
                        }
                        break;
                    case -1: message = "Requester does not have sufficient privileges."; break;
                    case -2: message = "Parent directory not found."; break;
                    case -3: message = "Package not found."; break;
                    case -4: message = "Delivery not found."; break;
                    case -99: message = "System error occurred."; break;
                    default: message = "Couldn't retrieve the delivery documents."; break;
                }
                Console.Out.WriteLine("\nReturn code: " + returnCode + ". " + message);
                Console.Out.WriteLine(additionalMessage);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from getDeliveryDocuments() method: " + e.Message);
            }

        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the init property.
        /// </summary>
        public void getInitProperty(string initProperty)
        {
            RestRequest request = new RestRequest("getInitProperty", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("propertyName", initProperty);            

            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //GetInitPropertyOutputWS output = new GetInitPropertyOutputWS();
                //output = JsonConvert.DeserializeObject<GetInitPropertyOutputWS>(response.Content);
                //int returnCode = output.returnCode;

                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));
                int totalRowCount = Convert.ToInt32((string)o.SelectToken("totalRowCount"));

                //Message according to the return code. Only most frequent cases are shown
                string message = "";
                switch (returnCode)
                {
                    case 0:
                        message = "Init property retrieved successfully. \n";
                        var initPropertyVOWSJSON = o.SelectToken("initPropertyVOWS");
                        if (initPropertyVOWSJSON != null)
                        {
                            InitPropertyVOWS initPropertyVOWS = JsonConvert.DeserializeObject<InitPropertyVOWS>(initPropertyVOWSJSON.ToString());
                            message = String.Concat(message, initPropertyVOWS.toString());
                        }                        
                        break;
                    case -1: message = "Requester does not have sufficient privileges."; break;
                    case -2: message = "Initialization property  not found."; break;
                    case -99: message = "System error occurred."; break;
                    default: message = "Couldn't retrieve the init property."; break;
                }
                Console.Out.WriteLine("\nReturn code: " + returnCode + ". " + message);

            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from getDelivery() method: " + e.Message);
            }

        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/
    }
}
