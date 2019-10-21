using System.Threading.Tasks;
using LongPollExample.WebApi.LongPoll;
using Microsoft.AspNetCore.Mvc;

namespace LongPollExample.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PollController : ControllerBase
    {
        [HttpGet("{key}")]
        public async Task<object> Get(string key, [FromServices] LongPollController longPollController)
        {
            var taskCompletionSource = new TaskCompletionSource<object>();

            void Published(object sender, LongPollPublishedEventArgs args)
            {
                if (key == args.Key)
                {
                    taskCompletionSource.SetResult(args.Value);
                }

                longPollController.Published -= Published;
            }

            longPollController.Published += Published;

            return await taskCompletionSource.Task;
        }
    }
}
