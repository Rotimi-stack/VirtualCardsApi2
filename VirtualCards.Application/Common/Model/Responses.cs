using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualCards.Application.Common.Model
{
    public class Responses
    {
      
    }

    public class TerminateVirtualCardResponse
    {
        public string status { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public string data { get; set; }
    }
    public class BlockUnblockVirtualCardResponse
    {
        public string status { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public string data { get; set; }
    }
    public class FetchVirtualCardTransactionResponse
    {
        public string status { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public string data { get; set; }
    }
    public class GetAllVirtualCardsResponse
    {
        public string status { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public List<Data> data { get; set; }

    }

    public class GetAVirtualCardResponse
    {
        public string status { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public Data data { get; set; }
    }


    public class WithdrawFromVirtualCardResponse
    {
        public string status { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public string data { get; set; }
    }

    public class FundVirtualCardResponse
    {
        public string status { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public string data { get; set; }
    }


    public class CreateVirtualCardResponse
    {
        public string status { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public Data data { get; set; }
    }



    public class Data
    {
        public string id { get; set; }
        public int account_id { get; set; }
        public string amount { get; set; } = string.Empty;
        public string currency { get; set; } = string.Empty;
        public string card_pan { get; set; } = string.Empty;
        public string masked_pan { get; set;} = string.Empty;
        public string city { get; set;} = string.Empty;
        public string state { get; set;} = string.Empty;
        public string address_1 { get; set;} = string.Empty;
        public string address_2 { get; set;} = string.Empty;
        public string zip_code { get; set;} = string.Empty;
        public string cvv { get; set;} = string.Empty;
        public string expiration { get; set;} = string.Empty;
        public string send_to { get; set;} = string.Empty;
        public string bin_check_name { get; set; } = string.Empty;
        public string card_type { get; set;} = string.Empty;
        public string name_on_card { get; set;}=string.Empty;
        public string created_at { get;set;}=string.Empty;
        public bool is_active { get; set;}
        public string callback_url { get; set;} = string.Empty;

    }
}
