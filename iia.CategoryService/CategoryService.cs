using iia.contracts.interfaces;
using iia.contracts.Models;
using System;
using System.Threading.Tasks;

namespace iia.CategoryService
{
    public class CategoryService : ICategoryService
    {
        public Task AddCategory(CategoryRequest categoryRequest)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<Categories> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategory(string categoryId, CategoryRequest categoryRequest)
        {
            throw new NotImplementedException();
        }
    }
}
