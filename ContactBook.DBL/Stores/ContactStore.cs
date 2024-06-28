using ContactBook.DBL.Models;
using ContactBook.DBL.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Drawing.Imaging;

namespace ContactBook.DBL.Stores
{
    public class ContactStore
    {
        private readonly ContactDBContext _dbContext;

        public ContactStore(ContactDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Contacts> GetContactsById(int id)
        {
            return await _dbContext.tblContacts
                 .AsNoTracking()
                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Contacts>> GetContactsByFilters(string filter)
        {
            IQueryable<Contacts> query = _dbContext.tblContacts.AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(c =>
                    EF.Functions.Like(c.FirstName, $"%{filter}%") ||
                    EF.Functions.Like(c.LastName, $"%{filter}%") ||
                    EF.Functions.Like(c.Company, $"%{filter}%") ||
                    EF.Functions.Like(c.Phone, $"%{filter}%") ||
                    EF.Functions.Like(c.Email, $"%{filter}%") ||
                    EF.Functions.Like(c.Address, $"%{filter}%") ||
                    EF.Functions.Like(c.Note, $"%{filter}%") ||
                    c.birthdate.ToString().Contains(filter) 
                );
            }
            query = query.OrderBy(x => x.FirstName);

            return await query.ToListAsync();
        }
        private string GetColumnsList()
        {
            var entityType = _dbContext.Model.FindEntityType(typeof(Contacts));
            var columns = entityType.GetProperties()
                                    .Where(p => p.PropertyInfo != null)
                                    .Select(p => $"COALESCE({p.GetColumnName()}, '')") // Use COALESCE to handle NULL values
                                    .ToList();

            return string.Join(" + ' ' + ", columns);
        }

        public async Task<Contacts> Add(Contacts contacts)
        {
            if (contacts.ProfileImage == null)
            {
                contacts.ProfileImage = GenerateImage.GenerateAvatar(contacts.FirstName, contacts.LastName);
            }
            _dbContext.tblContacts.Add(contacts);
            await _dbContext.SaveChangesAsync();
            return contacts;
        }

        public async Task<Contacts> Update(Contacts contacts)
        {
            if (contacts.ProfileImage == null)
            {
                contacts.ProfileImage = GenerateImage.GenerateAvatar(contacts.FirstName, contacts.LastName);
            }
            _dbContext.tblContacts.Update(contacts);
            await _dbContext.SaveChangesAsync();
            return contacts;
        }

        public async Task<bool> Remove(int id)
        {
            var contacts = _dbContext.tblContacts.Where(a => a.Id == id).FirstOrDefault();
            _dbContext.tblContacts.Remove(contacts);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        //public static byte[] GenerateAvatar(string firstName, string lastName)
        //{
        //    int width = 100;
        //    int height = 100;
        //    Bitmap bitmap = new Bitmap(width, height);

        //    using (Graphics g = Graphics.FromImage(bitmap))
        //    {
        //        g.Clear(Color.LightGray);

        //        string initials = $"{firstName[0]}{lastName[0]}";
        //        using (System.Drawing.Font font = new System.Drawing.Font("Arial", 40, FontStyle.Bold, GraphicsUnit.Pixel))
        //        {
        //            SizeF textSize = g.MeasureString(initials, font);
        //            PointF position = new PointF((width - textSize.Width) / 2, (height - textSize.Height) / 2);
        //            g.DrawString(initials, font, Brushes.Black, position);
        //        }
        //    }

        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        bitmap.Save(ms, ImageFormat.Png);
        //        byte[] imageBytes = ms.ToArray();
        //        return imageBytes;
        //    }
        //}
    }
}
