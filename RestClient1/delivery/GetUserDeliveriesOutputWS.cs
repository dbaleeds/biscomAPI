using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1.delivery
{
    class GetUserDeliveriesOutputWS
    {
        // Instance variables

        /** The return code for the method call */
        public int returnCode { get; set; }
        /** The list of extended delivery value objects */
        public List<ExtDeliveryVOWS> extDeliveryVOWSs { get; set; }
        /** The total number of rows */
        public int totalRowCount { get; set; }

    }
}
