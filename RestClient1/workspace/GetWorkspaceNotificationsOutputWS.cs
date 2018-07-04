using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class GetWorkspaceNotificationsOutputWS
    {
        /** The return code for the method call */
        public int returnCode { get; set; }
        /** The specified workspace */
        public List<WorkspaceNotificationVOWS> workspaceNotifications { get; set; }

        public string toString() {
		string NEW_LINE = "\n";

		StringBuilder thisString = new StringBuilder();
		thisString.Append("returnCode: ");
		thisString.Append(this.returnCode);
		thisString.Append(NEW_LINE);
		thisString.Append("workspaceNotifications: ");
        foreach (WorkspaceNotificationVOWS wn in workspaceNotifications)
        {
            thisString.Append((wn == null) ? "<null>" : wn.toString());
        }
        
		thisString.Append(NEW_LINE);

		return thisString.ToString();
	}
    }
}
