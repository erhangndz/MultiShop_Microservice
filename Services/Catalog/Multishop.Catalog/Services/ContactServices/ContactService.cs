using Multishop.Catalog.Entities;
using Multishop.Catalog.Settings;

namespace Multishop.Catalog.Services.ContactServices
{
    public class ContactService : GenericRepository<Contact>, IContactService
    {
        public ContactService(IDatabaseSettings settings) : base(settings)
        {
        }
    }
}
