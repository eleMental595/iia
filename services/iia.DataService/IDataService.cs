using iia.contracts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace iia.DataService
{
    public interface IDataService
    {
        Task<TResult> GetResults<TResult>(Func<DataContext, Task<TResult>> func);
    }
}
