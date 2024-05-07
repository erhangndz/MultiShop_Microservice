namespace Multishop.WebUI.Settings
{
    public class ClientSettings
    {
        public Client MultishopVisitorClient { get; set; }
        public Client MultishopManagerClient { get; set; }
        public Client MultishopAdminClient { get; set; }






        public class Client
        {
            public string  ClientId { get; set; }
            public string  ClientSecret { get; set; }
        }
    }
}
