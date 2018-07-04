using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class WorkspaceUsersWS
    {
        public HashSet<UserVOWS> managers = new HashSet<UserVOWS>();
        internal HashSet<UserVOWS> Managers
        {
            get { return managers; }
            set { managers = value; }
        }
        
        public HashSet<UserVOWS> collaborators = new HashSet<UserVOWS>();
        internal HashSet<UserVOWS> Collaborators
        {
            get { return collaborators; }
            set { collaborators = value; }
        }
        
        public HashSet<UserVOWS> viewers = new HashSet<UserVOWS>();
        internal HashSet<UserVOWS> Viewers
        {
            get { return viewers; }
            set { viewers = value; }
        }

        

        public string toString()
        {
            
            string NEW_LINE = "\n";

            StringBuilder thisString = new StringBuilder();
            thisString.Append("Managers: ");

            if (managers == null) thisString.Append("<null>");
            else
            {
                foreach (UserVOWS m in managers)
                {                    
                    thisString.Append((managers == null) ? "<null>" : m.emailAddress.ToString());
                    thisString.Append(",");
                }
            }
            thisString.Append(NEW_LINE);
            
            thisString.Append("Collaborators: ");

            if (collaborators == null) thisString.Append("<null>");
            else
            {
                foreach (UserVOWS c in this.collaborators)
                {
                    thisString.Append((this.collaborators == null) ? "<null>" : c.emailAddress.ToString());
                    thisString.Append(",");
                }
            }
            thisString.Append(NEW_LINE);

            thisString.Append("Viewers: ");
            if (viewers == null) thisString.Append("<null>");
            else
            {
                foreach (UserVOWS v in this.viewers)
                {
                    thisString.Append((this.viewers == null) ? "<null>" : v.emailAddress);
                    thisString.Append(",");
                }
            }
            thisString.Append(NEW_LINE);

            return thisString.ToString();
        }

    }
}
