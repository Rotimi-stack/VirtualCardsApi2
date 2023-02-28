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
    public class GetAllVirtualCardsQueryHandler : IRequestHandler<GetAllVirtualCardsQuery, GetAllVirtualCardsResponse>
    {

        private readonly VirtualCardsInterface _vc;
        public GetAllVirtualCardsQueryHandler(VirtualCardsInterface vc)
        {
            _vc = vc;
        }

        public async Task<GetAllVirtualCardsResponse> Handle(GetAllVirtualCardsQuery request, CancellationToken cancellationToken)
        {
            var data = new GetAllVirtualCardsResource
            {

            };
            return await _vc.GetAllVirtualCards(data);
        }
    }
}
