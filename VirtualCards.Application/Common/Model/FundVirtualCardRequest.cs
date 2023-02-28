using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualCards.Application.Common.Model
{
    public  class FundVirtualCardRequest
    {
        public string debit_currency { get; set; }
        public string amount { get; set; }
        
    }
}
