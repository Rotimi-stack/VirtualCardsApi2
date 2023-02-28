using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VirtualCards.Application.Common.Interface;
using VirtualCards.Application.Common.Model;
using VirtualCards.Application.Common.VirtualCards.VirtualCardsCommand;

namespace VirtualCards.Application.Common.VirtualCards.VirtualCardsCommandHandler
{
    public class BlockUnblockVirtualCardCommandHandler : IRequestHandler<BlockUnblockVirtualCardCommand, BlockUnblockVirtualCardResponse>
    {
        private readonly VirtualCardsInterface _vc;
        public BlockUnblockVirtualCardCommandHandler(VirtualCardsInterface vc)
        {
            _vc = vc;
        }
        public async Task<BlockUnblockVirtualCardResponse> Handle(BlockUnblockVirtualCardCommand request, CancellationToken cancellationToken)
        {
            var data = new BlockUnblockVirtualCardResource
            {
                id=request.id,
                status_action=request.status_action
            };
            return await _vc.BlockUnblockVirtualCard(data);
        }
    }
}
