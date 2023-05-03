using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;


namespace SESWebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SESController : ControllerBase
    {
        private readonly IAmazonSimpleEmailService _amazonSimpleEmailService;
        private string _fromAddress = "aefaustino.aws22@gmail.com";
        private string _toAddress = "aefaustino@gmail.com";
        private string _subject = "SES";
        private string _body = "<h1>It Worked!</h1> <p>So Happy!</p>";

        public SESController(IAmazonSimpleEmailService amazonSimpleEmailService)
        {
            _amazonSimpleEmailService = amazonSimpleEmailService;
        }

        public async Task<ActionResult> SendEmail()
        {
            SendEmailRequest sendEmailRequest = new SendEmailRequest()
            {
                Destination = new Destination() { ToAddresses = new List<string>() { _toAddress } },
                Source = _fromAddress,
                Message = new Message()
                {
                    Subject = new Content()
                    {
                        Charset = "UTF-8",
                        Data = _subject
                    },
                    Body = new Body()
                    {
                        Html = new Content()
                        {
                            Charset = "UTF-8",
                            Data = _body
                        }
                    }
                }
            };

            var sendResult =
                await _amazonSimpleEmailService.SendEmailAsync(sendEmailRequest);

            if (sendResult.HttpStatusCode != System.Net.HttpStatusCode.OK)
            {
                return BadRequest("Something went wrong!");
            }

            return Ok("Hi");
        }
    }
}
