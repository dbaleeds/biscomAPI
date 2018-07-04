using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using Newtonsoft.Json;
using RestClient1.user;
using Newtonsoft.Json.Linq;


namespace RestClient1
{
    class User : BDSRESTClientBase
    {
        //Constructs an object with a sessionId and a client
		public User(string session)
			: base(session)
		{

		}

        /// <summary>
        /// Adds a user.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="displayAs">The display as.</param>
        /// <param name="password">The password.</param>
        /// <param name="quota">The quota.</param>
        /// <param name="roles">The roles.</param>
        public void addUser(string emailAddress, string displayAs, string password, string quota, string roles)
        {
            RestRequest request = new RestRequest("addUser", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("emailAddress", emailAddress);
            request.AddParameter("displayAs", displayAs);
            request.AddParameter("password", password);
            request.AddParameter("quota", quota);
            request.AddParameter("roles", roles);
            
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //AddUserOutputWS output = new AddUserOutputWS();
                //output = JsonConvert.DeserializeObject<AddUserOutputWS>(response.Content);
                //int returnCode = output.returnCode;
                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch(returnCode)
                {
                    case 0: errorMessage = "User added successfully."; break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "User with the same name already exists."; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Couldn't add user."; break;

                }
                Console.Out.WriteLine("Return Code: "+returnCode+"\n"+errorMessage);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from addUser() method: " + e.Message);
            }

        }
        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        public void deleteUser(string userId)
        {
            RestRequest request = new RestRequest("deleteUser", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("userId", userId);
            
            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //DeleteUserOutputWS output = new DeleteUserOutputWS();
                //output = JsonConvert.DeserializeObject<DeleteUserOutputWS>(response.Content);
                //int returnCode = output.returnCode;
                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0: errorMessage = "User deleted successfully"; break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "User doesn't exist."; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "User deletion unsuccessfull."; break;
                }
                Console.Out.WriteLine(errorMessage);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from deleteUser() method: " + e.Message);
            }

        }

        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="displayName">The display name.</param>
        /// <param name="roleRecipient">The role recipient.</param>
        /// <param name="roleSender">The role sender.</param>
        /// <param name="anyAdminRole">Any admin role.</param>
        /// <param name="roleAdmin">The role admin.</param>
        /// <param name="status">The status.</param>
        public void updateUser(string userId, string displayName, string roleRecipient, string roleSender, string anyAdminRole,string roleAdmin, string status)
        {
            RestRequest request = new RestRequest("editUser", Method.POST);
            request.AddParameter("sessionId", this.sessionId);
            request.AddParameter("userId", userId);
            request.AddParameter("displayName", displayName);
            request.AddParameter("roleRecipient", roleRecipient);
            request.AddParameter("roleSender", roleSender);
            request.AddParameter("anyAdminRole", anyAdminRole);
            request.AddParameter("roleAdmin", roleAdmin);
            request.AddParameter("status", status);

            try
            {
                RestResponse response = (RestResponse)this.client.Execute(request);
                //EditUserOutputWS output = new EditUserOutputWS();
                //output = JsonConvert.DeserializeObject<EditUserOutputWS>(response.Content);
                //int returnCode = output.returnCode;

                JObject o = JObject.Parse(response.Content.ToString());
                int returnCode = Convert.ToInt32((string)o.SelectToken("returnCode"));

                //Message according to the return code. Only most frequent cases are shown
                string errorMessage = "";
                switch (returnCode)
                {
                    case 0: errorMessage = "User updated successfully"; break;
                    case -1: errorMessage = "Requester does not have sufficient privileges."; break;
                    case -2: errorMessage = "User doesn't exist."; break;
                    case -99: errorMessage = "System error occurred."; break;
                    default: errorMessage = "Update user unsuccessfull."; break;
                }
                Console.Out.WriteLine(errorMessage);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception Occured from deleteUser() method: " + e.Message);
            }
        }       
    }
}
