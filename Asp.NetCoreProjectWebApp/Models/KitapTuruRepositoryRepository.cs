using Asp.NetCoreProjectWebApp.Utility;

namespace Asp.NetCoreProjectWebApp.Models;

public class KitapTuruRepositoryRepository : Repository<KitapTuru>,IKitapTuruRepository
{
    private UygulamaDbContext _uygulamaDbContext;
    public KitapTuruRepositoryRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
    {
        _uygulamaDbContext = uygulamaDbContext;
    }

    public void Update(KitapTuru kitapTuru)
    {
        _uygulamaDbContext.Update(kitapTuru);
    }

    public void Save()
    {
        _uygulamaDbContext.SaveChanges();
    }
}