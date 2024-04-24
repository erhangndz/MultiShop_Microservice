using Multishop.Catalog.Entities;
using Multishop.Catalog.Settings;

namespace Multishop.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService : GenericRepository<SpecialOffer>, ISpecialOfferService
    {
        public SpecialOfferService(IDatabaseSettings settings) : base(settings)
        {
        }
    }
}
