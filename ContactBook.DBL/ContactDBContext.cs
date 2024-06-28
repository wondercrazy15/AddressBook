using ContactBook.DBL.Models;
using ContactBook.DBL.Utilities;
using Microsoft.EntityFrameworkCore;

namespace ContactBook.DBL
{
    public class ContactDBContext : DbContext
    {
        public ContactDBContext(DbContextOptions<ContactDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Contacts> tblContacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Contacts>()
            .HasData(
                    new Contacts
                    {
                        Id = 1,
                        FirstName = "Jonathan",
                        LastName = "Corbett",
                        Company = "Test Company",
                        Phone = "1234567891",
                        Email = "Jonathan@gmail.com",
                        ProfileImage = GenerateImage.GenerateAvatar("Jonathan", "Corbett")
                    }
            );

        }
    }
}
