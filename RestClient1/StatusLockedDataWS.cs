using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class StatusLockedDataWS
    {
        /** Last sign in failure date */
        public DateTime signInLastFailureDate { get; set; }
        /** Manual unlocking status */
        public Boolean manualUnlockRequired { get; set; }
    }
}
