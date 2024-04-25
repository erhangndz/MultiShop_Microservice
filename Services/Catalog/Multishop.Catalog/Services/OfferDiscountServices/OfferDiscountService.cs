using Multishop.Catalog.Entities;
using Multishop.Catalog.Settings;

namespace Multishop.Catalog.Services.OfferDiscountServices
{
    public class OfferDiscountService : GenericRepository<OfferDiscount>, IOfferDiscountService
    {
        public OfferDiscountService(IDatabaseSettings settings) : base(settings)
        {
        }
    }
}
