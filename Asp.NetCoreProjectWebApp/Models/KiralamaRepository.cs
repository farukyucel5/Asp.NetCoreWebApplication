using Asp.NetCoreProjectWebApp.Utility;

namespace Asp.NetCoreProjectWebApp.Models;

public class KiralamaRepository : Repository<Kiralama>,IKiralamaRepository
{
    private UygulamaDbContext _uygulamaDbContext;
    public KiralamaRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
    {
        _uygulamaDbContext = uygulamaDbContext;
    }

    public void Update(Kiralama kiralama)
    {
        _uygulamaDbContext.Update(kiralama);
    }

    public void Save()
    {
        _uygulamaDbContext.SaveChanges();
    }
}