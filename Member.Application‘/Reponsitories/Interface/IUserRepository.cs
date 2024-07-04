using System;
using Member.Domain.DTOs;
using static Member.Domain.DTOs.User;

namespace Member.Application_.Reponsitories.Interface
{
	public interface IUserRepository
	{
        List<UserResponse> GetUsers();

        UserResponse GetUserById(int userId);

        void DeleteUserById(int userId);

        UserResponse CreateUser(CreateUserRequest request);

        UserResponse UpdateUser(int userId, UpdateUserRequest request);
    }
}

