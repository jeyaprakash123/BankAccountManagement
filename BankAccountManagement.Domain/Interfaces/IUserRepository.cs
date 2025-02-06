using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagement.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<User> CreateUser(User user);
    }
}
