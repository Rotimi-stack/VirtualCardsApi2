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
    public class WithdrawFromVirtualCardCommandHandler : IRequestHandler<WithdrawFromVirtualCardCommand, WithdrawFromVirtualCardResponse>
    {
        private readonly VirtualCardsInterface _vc;
        public WithdrawFromVirtualCardCommandHandler(VirtualCardsInterface vc)
        {
            _vc = vc;
        }
        public async Task<WithdrawFromVirtualCardResponse> Handle(WithdrawFromVirtualCardCommand request, CancellationToken cancellationToken)
        {
            var data = new WithdrawFromVirtualCardResource
            {
                amount = request.amount,
                id = request.id
            };
            return await _vc.WithdrawFromVirtualCard(data);
        }
        
    }
}
