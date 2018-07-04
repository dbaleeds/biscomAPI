using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class InitPropertyVOWS
    {
        /** The property name. */
        public String name { get; set; }
        /** The property value. */
        public String value { get; set; }
        /** The status. */
        public String status { get; set; }
        /** Flag to indicate if the value takes effect after the application server is restarted. */
        public bool requiresRestart { get; set; }
        /** The user who created the record. */
        public int createdBy { get; set; }
        /** The date when the record was created. */
        public DateTime dateCreated { get; set; }
        /** The user who last updated the record. */
        public int lastUpdatedBy { get; set; }
        /** The date when the record was last updated. */
        public DateTime dateLastUpdated { get; set; }

        public String toString()
        {
            String NEW_LINE = "\n";

            StringBuilder thisString = new StringBuilder();
            thisString.Append("Name: ");
            thisString.AppendLine(this.name);
            thisString.Append("Value: ");
            thisString.AppendLine(this.value);
            thisString.Append("Status: ");
            thisString.AppendLine(this.status);
            thisString.Append("Requires restart: ");
            thisString.AppendLine(this.requiresRestart.ToString());
            thisString.Append("Created By: ");
            thisString.AppendLine(this.createdBy.ToString());
            thisString.Append("Date Created: ");
            thisString.AppendLine(this.dateCreated.ToString());
            thisString.Append("Last Updated By: ");
            thisString.AppendLine(this.lastUpdatedBy.ToString());
            thisString.Append("Date Last Updated: ");
            thisString.AppendLine(this.dateLastUpdated.ToString());
            return thisString.ToString();
        }
    }
}
