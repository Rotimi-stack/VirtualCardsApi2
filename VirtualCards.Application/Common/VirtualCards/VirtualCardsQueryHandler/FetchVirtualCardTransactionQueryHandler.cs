using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VirtualCards.Application.Common.Interface;
using VirtualCards.Application.Common.Model;
using VirtualCards.Application.Common.VirtualCards.VirtualCardsQuery;

namespace VirtualCards.Application.Common.VirtualCards.VirtualCardsQueryHandler
{
    public class FetchVirtualCardTransactionQueryHandler : IRequestHandler<FetchVirtualCardTransactionQuery, FetchVirtualCardTransactionResponse>
    {
        private readonly VirtualCardsInterface _vc;
        public FetchVirtualCardTransactionQueryHandler(VirtualCardsInterface vc)
        {
            _vc = vc;
        }
        public async Task<FetchVirtualCardTransactionResponse> Handle(FetchVirtualCardTransactionQuery request, CancellationToken cancellationToken)
        {
            var data = new FetchVirtualCardTransactionResource
            {
                id = request.id,
                from = request.from,
                index = request.index,
                size = request.size,
                to = request.to
            };
            return await _vc.FetchVirtualCardTransaction(data);
        }

    }
}
