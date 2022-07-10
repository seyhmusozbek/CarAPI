using Car.Core.Models;
using System.Threading.Tasks;

namespace Car.Core.Contracts
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginDTO loginDTO);
        Task<string> CreateToken();

    }
}
