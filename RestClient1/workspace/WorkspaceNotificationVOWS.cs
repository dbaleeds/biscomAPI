using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class WorkspaceNotificationVOWS
    {
        /* Instance variables */
        public int eventId { get; set; }
        public int packageId { get; set; }
        public String notificationType { get; set; }
        public String message { get; set; }
        public String status { get; set; }

        public DateTime eventDate { get; set; }
        public String parsedEventDate { get; set; }
        public DateTime sentDate { get; set; }
        public String parsedSentDate { get; set; }

    public String toString() {
		string NEW_LINE = "\n";

        StringBuilder thisString = new StringBuilder();
		thisString.Append("eventId: ");
		thisString.Append(this.eventId);
		thisString.Append(NEW_LINE);
		thisString.Append("packageId: ");
		thisString.Append(this.packageId);
		thisString.Append(NEW_LINE);
		thisString.Append("notificationType: ");
		thisString.Append(this.notificationType);
		thisString.Append(NEW_LINE);
		thisString.Append("message: ");
		thisString.Append((this.message == null) ? "<null>" : this.message);
		thisString.Append(NEW_LINE);
		thisString.Append("eventDate: ");
		thisString.Append((this.eventDate == null) ? "<null>" : this.eventDate.ToString());
		thisString.Append(NEW_LINE);
		thisString.Append("status: ");
		thisString.Append(this.status);
		thisString.Append(NEW_LINE);
		thisString.Append("sentDate: ");
		thisString.Append((this.sentDate == null) ? "<null>" : this.sentDate.ToString());
		thisString.Append(NEW_LINE);

		return thisString.ToString();
	}
    
    }
}
