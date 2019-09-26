using iia.contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iia.contracts.interfaces
{
    public interface IProductService
    {
        Task<List<Products>> GetProductsAsync();

        Task<Products> AddProduct(ProductRequest productRequest);

        Task<Products> UpdateProduct(ProductRequest productRequest);

        Task DeleteProduct(int productId);

    }
}
