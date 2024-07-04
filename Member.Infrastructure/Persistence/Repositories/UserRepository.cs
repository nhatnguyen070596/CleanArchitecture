using System;
using AutoMapper;
using Member.Domain.DTOs;
using Member.Domain.Entities;
using Member.Domain.Exceptions;
using Member.Domain.Utils;
using Member.Application_.Reponsitories.Interface;
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

        public UserResponse CreateUser(CreateUserRequest request)
        {
            var user = this.mapper.Map<User>(request);
            user.CreatedAt = user.UpdatedAt = DateUtil.GetCurrentDate();

            this.storeContext.Users.Add(user);
            this.storeContext.SaveChanges();

            return this.mapper.Map<UserResponse>(user);
        }

        public void DeleteUserById(int userId)
        {
            var user = this.storeContext.Users.Find(userId);
            if (user != null)
            {
                this.storeContext.Users.Remove(user);
                this.storeContext.SaveChanges();
            }
            else
            {
                throw new NotFoundException();
            }
        }

        public UserResponse GetUserById(int userId)
        {
            var user = this.storeContext.Users.Find(userId);
            if (user != null)
            {
                return this.mapper.Map<UserResponse>(user);
            }

            throw new NotFoundException();
        }

        public List<UserResponse> GetUsers()
        {
            return this.storeContext.Users.Select(u => this.mapper.Map<UserResponse>(u)).ToList();
        }

        public UserResponse UpdateUser(int userId, UpdateUserRequest request)
        {
            var user = this.storeContext.Users.Find(userId);
            if (user != null)
            {
                user.FullName = request.Fullname;
                user.Description = request.Description;
                user.IsActive = request.IsActive;
                user.UpdatedAt = DateUtil.GetCurrentDate();

                this.storeContext.Users.Update(user);
                this.storeContext.SaveChanges();

                return this.mapper.Map<UserResponse>(user);
            }

            throw new NotFoundException();
        }
    }
}

