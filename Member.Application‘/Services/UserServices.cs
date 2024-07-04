
using System;
using Member.Application_.Reponsitories.Interface;
using Member.Application_.Services.Interface;
using Member.Domain.DTOs;
using Member.Domain.Entities;

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

        public UserResponse CreateUser(CreateUserRequest request)
        {
            return this.userRepository.CreateUser(request);
        }

        public void DeleteUserById(int userId)
        {
            this.userRepository.DeleteUserById(userId);
        }

        public UserResponse GetUserById(int userId)
        {
            return this.userRepository.GetUserById(userId);
        }

        public List<UserResponse> GetUsers()
        {
            return this.userRepository.GetUsers();
        }

        public UserResponse UpdateUser(int userId, UpdateUserRequest request)
        {
            return this.userRepository.UpdateUser(userId, request);
        }
    }
}

