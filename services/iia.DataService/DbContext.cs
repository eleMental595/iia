using iia.contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace iia.DataService
{
  public class ReportContext : DbContext
  {
    public DbSet<Categories> Categories { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseMySQL("Server=db5000177002.hosting-data.io;Port=3306;Database=dbs171813;User=dbu257471;Password=HAha1254@");
      base.OnConfiguring(optionsBuilder);
    }
  }
}