using Asp.NetCoreProjectWebApp.Utility;

namespace Asp.NetCoreProjectWebApp.Models;

public class KitapRepository : Repository<Kitap>,IKitapRepository
{
    private UygulamaDbContext _uygulamaDbContext;
    public KitapRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
    {
        _uygulamaDbContext = uygulamaDbContext;
    }

    public void Update(Kitap kitap)
    {
        _uygulamaDbContext.Update(kitap);
    }

    public void Save()
    {
        _uygulamaDbContext.SaveChanges();
    }
}