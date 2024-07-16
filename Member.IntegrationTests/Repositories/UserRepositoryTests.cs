using System;
using AutoMapper;
using Member.Domain.Mappings;
using Microsoft.Extensions.Configuration;
using Member.Infrastructure.Persistence.Repositories;
using Member.Domain.Exceptions;
using Member.Domain.Entities;
using Member.Domain.DTOs;

namespace Member.IntegrationTests.Repositories
{
	public class UserRepositoryTests : IClassFixture<SharedDatabaseFixture>
    {
        private readonly IMapper _mapper;
        private SharedDatabaseFixture Fixture { get; }

        public UserRepositoryTests(SharedDatabaseFixture fixture)
        {
			Fixture = fixture;
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
            });
            _mapper = configuration.CreateMapper();

        }

        [Fact]
        public void getUsers_ReturnAllUsers()
        {
            using(var context = Fixture.CreateContext())
            {
                var repository = new UserRepository(context, _mapper);
                var user = repository.GetUsers();

                Assert.Equal(10, user.Count);
            }
        }
        [Fact]
        public void getUserById_ReturnOneUserById()
        {
            using(var context = Fixture.CreateContext())
            {
                var userRepo = new UserRepository(context, _mapper);
                var userId = 20;

                Assert.Throws<NotFoundException>(() => userRepo.GetUserById(userId));
            }
        }


        [Fact]
        public void CreateUser_SaveCorrectData()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                var request = new CreateUserRequest();
                request.Fullname = "Nguyen Minh Nhat";
                request.Description = "Description";
                request.IsActive = true;

                int userId = 0;

                using (var context = Fixture.CreateContext(transaction))
                {
                    var repository = new UserRepository(context, _mapper);
                    var user = repository.CreateUser(request);
                    userId = user.Id;
                }

                using (var context = Fixture.CreateContext())
                {
                    var repository = new UserRepository(context, _mapper);
                    var user = repository.GetUserById(userId);

                    Assert.NotNull(user);
                    Assert.Equal(user.Id, userId);
                    Assert.Equal(user.Description, request.Description);
                    Assert.Equal(user.FullName, request.Fullname);
                    Assert.Equal(user.IsActive, request.IsActive);
                }
            }
         
        }


        [Fact]
        public void DeleteUser_UserDoesNotExist()
        {
            using(var transation = Fixture.Connection.BeginTransaction())
            {
                var userId = 31;

                using(var context = Fixture.CreateContext())
                {
                    var UserRepo = new UserRepository(context, _mapper);

                    Assert.Throws<NotFoundException>(() => UserRepo.DeleteUserById(userId));
                }
            }
        }

        [Fact]
        public void DeleteUser_EnsureTheUserIsDeleted()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                var userId = 1;
                using(var context = Fixture.CreateContext())
                {
                    var repoUser = new UserRepository(context, _mapper);

                    repoUser.DeleteUserById(userId);
                }
                using (var context = Fixture.CreateContext())
                {
                    var repoUser = new UserRepository(context, _mapper);
                    Assert.Throws<NotFoundException>(() => repoUser.GetUserById(userId));
                }

            }
        }

        [Fact]
        public void UpdateUser_UserDoesNotExit()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                var userId = 21;
                var request = new UpdateUserRequest();
                request.Fullname = "Nguyen Minh Nhat 11";
                request.Description = "Description";
                request.IsActive = true;

                using (var context = Fixture.CreateContext())
                {
                    var repoUser = new UserRepository(context, _mapper);

                    var action = () => repoUser.UpdateUser(userId,request);

                    Assert.Throws<NotFoundException>( action);
                }
            }
        }

        [Fact]
        public void UpdateUser_EnsureUserIsUpdated()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                var userId = 1;
                var request = new UpdateUserRequest();
                request.Fullname = "Nguyen Minh Nhat 11";
                request.Description = "Description";
                request.IsActive = true;

                using (var context = Fixture.CreateContext())
                {
                    var repoUser = new UserRepository(context, _mapper);

                    repoUser.UpdateUser(userId, request);

                }
                using (var context = Fixture.CreateContext())
                {
                    var repoUser = new UserRepository(context, _mapper);
                    var user = repoUser.GetUserById(userId);

                    Assert.NotNull(user);
                    Assert.Equal(user.Id, userId);
                    Assert.Equal(user.FullName, request.Fullname);
                    Assert.Equal(user.Description, request.Description);
                    Assert.Equal(user.IsActive, request.IsActive);
                }
            }
        }
    }
}

