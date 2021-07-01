using DataAccess;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class ImageService
    {
        private readonly Context context;

        public ImageService(Context _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Image>> GetAllImage()
        {
            return await context.Image.ToListAsync();
        }

        //Get/{id}
        public async Task<Image> GetByIdImage(int? id)
        {
            return await context.Image.FindAsync(id);
        }

        //Post
        public async Task<Image> PostImage(Image data)
        {
            context.Image.Add(data);
            await context.SaveChangesAsync();
            return data;
        }

        //Put
        public async Task<Image> PutImage(Image data)
        {
            context.Entry(data).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return data;
        }

        //Delete
        public async Task<Image> DeleteImage(int? id)
        {
            var data = await context.Image.FindAsync(id);
            context.Remove(data);
            await context.SaveChangesAsync();
            return data;
        }

        //Get/{username}
        public async Task<Image> GetByIdImage(string? username)
        {
            return await context.Image.Where(image => image.Username == username).FirstOrDefaultAsync();
        }
    }
}
