using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MFPE_PolicyMicroService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.IdentityModel.JsonWebTokens;

namespace MFPE_PolicyMicroService.Controllers
{

    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        
        private readonly DemoContext Context;
        public string token;
        public PolicyController(DemoContext Context)
        {
            this.Context = Context;
            //token = HttpContext.Session.GetString("token");

        }
        

        // [HttpPost("CreatePolicy")]
        [HttpPost("CreatePolicy")]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<bool> CreatePolicy(ConsumerPolicyDetails cpd)
      {

            
            Consumer cm = new Consumer();
            ConsumerPolicy pm = new ConsumerPolicy();
            List<Quotes> quotes = new List<Quotes>();

            int consumerid = cpd.ConsumerId;

            //Retriving Data From QuotesMicroservice
            
            
            using (var client = new HttpClient())
            {
                string token = HttpContext.Session.GetString("JWToken");
               

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                client.BaseAddress = new Uri("https://localhost:44387/api/");
                var result = await client.GetAsync("Quotes");

                if (result.IsSuccessStatusCode)
                {
                    //var readTask = result.Content.ReadAsAsync<BusinessMaster>();
                    var jsoncontent = await result.Content.ReadAsStringAsync();
                    List<Quotes> quo = JsonConvert.DeserializeObject<List<Quotes>>(jsoncontent);
                    //readTask.Wait();
                    quotes = quo;
                }

            }

            //Retriving Data From ConsumerMicroservice
            using (var client = new HttpClient())
            {
                string token = HttpContext.Session.GetString("JWToken");

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                client.BaseAddress = new Uri("https://localhost:44369/api/");
                //HTTP GET
                var result = await client.GetAsync("Consumer/{consumerid}?consumerid="+consumerid);
                if (result.IsSuccessStatusCode)
                {
                    //var readTask = result.Content.ReadAsAsync<BusinessMaster>();
                    var jsoncontent = await result.Content.ReadAsStringAsync();
                    Consumer consumer = JsonConvert.DeserializeObject<Consumer>(jsoncontent);
                    //readTask.Wai
                    cm = consumer;
                }
            }
           

            foreach (var quote in quotes)
            {
                if (cm.Business.BusinessMaster.BussinessValue >= quote.BussinessValueFrom && cm.Business.BusinessMaster.BussinessValue <= quote.BussinessValueTo)
                {

                    if (cm.Business.BusinessMaster.BussinessValue ==5 )
                    {

                        ConsumerPolicy policy1 = new ConsumerPolicy() {

                            BussinessName = cpd.BussinessName,
                            BussinessType = cpd.BussinessType,
                            ConsumerId = cpd.ConsumerId,
                            ConsumerName = cpd.ConsumerName,
                            PolicyStatus = false,
                        PolicyMaster=
                        new PolicyMaster()
                        {
                            BussinessValue = cm.Business.BusinessMaster.BussinessValue,
                        PropertyType = "Building",
                        ConsumerType = "Owner",
                        AssuredSum = 2000000,
                        Tenure = "3 years",
                        BaseLocation = "Chennai",
                        Type = "Replacement"

                    }
                        

                    };
                        

                        //Policy.PropertyValue = bm.PropertyValue;
                        Context.ConsumerPolicies.Add(policy1);
                        int count = await Context.SaveChangesAsync();
                        return count >= 0;

                    }
                    else if(cm.Business.BusinessMaster.BussinessValue>5)
                    {

                        ConsumerPolicy policy1 = new ConsumerPolicy()
                        {

                            BussinessName = cpd.BussinessName,
                            BussinessType = cpd.BussinessType,
                            ConsumerId = cpd.ConsumerId,
                            ConsumerName = cpd.ConsumerName,
                            PolicyStatus = false,
                            PolicyMaster =
                        new PolicyMaster()
                        {
                            BussinessValue = cm.Business.BusinessMaster.BussinessValue,
                            PropertyType = "Building",
                            ConsumerType = "Owner",
                            AssuredSum = 2000000,
                            Tenure = "3 years",
                            BaseLocation = "Chennai",
                            Type = "Replacement"

                        }


                        };

                        //Policy.PropertyValue = bm.PropertyValue;
                        Context.ConsumerPolicies.Add(policy1);
                        int count = await Context.SaveChangesAsync();
                        return count >= 0;

                    }
                    else
                    {
                        ConsumerPolicy policy1 = new ConsumerPolicy()
                        {

                            BussinessName = cpd.BussinessName,
                            BussinessType = cpd.BussinessType,
                            ConsumerId = cpd.ConsumerId,
                            ConsumerName = cpd.ConsumerName,
                            PolicyStatus = false,
                            PolicyMaster =
                       new PolicyMaster()
                       {
                           BussinessValue = cm.Business.BusinessMaster.BussinessValue,
                           PropertyType = "Building",
                           ConsumerType = "Owner",
                           AssuredSum = 2000000,
                           Tenure = "3 years",
                           BaseLocation = "Chennai",
                           Type = "Replacement"

                       }


                        };
                            
                        Context.ConsumerPolicies.Add(policy1);
                        int count = await Context.SaveChangesAsync();
                        return count >= 0;
                    }
                    

                }
            }







            return true;

            //return new CreatedResult("Policy Initiated", new { id = pm.ID });
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("ViewConsumerPolicyById")]
        public async Task<ConsumerPolicy> ViewConsumerPolicyById(int consumerId)
        {
            var consumer1 = await Context.ConsumerPolicies.Include(t => t.PolicyMaster).FirstOrDefaultAsync(t => t.ConsumerId == consumerId);


            return consumer1;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("IssueConsumerPolicy")]
        public async Task<bool> IssueConsumerPolicy(IssuePolicy issuePolicy)
        {
            var con1 = await Context.ConsumerPolicies.Include(t => t.PolicyMaster).FirstOrDefaultAsync(t => t.ConsumerId==issuePolicy.CustomerId);

            con1.PolicyStatus = true;

            var count = await Context.SaveChangesAsync();
            return count > 0;
            //throw new NotImplementedException();
        }

    }
}