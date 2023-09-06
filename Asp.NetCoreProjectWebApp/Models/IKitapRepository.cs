namespace Asp.NetCoreProjectWebApp.Models;

public interface IKitapRepository : IRepository<Kitap>
{
    void Update(Kitap kitapTuru);
    void Save();
}