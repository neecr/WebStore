using WebStore.Models;

namespace WebStore;

public interface IJwtProvider
{
    public string GenerateToken();
}