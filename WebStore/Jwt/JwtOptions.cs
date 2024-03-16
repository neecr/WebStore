namespace WebStore;

public class JwtOptions
{
    public string SecretKey { get; set; }
    public int ExpiresInHours { get; set; }
}