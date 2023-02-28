using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualCards.Application.Common.Model;

namespace VirtualCards.Application.Common.VirtualCards.VirtualCardsCommand
{
   public class TerminateVirtualCardCommand : IRequest<TerminateVirtualCardResponse>
    {
        public string id { get; set; }
    }
}
