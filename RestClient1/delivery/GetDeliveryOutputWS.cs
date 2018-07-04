using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1.delivery
{
    class GetDeliveryOutputWS
    {
        // Instance variables

        /** The return code for the method call */
        public int returnCode { get; set; }
        /** The specified delivery */
        public ExtDeliveryVOWS deliveryVO { get; set; }
    }
}
