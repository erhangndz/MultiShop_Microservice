namespace Multishop.Catalog.Entities
{
    public class FeatureSlider: BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsShown { get; set; }
    }
}
