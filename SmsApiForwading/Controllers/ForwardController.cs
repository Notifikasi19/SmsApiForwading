using SmsApiForwading.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace SmsApiForwading.Controllers
{
    public class ForwardController : ApiController
    {
        [Route("api/Forward/SendMessage")]
        [HttpPost]
        public async Task<HttpResponseMessage> SendMessage(ResquestSMS resquestSMS)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["SMSENDPOINT"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("IMWS1", "key = " + ConfigurationManager.AppSettings["SMSAPIKEY"]);
                client.DefaultRequestHeaders.Add("X-Impact-Fail-Fast", "false");
                client.DefaultRequestHeaders.Add("X-Impact-Response-Detail", "standard");
                RequestMessage request = new RequestMessage();
                request.messages.Add(new Message()
                {
                    content = new Content() { body = "MyhomeWallet by Ecohome Financial: " + resquestSMS.messagebody + " StdMsg&DataRtsAply Txt STOP to stop INFO for info" },
                    sendDate = DateTime.Now,
                    validUntil = DateTime.Now.AddMinutes(5),
                    to = new To() { subscriber = new Subscriber() { phone = resquestSMS.phonenumber } },
                    tracking = new Tracking() { code = "try123" }
                });

                return await client.PostAsJsonAsync("media/ws/rest/mbox/v1/reference/" + System.Configuration.ConfigurationManager.AppSettings["SubscriptionRef"] + "/message", request);
            }
        }
    }
}
