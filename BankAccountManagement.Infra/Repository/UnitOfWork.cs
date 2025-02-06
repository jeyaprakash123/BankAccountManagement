using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountManagement.Domain.Interfaces;
using BankAccountManagement.Infrastructure.Repository;

namespace BankAccountManagement.Infrastructure.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly BankDbContext _bankDbContext;

        public UnitOfWork(BankDbContext bankDbContext,IUserRepository userRepository)
        {
            _bankDbContext = bankDbContext;
            UserRepository=userRepository;
        }

        public IUserRepository UserRepository { get; }

        public void Dispose()
        {
            _bankDbContext.Dispose();
        }

        public async Task<int> CompleteAsync()
        {
            return await _bankDbContext.SaveChangesAsync();
        }

    }
}
