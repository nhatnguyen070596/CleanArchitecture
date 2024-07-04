
using System;
using Member.Application_.Reponsitories.Interface;
using Member.Application_.Services.Interface;
using Member.Domain.DTOs;

namespace Member.Application_.Services
{
	public class UserServices : IUserServices
	{
        //Implement Bussiness Rule / USE CASES
        private readonly IUserRepository userRepository;
        public UserServices(IUserRepository userRepository)
		{
            this.userRepository = userRepository;

        }

        public User.UserResponse GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        User.UserResponse IUserServices.CreateUser(User.CreateUserRequest request)
        {
            throw new NotImplementedException();
        }

        void IUserServices.DeleteUserById(int userId)
        {
            throw new NotImplementedException();
        }

        List<User.UserResponse> IUserServices.GetUsers()
        {
            throw new NotImplementedException();
        }

        User.UserResponse IUserServices.UpdateUser(int userId, User.UpdateUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

