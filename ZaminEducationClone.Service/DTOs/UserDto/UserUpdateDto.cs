using System;
using System.ComponentModel.DataAnnotations;

namespace ZaminEducationClone.Service.DTOs
{
    public class UserUpdateDto
    {
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Login { get; set; }
    }
}
