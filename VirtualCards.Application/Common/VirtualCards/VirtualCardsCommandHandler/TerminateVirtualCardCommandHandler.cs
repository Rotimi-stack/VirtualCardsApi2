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
    public class TerminateVirtualCardCommandHandler : IRequestHandler<TerminateVirtualCardCommand, TerminateVirtualCardResponse>
    {
        private readonly VirtualCardsInterface _vc;
        public TerminateVirtualCardCommandHandler(VirtualCardsInterface vc)
        {
            _vc = vc;
        }
        public async Task<TerminateVirtualCardResponse> Handle(TerminateVirtualCardCommand request, CancellationToken cancellationToken)
        {
            var data = new TerminateVirtualCardResource
            {
                id = request.id
            };
            return await _vc.TerminateVirtualCard(data);
        }
    }
}
