namespace Multishop.Catalog.Settings
{
    public interface IDatabaseSettings
    {
        public string Category { get; set; }
        public string Product { get; set; }
        public string ProductPhoto { get; set; }
        public string ProductDetail { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
