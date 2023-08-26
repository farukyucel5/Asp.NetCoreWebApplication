using Microsoft.EntityFrameworkCore;

namespace Asp.NetCoreProjectWebApp.Utility;

public class UygulamaDbContext:DbContext
{
    public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options){}
    

}