using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace RestClient1
{
    /*
     * Base class for classes dedicated to call the REST Web Services.
     */
    class BDSRESTClientBase
    {   
        // Instance of RestClient
        public RestClient client {get;set;}
        // Value of session ID
        public string sessionId { get;set;}

        // Constructor for BDSRESTClientBase class
        public BDSRESTClientBase(string session)
        {
            this.sessionId = session;
            this.client = BDSRESTClientTester.getClient();
        }


    }
}
