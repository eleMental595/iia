using iia.contracts.interfaces;
using iia.contracts.Models;
using iia.DataService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iia.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private IDataService _dataService;

        public CategoryService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<Categories> AddCategory(CategoryRequest categoryRequest)
        {
             var result = await _dataService.GetResults<EntityEntry<Categories>>(async (dataContext) =>
             {
                 Categories NewCategory = new Categories(){Category_Name = categoryRequest.Category, Vat = categoryRequest.Vat};
                 var category = await dataContext.Categories.AddAsync(NewCategory);
                 await dataContext.SaveChangesAsync();
                 return category;
             });

             return result.Entity;
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

 public async Task<Categories> UpdateCategory(CategoryRequest categoryRequest)
       {
           var result = await _dataService.GetResults<EntityEntry<Categories>>(async (dataContext) =>
           {
               Categories CategoryToUpdate = new Categories() { Category_Name = categoryRequest.Category, Vat = categoryRequest.Vat };
               var entity = await dataContext.Categories.FindAsync(categoryRequest.Id);
               if (entity != null)
               {
                   entity.Category_Name = CategoryToUpdate.Category_Name;
                   entity.Vat = CategoryToUpdate.Vat;
                   var updatedCategory = dataContext.Categories.Update(entity);
                   await dataContext.SaveChangesAsync();
                   return updatedCategory;
               }
               else
               {
                   throw new Exception("Record not found");
               }
           });

           return result.Entity;
       }

    }
}
