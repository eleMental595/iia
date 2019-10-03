using iia.contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iia.contracts.interfaces
{
    public interface IPurchaseService
    {
        Task<List<Purchase>> GetPurchasesAsync();

        Task<Purchase> AddPurchaseEntryAsync(PurchaseEntryRequest productRequest);

        Task<PurchaseEntryRequest> GetPurchaseByIdAsync(int id);

    }
}
