using Asp.NetCoreProjectWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetCoreProjectWebApp.Utility;

public class UygulamaDbContext:IdentityDbContext
{
    public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options){}
    public DbSet<KitapTuru> KitapTurleri { get; set; }
    public DbSet<Kitap> Kitaplar { get; set; }
    
    public DbSet<Kiralama> Kiralama { get; set;}

}