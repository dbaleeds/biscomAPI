using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class SignInOutputWS
    {
        public int ReturnCode { get; set; }
        public String SessionId { get; set; }
        public UserVOWS UserVOWS { get; set; }
        public StatusLockedDataWS StatusLockedDataWS { get; set; }
    }
}
