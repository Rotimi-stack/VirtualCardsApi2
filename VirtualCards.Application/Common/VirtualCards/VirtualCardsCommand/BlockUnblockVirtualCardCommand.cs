using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualCards.Application.Common.Model;

namespace VirtualCards.Application.Common.VirtualCards.VirtualCardsCommand
{
   public class BlockUnblockVirtualCardCommand: IRequest<BlockUnblockVirtualCardResponse>
    {
        public string id { get; set; }
        public string status_action { get; set; }
    }
}
