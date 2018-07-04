using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1.package
{
    class GetPackageDeliveriesOutputWS
    {
        // Instance variables

        /** The return code for the method call */
        public int returnCode { get; set; }
        /** The list of delivery value objects */
        public List<DeliveryVOWS> deliveryVOs { get; set; }
        /** The total number of rows */
        public int totalRowCount { get; set; }
    }
}
