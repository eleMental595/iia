using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iia.contracts.interfaces;
using iia.contracts.Models;
using iia.DataService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace iia.PurchaseService
{
    public class PurchaseService : IPurchaseService
    {
        private IDataService _dataService;

        public PurchaseService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<List<Purchase>> GetPurchasesAsync()
        {
            return await _dataService.GetResults<List<Purchase>>(async (dataContext) =>
            {
                return await dataContext.Purchases.ToListAsync();
            });
        }

        public async Task<Purchase> AddPurchaseEntryAsync(PurchaseEntryRequest productRequest)
        {
            var purchase = new Purchase()
            {
                Id = productRequest.Id,
                VendorId = productRequest.VendorId,
                VendorName = productRequest.VendorName,
                InvoiceNumber = productRequest.InvoiceNumber,
                NetAmount = productRequest.NetAmount,
                VatAmount = productRequest.VatAmount,
                TotalAmount = productRequest.TotalAmount,
                RecievedBy = productRequest.RecievedBy
            };

            var result = await _dataService.GetResults<EntityEntry<Purchase>>(async (dataContext) =>
            {
                var product = await dataContext.Purchases.AddAsync(purchase);
                await dataContext.SaveChangesAsync();
                return product;
            });

            var purchaseId = result.Entity.Id;

            productRequest.PurchaseProducts.ForEach(x =>
            {
                x.PurchaseId = purchaseId;
            });

             var productresult = await _dataService.GetResults<bool>(async (dataContext) =>
             {
                 await dataContext.PurchaseProducts.AddRangeAsync(productRequest.PurchaseProducts);
                 await dataContext.SaveChangesAsync();
                 return true;
             });
            
            return result.Entity;
        }
    }
}
