using SpotiWiFi.STS.Model;

namespace SpotiWiFi.STS.Data
{
    public interface IIdentityRepository
    {
        Task<Usuario> FindByEmailAndPasswordAsync(string email, string password);
        Task<Usuario> FindByIdAsync(Guid id);
    }
}