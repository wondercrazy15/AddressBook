using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactBook.DBL.Models
{
    [PrimaryKey("Id")]
    public class Contacts
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("FisrtName", TypeName = "varchar(50)")] 
        public string FirstName { get; set; } = string.Empty;

        [Column("LastName", TypeName = "varchar(50)")]
        public string LastName { get; set; } = string.Empty;

        [Column("ProfileImage", TypeName = "VARBINARY(max)")]
        public byte[]? ProfileImage { get; set; } 

        [Column("Company", TypeName = "varchar(200)")]
        public string? Company { get; set; } 

        [Column("Phone", TypeName = "varchar(20)")]
        public string Phone { get; set; } 

        [Column("Email", TypeName = "varchar(100)")]
        public string? Email { get; set; } 

        [Column("Address", TypeName = "varchar(max)")]
        public string? Address { get; set; } 

        [Column("Latitude", TypeName = "decimal(9,6)")]
        public decimal? Latitude { get; set; }

        [Column("Longitude", TypeName = "decimal(9,6)")]
        public decimal? Longitude { get; set; }

        [Column("birthdate", TypeName = "DateTime")]
        public DateTime? birthdate { get; set; }

        [Column("Note", TypeName = "varchar(max)")]
        public string? Note { get; set; } 
    }
}
