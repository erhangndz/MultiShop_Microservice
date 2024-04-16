namespace Multishop.Catalog.Settings
{
    public interface IDatabaseSettings
    {

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
