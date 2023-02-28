using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualCards.Application.Common.Model;

namespace VirtualCards.Application.Common.Interface
{
    public interface VirtualCardsInterface
    {
        Task<CreateVirtualCardResponse> CreateVirtualCard(CreateVirtualCardResources vc);
        Task<FundVirtualCardResponse> FundVirtualCard(FundVirtualCardResource fvc);
        Task<WithdrawFromVirtualCardResponse> WithdrawFromVirtualCard(WithdrawFromVirtualCardResource wfc);
        Task<GetAllVirtualCardsResponse> GetAllVirtualCards(GetAllVirtualCardsResource gvc);
        Task<GetAVirtualCardResponse> GetAVirtualCard(string id);
        Task<FetchVirtualCardTransactionResponse> FetchVirtualCardTransaction(FetchVirtualCardTransactionResource fvc);
        Task<BlockUnblockVirtualCardResponse> BlockUnblockVirtualCard(BlockUnblockVirtualCardResource bvc);
        Task<TerminateVirtualCardResponse> TerminateVirtualCard(TerminateVirtualCardResource tvc);


    }
}
