using Multishop.WebDTO.DTOs.CatalogDtos.ContactDtos;

namespace Multishop.WebUI.Services.CatalogServices.ContactServices
{
    public interface IContactService
    {

        Task<List<ResultContactDto>> GetAllContactsAsync();

        Task CreateContactAsync(CreateContactDto createContactDto);
        Task UpdateContactAsync(UpdateContactDto updateContactDto);

        Task DeleteContactAsync(string id);

        Task<UpdateContactDto> GetContactByIdAsync(string id);
    }
}
