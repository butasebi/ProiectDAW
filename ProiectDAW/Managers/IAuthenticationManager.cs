using ProiectDAW.Models;
using System.Threading.Tasks;

namespace ProiectDAW.Managers
{
    public interface IAuthenticationManager
    {
        Task Signup(RegisterModel registerModel);

        Task<TokensModel> Login(LoginModel loginModel);
    }
}
