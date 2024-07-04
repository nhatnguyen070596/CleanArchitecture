using System;
using System.ComponentModel.DataAnnotations;

namespace Member.Domain.DTOs
{
    public class CreateUserRequest
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Fullname { get; set; }

        [Required]
        public bool IsActive { get; set; } = false;

        [Required]
        [Range(0, 100)]
        public string Description { get; set; }

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
        public bool IsActive { get; set; }
        public string Description { get; set; }
    }
}

