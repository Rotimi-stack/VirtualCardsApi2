using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VirtualCards.Application.Common.Interface;
using VirtualCards.Application.Common.Model;
using VirtualCards.Application.Common.VirtualCards.VirtualCardsCommand;

namespace VirtualCards.Application.Common.VirtualCards.VirtualCardsCommandHandler
{
    public class CreateVirtualCardsCommandHandler : IRequestHandler<CreateVirtualCardCommand, CreateVirtualCardResponse>
    {
        private readonly VirtualCardsInterface _vc;
        public CreateVirtualCardsCommandHandler(VirtualCardsInterface vc)
        {
            _vc = vc;
        }

        public async Task<CreateVirtualCardResponse> Handle(CreateVirtualCardCommand request, CancellationToken cancellationToken)
        {
            var data = new CreateVirtualCardResources
            {
                amount = request.amount,
                billing_address = request.billing_address,
                billing_city = request.billing_city,
                billing_country = request.billing_country,
                billing_name = request.billing_name,
                billing_postal_code = request.billing_postal_code,
                billing_state = request.billing_state,
                callback_url = request.callback_url,
                currency = request.currency,
                date_of_birth = request.date_of_birth,
                debit_currency = request.debit_currency,
                email = request.email,
                first_name = request.first_name,
                gender = request.gender,
                last_name = request.last_name,
                phone = request.phone,
                title = request.title,
            };
            return await _vc.CreateVirtualCard(data);
        }
    }
}
