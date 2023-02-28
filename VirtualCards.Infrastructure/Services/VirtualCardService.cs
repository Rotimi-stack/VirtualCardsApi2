using FSDH.Shared.LogService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VirtualCards.Application.Common.Interface;
using VirtualCards.Application.Common.Model;
using VirtualCards.Application.Common.VirtualCards.VirtualCardsQuery;
using VirtualCards.Domain.Enum;
using VirtualCards.Infrastructure.Persistence.Context;

namespace VirtualCards.Infrastructure.Services
{
    public class VirtualCardService : VirtualCardsInterface
    {
        private readonly HttpClient _client;

        private readonly IConfiguration _config;
        private readonly ILogWritter _logger;
        private readonly VirtualCardContext _db;



        private static Logger log = LogManager.GetCurrentClassLogger();

        public VirtualCardService(IHttpClientFactory httpClientFactory, IConfiguration config, ILogWritter logger, VirtualCardContext db)
        {
            _client = httpClientFactory.CreateClient();
            _config = config;
            _logger = logger;
            _db = db;
        }

        public async Task<CreateVirtualCardResponse> CreateVirtualCard(CreateVirtualCardResources vc)
        {

            var data = new CreateVirtualCardRequest
            {
                title = vc.title,
                phone = vc.phone,
                last_name = vc.last_name,
                gender = vc.gender,
                first_name = vc.first_name,
                email = vc.email,
                amount = vc.amount,
                billing_address = vc.billing_address,
                billing_city = vc.billing_city,
                billing_country = vc.billing_country,
                billing_name = vc.billing_name,
                billing_postal_code = vc.billing_postal_code,
                billing_state = vc.billing_state,
                callback_url = vc.callback_url,
                currency = vc.currency,
                date_of_birth = vc.date_of_birth,
                debit_currency = vc.debit_currency,

            };
            return await SendAsync<CreateVirtualCardRequest, CreateVirtualCardResponse>(
               data, "/v3/virtual-cards", VirtualCardsHttpMethodType.Post
               );
        }

        public async Task<FundVirtualCardResponse> FundVirtualCard(FundVirtualCardResource fvc)
        {
            var data = new FundVirtualCardRequest
            {
                amount = fvc.amount,
                debit_currency = fvc.debit_currency
            };
            return await SendAsync<FundVirtualCardRequest, FundVirtualCardResponse>(
                data, $"/v3/virtual-cards/{fvc.id}/fund", VirtualCardsHttpMethodType.Post);
        }

        public async Task<WithdrawFromVirtualCardResponse> WithdrawFromVirtualCard(WithdrawFromVirtualCardResource wfc)
        {
            var data = new WithdrawFromVirtualCardRequest
            {
                amount = wfc.amount

            };
            return await SendAsync<WithdrawFromVirtualCardRequest, WithdrawFromVirtualCardResponse>(
               data, $"/v3/virtual-cards/{wfc.id}/withdraw", VirtualCardsHttpMethodType.Post);
        }

        public async Task<GetAllVirtualCardsResponse> GetAllVirtualCards(GetAllVirtualCardsResource gvc)
        {
            return await SendAsync<GetAllVirtualCardsQuery, GetAllVirtualCardsResponse>(
                new GetAllVirtualCardsQuery(), $"/v3/virtual-cards/", VirtualCardsHttpMethodType.Get);
        }

        public async Task<GetAVirtualCardResponse> GetAVirtualCard(string id)
        {
            return await SendAsync<GetAVirtualCardQuery, GetAVirtualCardResponse>(
                new GetAVirtualCardQuery(), $"/v3/virtual-cards/{id}", VirtualCardsHttpMethodType.Get);
        }

        public async Task<FetchVirtualCardTransactionResponse> FetchVirtualCardTransaction(FetchVirtualCardTransactionResource fvc)
        {
            var data = new FetchVirtualCardTransactionQuery
            {
                id = fvc.id,
                from = fvc.from,
                to = fvc.to,
                index = fvc.index,
                size = fvc.size,
                
            };
            return await SendAsync<FetchVirtualCardTransactionQuery, FetchVirtualCardTransactionResponse>(
                data, $"/v3/virtual-cards/{fvc.id}/transactions?from={fvc.from}&to={fvc.to}&index={fvc.index}&size={fvc.size}", VirtualCardsHttpMethodType.Get);
        }

