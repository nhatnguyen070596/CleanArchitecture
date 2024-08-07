﻿using System;
using Member.Domain.DTOs;

namespace Member.Application_.Services.Interface
{
	public interface IUserServices
	{
        List<UserResponse> GetUsers();

        UserResponse GetUserById(int userId);

        void DeleteUserById(int userId);

        UserResponse CreateUser(CreateUserRequest request);

        UserResponse UpdateUser(int userId, UpdateUserRequest request);
    }
}

