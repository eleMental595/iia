using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iia.contracts.interfaces;
using iia.contracts.Models;
using iia.DataService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace iia.ProductService
{
    public class ProductService : IProductService
    {
        private IDataService _dataService;

        public ProductService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<List<Products>> GetProductsAsync()
        {
            return await _dataService.GetResults<List<Products>>(async (dataContext) =>
             {
                 return await dataContext.Products.ToListAsync();
             });
        }

        public async Task<Products> AddProduct(Products productRequest)
        {
            var result = await _dataService.GetResults<EntityEntry<Products>>(async (dataContext) =>
            {
                var product = await dataContext.Products.AddAsync(productRequest);
                await dataContext.SaveChangesAsync();
                return product;
            });

            return result.Entity;
        }

        public async Task<Products> UpdateProduct(Products productRequest)
        {
            var result = await _dataService.GetResults<EntityEntry<Products>>(async (dataContext) =>
            {
                var entity = await dataContext.Products.FindAsync(productRequest.Id);
                if (entity != null)
                {
                    entity.Category = productRequest.Category;
                    entity.Cost = productRequest.Cost;
                    entity.ExpiryDate = productRequest.ExpiryDate;
                    entity.NameArabic = productRequest.NameArabic;
                    entity.ProductName = productRequest.ProductName;
                    entity.SellingPrice = productRequest.SellingPrice;
                    entity.Unit = productRequest.Unit;
                    entity.Batch = productRequest.Batch;
                    var updatedProduct = dataContext.Products.Update(entity);
                    await dataContext.SaveChangesAsync();
                    return updatedProduct;
                }
                else
                {
                    throw new Exception("Record not found");
                }
            });

            return result.Entity;
        }

        public async Task DeleteProduct(int Id)
        {
            var result = await _dataService.GetResults<EntityEntry<Products>>(async (dataContext) =>
            {
                Products ProductToDelete = new Products() { Id = Id };
                dataContext.Products.Attach(ProductToDelete);
                var DeletedProduct = dataContext.Products.Remove(ProductToDelete);
                await dataContext.SaveChangesAsync();
                return DeletedProduct;
            });
        }

    }
}
