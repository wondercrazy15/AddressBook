using AutoMapper;
using ContactBook.DBL.Models;
using ContactBook.DBL.Stores;
using ContactBook.Services.Interfaces;
using ContactBook.Services.Models;

namespace ContactBook.Services.Services
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly ContactStore _contactStore;
        private readonly IServiceProvider _serviceProvider;

        public ContactService(
            IMapper mapper,
            ContactStore contactStore,
            IServiceProvider serviceProvider
            )
        {
            _mapper = mapper;
            _contactStore = contactStore;
            _serviceProvider = serviceProvider;
        }
        public async Task<ContactsModel> GetContectsByIdAsync(int id)
        {
            var Contact = await _contactStore.GetContactsById(id);
            return _mapper.Map<ContactsModel>(Contact);
        }
        public async Task<List<ContactsModel>> GetContactsByFiltersAsync(string filter)
        {
            var contacts = await _contactStore.GetContactsByFilters(filter);
            var data = _mapper.Map<List<ContactsModel>>(contacts);
            return data;
        }

        public async Task<ContactsModel> Add(ContactsModel contact)
        {
            var contacts = _mapper.Map<Contacts>(contact);
            contacts.ProfileImage = contact.ProfileImage;
            contacts = await _contactStore.Add(contacts);
            return _mapper.Map<ContactsModel>(contacts);
        }

        public async Task<ContactsModel> Update(ContactsModel contact)
        {
            var existingContact = await _contactStore.GetContactsById(contact.Id);
            if (existingContact != null)
            {
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;
                existingContact.Address = contact.Address;
                existingContact.birthdate = contact.birthdate;
                existingContact.Email = contact.Email;
                existingContact.Company = contact.Company;
                existingContact.Phone = contact.Phone;
                existingContact.Address = contact.Address;
                if (contact.ProfileImage != null)
                {
                    existingContact.ProfileImage = contact.ProfileImage;
                }


                existingContact.Longitude = Convert.ToDecimal(contact.Longitude);
                existingContact.Latitude = Convert.ToDecimal(contact.Latitude);
                existingContact = await _contactStore.Update(existingContact);
                return _mapper.Map<ContactsModel>(existingContact);
            }
            return null;
        }
        public async Task<bool> Delete(int id)
        {
            bool isDeleted = await _contactStore.Remove(id);
            return isDeleted;
        }
    }
}
