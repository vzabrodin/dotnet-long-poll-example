using LongPollExample.WebApi.LongPoll;
using Microsoft.AspNetCore.Mvc;

namespace LongPollExample.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublishController : Controller
    {
        [HttpGet("{key}/{value}")]
        public ActionResult Get(string key, string value, [FromServices] LongPollController longPollController)
        {
            longPollController.Publish(key, value);
            return Ok($"Value \"{value}\" for key \"{key}\" is successfully published");
        }
    }
}
