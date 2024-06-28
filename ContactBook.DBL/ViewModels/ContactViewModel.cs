namespace ContactBook.DBL.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public byte[]? ProfileImage { get; set; }

        public string Company { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public DateTime? birthdate { get; set; }

        public string Note { get; set; } = string.Empty;
    }
}
