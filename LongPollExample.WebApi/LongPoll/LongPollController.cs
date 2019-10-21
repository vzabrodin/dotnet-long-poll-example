using System;

namespace LongPollExample.WebApi.LongPoll
{
    public class LongPollController
    {
        public event EventHandler<LongPollPublishedEventArgs> Published = delegate { };

        public void Publish(string key, string value) => Published(this, new LongPollPublishedEventArgs(key, value));
    }
}
