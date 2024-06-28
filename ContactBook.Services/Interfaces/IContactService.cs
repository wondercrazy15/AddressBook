using ContactBook.Services.Models;

namespace ContactBook.Services.Interfaces
{
    public interface IContactService
    {
        Task<ContactsModel> GetContectsByIdAsync(int id);

        Task<List<ContactsModel>> GetContactsByFiltersAsync(string Contact);

        Task<ContactsModel> Add(ContactsModel vehicle);

        Task<ContactsModel> Update(ContactsModel vehicle);
    }
}
