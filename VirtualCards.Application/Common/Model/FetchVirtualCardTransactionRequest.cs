using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualCards.Application.Common.Model
{
    public class FetchVirtualCardTransactionRequest
    {
        public string id { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public int index { get; set; }
        public int size { get; set; }
    }
}
