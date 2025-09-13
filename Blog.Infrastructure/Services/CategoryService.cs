using Blog.Core.Interfaces;
using Blog.Core.Models;
using Blog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        // DI
        private readonly AppDbContext _context;
        public CategoryService (AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return  await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
            //return await _context.Categories.FirstAsync(c => c.CatId == id);
            //return await _context.Categories.LastAsync(c => c.CatId == id);
            //return await _context.Categories.SingleAsync(c => c.CatId == id);
            //return await _context.Categories.FirstOrDefaultAsync(c => c.CatId == id);
            //return await _context.Categories.LastOrDefaultAsync(c => c.CatId == id);
            //return await _context.Categories.SingleOrDefaultAsync(c => c.CatId == id);
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public Task<bool> UpdateAsync(int id, Category category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Category category)
        {
            throw new NotImplementedException();
        }

        

        
    }
}
