using ProiectDAW.Entities;
using System.Threading.Tasks;

namespace ProiectDAW.Managers
{
    public interface ITokenManager
    {
        Task<string> Generate_Token(User user);
    }
}
