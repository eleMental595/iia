using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iia.contracts.interfaces;
using iia.contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace iia.DataService
{
    public class DataService : IDataService
    {
        private DataContext _dataContext;

        public DataService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<TResult> GetResults<TResult>(Func<DataContext, Task<TResult>> func)
        {
            try
            {
                return await func(_dataContext);
            }
            catch (Exception ex)
            {
                // Log Error
                return default(TResult);
            }
        }
    }
}
