using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaminEducationClone.Domain.Commons;
using ZaminEducationClone.Domain.Enums;

namespace ZaminEducationClone.Domain.Entities.Users
{
    public class User : IAuditable
    {
        [Key]
        [Required]
        public Guid Id { get ; set ; }

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

        
        
        public DateTime CreatedDate { get ; set ; }
        public DateTime? ModifiedDate { get ; set ; }
        public string CreatedBy { get ; set ; }
        public string ModifiedBy { get ; set ; }
        public ItemState Status { get ; set ; }
        
        public void Create(string id=null)
        {
            CreatedDate = DateTime.Now;
            Status = ItemState.Created;
            CreatedBy = id;
        }
        public void Update(string id = null)
        {
            ModifiedDate = DateTime.Now;
            Status = ItemState.Updated;
            ModifiedBy = id;
        }
        public void Deleted(string id = null)
        {
            ModifiedDate = DateTime.Now;
            Status = ItemState.Deleted;
            ModifiedBy = id;
        }

    }
}

