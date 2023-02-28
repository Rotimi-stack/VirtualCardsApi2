using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualCards.Application.Common.Model;

namespace VirtualCards.Application.Common.VirtualCards.VirtualCardsCommand
{
    public class WithdrawFromVirtualCardCommand: IRequest<WithdrawFromVirtualCardResponse>
    {
        public string amount { get; set; }
        
        public string id { get; set; }
        
    }
}
