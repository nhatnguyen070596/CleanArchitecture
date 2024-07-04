using System;
using Member.Domain.DTOs;
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

