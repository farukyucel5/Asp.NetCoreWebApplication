using Asp.NetCoreProjectWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetCoreProjectWebApp.Utility;

public class UygulamaDbContext:DbContext
{
    public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options){}
    public DbSet<KitapTuru> KitapTurleri { get; set; }
    public DbSet<Kitap> Kitaplar { get; set; }
    

}