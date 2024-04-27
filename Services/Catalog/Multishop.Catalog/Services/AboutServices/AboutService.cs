using Multishop.Catalog.Entities;
using Multishop.Catalog.Settings;

namespace Multishop.Catalog.Services.AboutServices
{
    public class AboutService : GenericRepository<About>, IAboutService
    {
        public AboutService(IDatabaseSettings settings) : base(settings)
        {
        }
    }
}
