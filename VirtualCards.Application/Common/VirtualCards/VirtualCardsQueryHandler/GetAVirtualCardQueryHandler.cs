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
    public class GetAVirtualCardQueryHandler : IRequestHandler<GetAVirtualCardQuery, GetAVirtualCardResponse>
    {
        private readonly VirtualCardsInterface _vc;
        public GetAVirtualCardQueryHandler(VirtualCardsInterface vc)
        {
            _vc = vc;
        }

        public async Task<GetAVirtualCardResponse> Handle(GetAVirtualCardQuery request, CancellationToken cancellationToken)
        {
            var data = new GetAVirtualCardResource
            {

            };
            return await _vc.GetAVirtualCard(request.id);
        }
    }
    
}
