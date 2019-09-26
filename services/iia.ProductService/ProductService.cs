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

        public async Task<Products> AddProduct(ProductRequest productRequest)
        {
            var result = await _dataService.GetResults<EntityEntry<Products>>(async (dataContext) =>
            {
                Products NewProduct = new Products() { Product_Name = productRequest.Product_Name };
                var product = await dataContext.Products.AddAsync(NewProduct);
                await dataContext.SaveChangesAsync();
                return product;
            });

            return result.Entity;
        }

        public Task DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<Products> UpdateProduct(ProductRequest productRequest)
        {
            throw new NotImplementedException();
        }
    }
}
