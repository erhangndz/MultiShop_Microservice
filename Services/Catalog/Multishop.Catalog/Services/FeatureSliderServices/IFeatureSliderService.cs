using Multishop.Catalog.Entities;

namespace Multishop.Catalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderService: IRepository<FeatureSlider>
    {
        Task ShowOnHomeAsync(string id);
        Task DontShowOnHomeAsync(string id);
    }
}
