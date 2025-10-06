using AutoMapper;
using BankAccountManagement.Application.DTO;
using BankAccountManagement.Application.Interface;
using BankAccountManagement.Domain;
using BankAccountManagement.Domain.Interfaces;

namespace BankAccountManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetById(int id)
        {
            var res = await _unitOfWork.UserRepository.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(res) ;
        }
        public async Task<UserDTO> CreateUser(User user)
        {
            var res = await _unitOfWork.UserRepository.CreateUser(user);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<UserDTO>(res);
        }
    }
}
