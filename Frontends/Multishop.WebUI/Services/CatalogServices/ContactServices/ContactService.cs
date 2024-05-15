using Multishop.WebDTO.DTOs.CatalogDtos.ContactDtos;

namespace Multishop.WebUI.Services.CatalogServices.ContactServices
{
    public class ContactService(HttpClient _client) : IContactService
    {
        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            await _client.PostAsJsonAsync("contacts", createContactDto);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _client.DeleteAsync("contacts/" + id);
        }

        public async Task<List<ResultContactDto>> GetAllContactsAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultContactDto>>("contacts");
        }

        public async Task<UpdateContactDto> GetContactByIdAsync(string id)
        {
            return await _client.GetFromJsonAsync<UpdateContactDto>("contacts/" + id);
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            await _client.PutAsJsonAsync("contacts", updateContactDto);
        }
    }
}
