using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualCards.Application.Common.Model;

namespace VirtualCards.Application.Common.VirtualCards.VirtualCardsCommand
{
    public class CreateVirtualCardCommand : IRequest<CreateVirtualCardResponse>
    {
        public string currency { get; set; } = string.Empty;
        public int amount { get; set; }
        public string debit_currency { get; set; } = string.Empty;
        public string billing_name { get; set; } = string.Empty;
        public string billing_address { get; set; } = string.Empty;
        public string billing_city { get; set; } = string.Empty;
        public string billing_state { get; set; } = string.Empty;
        public string billing_postal_code { get; set; } = string.Empty;
        public string billing_country { get; set; } = string.Empty;
        public string first_name { get; set; } = string.Empty;
        public string last_name { get; set; } = string.Empty;
        public string date_of_birth { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;
        public string gender { get; set; } = string.Empty;
        public string callback_url { get; set; } = string.Empty;
    }
}