        public async Task<BlockUnblockVirtualCardResponse> BlockUnblockVirtualCard(BlockUnblockVirtualCardResource bvc)
        {
            var data = new BlockUnblockVirtualCardRequest
            {
                id = bvc.id,
                status_action = bvc.status_action
            };
            return await SendAsync<BlockUnblockVirtualCardRequest, BlockUnblockVirtualCardResponse>(
                data, $"/v3/virtual-cards/{bvc.id}/status/{bvc.status_action}", VirtualCardsHttpMethodType.Put);
        }


        public async Task<TerminateVirtualCardResponse> TerminateVirtualCard(TerminateVirtualCardResource tvc)
        {
            var data = new TerminateVirtualCardRequest
            {
                id = tvc.id
            };
            return await SendAsync<TerminateVirtualCardRequest, TerminateVirtualCardResponse>(
                data, $"/v3/virtual-cards/{tvc.id}/terminate", VirtualCardsHttpMethodType.Put);
        }


        public async Task<U> SendAsync<T, U>(T payload, string relativePath, VirtualCardsHttpMethodType httpMethod)
        {
            var baseaddress = _config.GetSection("BaseAddress").Value.ToString();
            var testkey = _config.GetSection("ApiKey").Value.ToString();

            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {testkey}");

            var message = new StringContent(System.Text.Json.JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            HttpResponseMessage response = new HttpResponseMessage();
            string content;
            switch (httpMethod)
            {
                case VirtualCardsHttpMethodType.Post:
                    var resp = await _client.PostAsync($"{baseaddress}{relativePath}", message);
                    content = await resp.Content.ReadAsStringAsync();
                    log.Info("Message: " + content + Environment.NewLine + Environment.NewLine + "Endpoint: " + baseaddress + relativePath + Environment.NewLine + payload + Environment.NewLine + Environment.NewLine + "ApiKey: " + testkey + Environment.NewLine + _client.Timeout + Environment.NewLine + DateTime.Now);

                    try
                    {
                        DateTime requestTime;
                        DateTime responseTime;
                        tblRequestandResponseLogs requestForDb = new tblRequestandResponseLogs();

                        if (resp.IsSuccessStatusCode)
                        {
                            requestTime = DateTime.Now;
                            responseTime = DateTime.Now;
                            requestForDb = new tblRequestandResponseLogs() { RequestType = "VirtualCards", RequestPayload = JsonConvert.SerializeObject(payload), Response = JsonConvert.SerializeObject(content), RequestTimestamp = DateTime.Now, ResponseTimestamp = DateTime.Now, RequestUrl = baseaddress };
                            _db.tblRequestAndResponse.Add(requestForDb);
                            await _db.SaveChangesAsync();
                        }
                        else
                        {
                            if (resp.StatusCode == HttpStatusCode.BadGateway || resp.StatusCode == HttpStatusCode.Unauthorized || resp.StatusCode == HttpStatusCode.BadRequest || resp.StatusCode == HttpStatusCode.ServiceUnavailable || resp.StatusCode == HttpStatusCode.InternalServerError || resp.StatusCode == HttpStatusCode.NotFound || resp.StatusCode == HttpStatusCode.Forbidden)
                            {
                                responseTime = DateTime.Now;
                                requestForDb = new tblRequestandResponseLogs() { RequestType = "EnhancedKycVerification", RequestPayload = JsonConvert.SerializeObject(payload), Response = JsonConvert.SerializeObject(content), RequestTimestamp = responseTime, RequestUrl = baseaddress };
                                _db.tblRequestAndResponse.Add(requestForDb);
                                await _db.SaveChangesAsync();
                                return JsonConvert.DeserializeObject<U>(content);


                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Something went wrong", ex);
                    }
                    return JsonConvert.DeserializeObject<U>(content);


                case VirtualCardsHttpMethodType.Delete:
                    var resssp = await _client.GetAsync($"{baseaddress}{relativePath}");
                    content = await resssp.Content.ReadAsStringAsync();
                    log.Info("Message: " + content + Environment.NewLine + Environment.NewLine + "Endpoint: " + baseaddress + relativePath + Environment.NewLine + payload + Environment.NewLine + Environment.NewLine + "ApiKey: " + testkey + Environment.NewLine + _client.Timeout + Environment.NewLine + DateTime.Now);

                    if (resssp.StatusCode == HttpStatusCode.BadGateway || resssp.StatusCode == HttpStatusCode.Unauthorized || resssp.StatusCode == HttpStatusCode.BadRequest || resssp.StatusCode == HttpStatusCode.ServiceUnavailable || resssp.StatusCode == HttpStatusCode.InternalServerError || resssp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return JsonConvert.DeserializeObject<U>(content);

                    }
                    return JsonConvert.DeserializeObject<U>(content);


                case VirtualCardsHttpMethodType.Put:
                    var reesp = await _client.PutAsync($"{baseaddress}{relativePath}", message);
                    content = await reesp.Content.ReadAsStringAsync();
                    log.Info("Message: " + content + Environment.NewLine + Environment.NewLine + "Endpoint: " + baseaddress + relativePath + Environment.NewLine + payload + Environment.NewLine + Environment.NewLine + "ApiKey: " + testkey + Environment.NewLine + _client.Timeout + Environment.NewLine + DateTime.Now);

                    try
                    {
                        DateTime requestTime;
                        DateTime responseTime;
                        tblRequestandResponseLogs requestForDb = new tblRequestandResponseLogs();

                        if (reesp.IsSuccessStatusCode)
                        {
                            requestTime = DateTime.Now;
                            responseTime = DateTime.Now;
                            requestForDb = new tblRequestandResponseLogs() { RequestType = "VirtualCards", RequestPayload = JsonConvert.SerializeObject(payload), Response = JsonConvert.SerializeObject(content), RequestTimestamp = DateTime.Now, ResponseTimestamp = DateTime.Now, RequestUrl = baseaddress };
                            _db.tblRequestAndResponse.Add(requestForDb);
                            await _db.SaveChangesAsync();
                        }
                        else
                        {
                            if (reesp.StatusCode == HttpStatusCode.BadGateway || reesp.StatusCode == HttpStatusCode.Unauthorized || reesp.StatusCode == HttpStatusCode.BadRequest || reesp.StatusCode == HttpStatusCode.ServiceUnavailable || reesp.StatusCode == HttpStatusCode.InternalServerError || reesp.StatusCode == HttpStatusCode.NotFound || reesp.StatusCode == HttpStatusCode.Forbidden)
                            {
                                responseTime = DateTime.Now;
                                requestForDb = new tblRequestandResponseLogs() { RequestType = "EnhancedKycVerification", RequestPayload = JsonConvert.SerializeObject(payload), Response = JsonConvert.SerializeObject(content), RequestTimestamp = responseTime, RequestUrl = baseaddress };
                                _db.tblRequestAndResponse.Add(requestForDb);
                                await _db.SaveChangesAsync();
                                return JsonConvert.DeserializeObject<U>(content);


                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Something went wrong", ex);
                    }

                    return JsonConvert.DeserializeObject<U>(content);


                default:

                    var ressp = await _client.GetAsync($"{baseaddress}{relativePath}");
                    content = await ressp.Content.ReadAsStringAsync();
                    log.Info("Message: " + content + Environment.NewLine + Environment.NewLine + "Endpoint: " + baseaddress + relativePath + Environment.NewLine + payload + Environment.NewLine + Environment.NewLine + "ApiKey: " + testkey + Environment.NewLine + _client.Timeout + Environment.NewLine + DateTime.Now);


                    try
                    {
                        DateTime requestTime;
                        DateTime responseTime;
                        tblRequestandResponseLogs requestForDb = new tblRequestandResponseLogs();

                        if (ressp.IsSuccessStatusCode)
                        {
                            requestTime = DateTime.Now;
                            responseTime = DateTime.Now;
                            requestForDb = new tblRequestandResponseLogs() { RequestType = "VirtualCards", RequestPayload = JsonConvert.SerializeObject(payload), Response = JsonConvert.SerializeObject(content), RequestTimestamp = DateTime.Now, ResponseTimestamp = DateTime.Now, RequestUrl = baseaddress };
                            _db.tblRequestAndResponse.Add(requestForDb);
                            await _db.SaveChangesAsync();
                        }
                        else
                        {
                            if (ressp.StatusCode == HttpStatusCode.BadGateway || ressp.StatusCode == HttpStatusCode.Unauthorized || ressp.StatusCode == HttpStatusCode.BadRequest || ressp.StatusCode == HttpStatusCode.ServiceUnavailable || ressp.StatusCode == HttpStatusCode.InternalServerError || ressp.StatusCode == HttpStatusCode.NotFound || ressp.StatusCode == HttpStatusCode.Forbidden)
                            {
                                responseTime = DateTime.Now;
                                requestForDb = new tblRequestandResponseLogs() { RequestType = "EnhancedKycVerification", RequestPayload = JsonConvert.SerializeObject(payload), Response = JsonConvert.SerializeObject(content), RequestTimestamp = responseTime, RequestUrl = baseaddress };
                                _db.tblRequestAndResponse.Add(requestForDb);
                                await _db.SaveChangesAsync();
                                return JsonConvert.DeserializeObject<U>(content);


                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Something went wrong", ex);
                    }

                    return JsonConvert.DeserializeObject<U>(content);


            }

        }


    }
}
