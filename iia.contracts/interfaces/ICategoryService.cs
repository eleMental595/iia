using iia.contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iia.contracts.interfaces
{
    public interface ICategoryService
    {
        Task<Categories> GetCategoriesAsync();

        Task AddCategory(CategoryRequest categoryRequest);

        Task UpdateCategory(string categoryId, CategoryRequest categoryRequest);

        Task DeleteCategory(string categoryId);

    }
}
