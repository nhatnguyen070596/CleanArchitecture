using System;
using System.ComponentModel.DataAnnotations;

namespace Member.Domain.DTOs
{
	public class User
	{
        public class CreateUserRequest
        {
            [Required]
            [StringLength(30, MinimumLength = 3)]
            public string Fullname { get; set; }

            [Required]
            public bool IsActive { get; set; } = false;

        }

        public class UpdateUserRequest : CreateUserRequest
        {
            [Required]
            [Range(0, 100)]
            public string Description { get; set; }
        }

        public class UserResponse
        {
            public int Id { get; set; }
            public string FullName { get; set; }
            public string IsActive { get; set; }
            public int Description { get; set; }
        }
    }
}

