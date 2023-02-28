using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VerificationAPI.Controllers;
using VirtualCards.Application.Common.Model;
using VirtualCards.Application.Common.VirtualCards.VirtualCardsCommand;
using VirtualCards.Application.Common.VirtualCards.VirtualCardsQuery;

namespace VirtualCardsApi.Controllers
{
    public class VirtualCardsController : BaseController
    {
        [HttpPost("create-virtual-card")]
        public async Task<ActionResult<CreateVirtualCardResponse>> GetEnhancedKYCVerification(CreateVirtualCardCommand lyc)
        {
            return await Mediator.Send(lyc);
        }


        [HttpPost("fund-virtual-card")]
        public async Task<ActionResult<FundVirtualCardResponse>> FundVirtualCard(FundVirtualCardCommand lyc)
        {
            return await Mediator.Send(lyc);
        }

        [HttpPost("withdraw-from-virtual-card")]
        public async Task<ActionResult<WithdrawFromVirtualCardResponse>> WithdrawFromVirtualCard(WithdrawFromVirtualCardCommand lyc)
        {
            return await Mediator.Send(lyc);
        }

        [HttpGet("get-all-virtual-cards")]
        public async Task<ActionResult<GetAllVirtualCardsResponse>> GetAllVirtualCards()
        {
            return await Mediator.Send(new GetAllVirtualCardsQuery());
        }

        [HttpGet("get-a-virtual-card")]
        public async Task<ActionResult<GetAVirtualCardResponse>> GetAVirtualCard([FromQuery] string id)
        {
            return await Mediator.Send(new GetAVirtualCardQuery { id = id});
        }

        [HttpGet("fetch-a-virtual-card-transaction")]
        public async Task<ActionResult<FetchVirtualCardTransactionResponse>> FetchVirtualCardTransaction( string id,[FromQuery] string from, [FromQuery] string to, [FromQuery] int index, [FromQuery] int size)
        {
            return await Mediator.Send(new FetchVirtualCardTransactionQuery { id = id,from = from,index =index, size = size, to=to });
 
        }

        [HttpPut("block-unblock-virtual-card")]
        public async Task<ActionResult<BlockUnblockVirtualCardResponse>> BlockUnblockVirtualCard(BlockUnblockVirtualCardCommand bvc)
        {
            return await Mediator.Send(bvc);
        }

        [HttpPut("terminate-virtual-card")]
        public async Task<ActionResult<TerminateVirtualCardResponse>> TerminateVirtualCard(TerminateVirtualCardCommand bvc)
        {
            return await Mediator.Send(bvc);
        }
    }
}
