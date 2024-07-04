using System;
using System.ComponentModel.DataAnnotations;

namespace Member.Domain.Identity
{
    public class AppUser
    {

        [MaxLength(100)]
        public string FullName { set; get; }

        [MaxLength(255)]
        public string Address { set; get; }

        [DataType(DataType.Date)]
        public DateTime? Birthday { set; get; }

    }
}

