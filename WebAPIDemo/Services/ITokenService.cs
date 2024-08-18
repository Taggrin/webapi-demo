namespace WebAPIDemo.Services
{
    public interface ITokenService
    {
        string? GenerateToken(string username, string password, string scope);
    }
}
