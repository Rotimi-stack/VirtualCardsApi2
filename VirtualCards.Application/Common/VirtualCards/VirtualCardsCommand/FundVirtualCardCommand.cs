using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualCards.Application.Common.Model;

namespace VirtualCards.Application.Common.VirtualCards.VirtualCardsCommand
{
    public class FundVirtualCardCommand :IRequest<FundVirtualCardResponse>
    {
        public string debit_currency { get; set; }
        public string amount { get; set; }
        public string id { get;set; }
    }
}
