namespace Multishop.Basket.Settings
{
    public class RedisSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }

        public RedisSettings(string host, int port)
        {
            Host = host;
            Port = port;
        }
    }
}
