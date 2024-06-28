using System.Drawing;
using System.Drawing.Imaging;

namespace ContactBook.DBL.Utilities
{
    /// <summary>
    /// Generate Image.
    /// </summary>
    public static class GenerateImage
    {
        public static byte[] GenerateAvatar(string firstName, string lastName)
        {
            int width = 100;
            int height = 100;
            Bitmap bitmap = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.LightGray);

                string initials = $"{firstName[0]}{lastName[0]}";
                using (System.Drawing.Font font = new System.Drawing.Font("Arial", 40, FontStyle.Bold, GraphicsUnit.Pixel))
                {
                    SizeF textSize = g.MeasureString(initials, font);
                    PointF position = new PointF((width - textSize.Width) / 2, (height - textSize.Height) / 2);
                    g.DrawString(initials, font, Brushes.Black, position);
                }
            }

            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }
    }
}
