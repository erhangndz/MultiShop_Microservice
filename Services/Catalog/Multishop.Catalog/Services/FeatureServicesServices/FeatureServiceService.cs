using Multishop.Catalog.Entities;
using Multishop.Catalog.Settings;

namespace Multishop.Catalog.Services.FeatureServicesServices
{
    public class FeatureServiceService : GenericRepository<FeatureService>, IFeatureServiceService
    {
        public FeatureServiceService(IDatabaseSettings settings) : base(settings)
        {
        }
    }
}
