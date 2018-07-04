using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class AddCommentOutputWS
    {
        /** The return code for the method call */
        public int returnCode { get; set; }
        /** The newly created <code>{@link CommentVOWS}</code> */
        public CommentVOWS commentVO { get; set; }
    }
}
