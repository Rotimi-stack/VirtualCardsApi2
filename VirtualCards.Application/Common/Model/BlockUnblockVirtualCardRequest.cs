using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualCards.Application.Common.Model
{
   public class BlockUnblockVirtualCardRequest
    {
        public string id { get; set; }
        public string status_action { get; set; }
    }
}
