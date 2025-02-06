using BankAccountManagement.Domain;
using BankAccountManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankAccountManagement.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BankDbContext _dbContext;
        public UserRepository(BankDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x=>x.UserId == id);
        }

        public async Task<User> CreateUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            return user;
        }

    }
}
