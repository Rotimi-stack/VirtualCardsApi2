using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualCards.Application.Common.Model;

namespace VirtualCards.Application.Common.VirtualCards.VirtualCardsQuery
{
    public class FetchVirtualCardTransactionQuery : IRequest<FetchVirtualCardTransactionResponse>
    {
        public string id { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public int index { get; set; }
        public int size { get; set; }

    }
}