using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class AddDocumentOutputWS
    {
        // Instance variables

    /** The return code for the method call */
    public int returnCode{get;set;}
    /** The newly created document */
    public DocumentVOWS documentVO { get; set; }
    /** The newly created message */
    public List<RcMessageWS> messages = new List<RcMessageWS>();

    internal List<RcMessageWS> Messages
    {
        get { return messages; }
        set { messages = value; }
    }
    }
}
