using iia.contracts.interfaces;
using iia.contracts.Models;
using iia.DataService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iia.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private IDataService _dataService;
        private DataContext _dataContext;

        public CategoryService(IDataService dataService, DataContext dataContext)
        {
            _dataService = dataService;
            _dataContext = dataContext;
        }

        public Task AddCategory(CategoryRequest categoryRequest)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Categories>> GetCategoriesAsync()
        {
            return await _dataService.GetResults<List<Categories>>(async (dataContext) =>
             {
                 return await dataContext.Categories.ToListAsync();
             });
        }

        public Task UpdateCategory(string categoryId, CategoryRequest categoryRequest)
        {
            throw new NotImplementedException();
        }

    }
}
