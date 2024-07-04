using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Member.Domain.Entities;
using Member.Domain.DTOs;

namespace Member.Domain.Mappings
{
	public class UserProfile : Profile
    {
		public UserProfile()
		{
            CreateMap<User, UserResponse>();

            CreateMap<CreateUserRequest, User>()
                    .ForMember(dest =>
                        dest.Id,
                        opt => opt.Ignore()
                    )
                    .ForMember(dest =>
                        dest.CreatedAt,
                        opt => opt.Ignore()
                    )
                    .ForMember(dest =>
                        dest.UpdatedAt,
                        opt => opt.Ignore()
                    );
        }
	}
}

