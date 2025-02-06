using BankAccountManagement.Application.DTO;
using BankAccountManagement.Domain;

namespace BankAccountManagement.Application.Interface
{
    public interface IUserService
    {
        Task<UserDTO> GetById(int id);
        Task<UserDTO> CreateUser(User user);
    }
}
