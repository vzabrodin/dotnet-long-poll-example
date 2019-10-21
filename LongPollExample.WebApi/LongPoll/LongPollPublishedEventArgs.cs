namespace LongPollExample.WebApi.LongPoll
{
    public class LongPollPublishedEventArgs : System.EventArgs
    {
        public LongPollPublishedEventArgs(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; }

        public string Value { get; }
    }
}
