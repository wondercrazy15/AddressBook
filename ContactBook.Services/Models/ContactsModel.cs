using System.ComponentModel.DataAnnotations;

namespace ContactBook.Services.Models
{
    public class ContactsModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter last name.")]
        public string LastName { get; set; } = string.Empty ;

        public Byte[]? ProfileImage { get; set; }

        public string? Company { get; set; }

        [Required(ErrorMessage = "Enter Phone number.")]
        public string Phone { get; set; } = string.Empty;

        public string? Email { get; set; } 

        public string? Address { get; set; } 

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public DateTime? birthdate { get; set; }

        public string? Note { get; set; }

        public string? ImageUrl { get; set; }
    }
}
