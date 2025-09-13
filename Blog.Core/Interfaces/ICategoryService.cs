using Blog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Interfaces
{
    public interface ICategoryService
    {
        // Get All
        Task<IEnumerable<Category>> GetAllAsync();
        // Get By Id
        Task<Category> GetByIdAsync(int id);
        // Create
        Task<Category> CreateAsync(Category category);
        // Update
        Task<bool> UpdateAsync(int id, Category category);
        Task<bool> UpdateAsync(Category category);
        // Delete
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(Category category);
    }
}
