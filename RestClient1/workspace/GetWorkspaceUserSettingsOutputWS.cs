using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class GetWorkspaceUserSettingsOutputWS
    {

        // Instances
        /** The return code for the method call */
        public int returnCode { get; set; }
        /** Map of the notification settings */
        public Dictionary<string, Boolean> settingMap { get; set; }
        

        public string toString() {
		string NEW_LINE = "\n";

		StringBuilder thisString = new StringBuilder();
		thisString.Append("returnCode: ");
		thisString.Append(this.returnCode);
		thisString.Append(NEW_LINE);
		thisString.Append("settingMap: ");
        foreach (KeyValuePair<string, Boolean> map in settingMap)
        {
           thisString.Append((map.Key != null) ? map.Key+" = "+map.Value: "<null>");
        }
        //thisString.Append((settingMap.Keys != null) ? settingMap.entry + " = " + this.settingMap.Value : "<null>");
        //thisString.Append(settingMap.entry);
		thisString.Append(NEW_LINE);

		return thisString.ToString();
	    }
    }

    
}
