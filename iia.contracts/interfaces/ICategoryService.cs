using iia.contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iia.contracts.interfaces
{
    public interface ICategoryService
    {
        Task<List<Categories>> GetCategoriesAsync();

        Task<Categories> AddCategory(CategoryRequest categoryRequest);

        Task<Categories> UpdateCategory(CategoryRequest categoryRequest);

        Task DeleteCategory(string categoryId);

    }
}
