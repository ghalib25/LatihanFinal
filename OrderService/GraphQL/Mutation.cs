using HotChocolate.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Models;
using Newtonsoft.Json;
using OrderService.Models;
using System.Security.Claims;

namespace OrderService.GraphQL
{
    public class Mutation
    {
        //[Authorize]
        public async Task<OrderOutput> SubmitOrderAsync(
            OrderData input,
            [Service] IOptions<KafkaSettings> settings)
        {
            var dts = DateTime.Now.ToString();
            var key = "order-" + dts;
            var val = JsonConvert.SerializeObject(input);

            var result = await KafkaHelper.SendMessage(settings.Value, "simpleorder", key, val);

            OrderOutput resp = new OrderOutput
            {
                TransactionDate = dts,
                Message = "Order was submitted successfully"
            };

            if (!result)
                resp.Message = "Failed to submit data";

            return await Task.FromResult(resp);
        }

    }
}
