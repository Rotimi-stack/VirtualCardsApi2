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
    public class FundVirtualCardCommandHandler : IRequestHandler<FundVirtualCardCommand, FundVirtualCardResponse>
    {
        private readonly VirtualCardsInterface _vc;
        public FundVirtualCardCommandHandler(VirtualCardsInterface vc)
        {
            _vc = vc;
        }
        public async Task<FundVirtualCardResponse> Handle(FundVirtualCardCommand request, CancellationToken cancellationToken)
        {
            var data = new FundVirtualCardResource
            {
                amount = request.amount,
                debit_currency = request.debit_currency,
                id=request.id
                
            };

            return await _vc.FundVirtualCard(data);
        }
    }
}
