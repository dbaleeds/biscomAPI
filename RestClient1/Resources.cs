using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    /*
     * This class contains some resources used frequently
     * */
    class Resources
    {
        // url for the BDS REST Web Service
        //public static string URL = "http://rupshav10/bdsrestws/";
        public static string URL = "https://sftp.irc.leeds.ac.uk/bdsrestws";
        //public static string URL = "http://192.168.10.251:8001/bdsrestws";
       
        //public static string URL = "https://download.biscom.com/pianbdsrestws";
        
        // username required for sign in
        public static string USER_NAME = "USER";
        //public static string USER_NAME = "raine@nilavo.com";
        //public static string USER_NAME = "admin";
        
        
        // password required for sign in
        public static string PASSWORD = "PASS";
        //public static string PASSWORD = "admin";   

        public static string LOG_FILE_PATH = @"C:\Users\meddbat\BDSRESTClient.log";
    }
}
