using System;
using AutoMapper;
using Member.Application_.Reponsitories.Interface;
using Member.Domain.DTOs;
using Member.Infrastructure.Persistence.Contexts;

namespace Member.Infrastructure.Persistence.Repositories
{
	public class UserRepository : IUserRepository
	{
        private readonly StoreContext storeContext;
        private readonly IMapper mapper;
        public UserRepository(StoreContext context, IMapper mapper)
		{
            storeContext = context;
            this.mapper = mapper;
        }

        public User.UserResponse CreateUser(User.CreateUserRequest request)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public User.UserResponse GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public List<User.UserResponse> GetUsers()
        {
            throw new NotImplementedException();
        }

        public User.UserResponse UpdateUser(int userId, User.UpdateUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

