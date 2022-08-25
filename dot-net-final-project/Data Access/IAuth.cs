using Data_Access.Models;
namespace Data_Access
{
    public interface IAuth
    {
        Token Authenticate(User user);
        bool IsAuthenticated(string token);
        bool Logout(string token);
        int GetUserType(string token);
        bool IsActive(string token);

    }
}
