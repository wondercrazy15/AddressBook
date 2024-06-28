using ContactBook.Services.Models;
using System.ComponentModel.DataAnnotations;

namespace ContactBook.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "Required")]
        public ContactsModel contactsModel { get; set; }
        public List<ContactsModel> Contacts { get; set; } = new List<ContactsModel>();
    }
}
