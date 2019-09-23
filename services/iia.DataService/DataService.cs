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

        public List<T> GetTables<T>(ComponentType componentType)
        {
            var result = _dataContext.GetType().GetProperty(componentType.ToString()).GetValue(_dataContext);
            return (List<T>)result;
            //var result = _dataContext.Categories.ToList();
            //return result.Cast<T>().ToList();
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
