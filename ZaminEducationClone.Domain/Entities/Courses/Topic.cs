using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaminEducationClone.Domain.Commons;
using ZaminEducationClone.Domain.Enums;

namespace ZaminEducationClone.Domain.Entities.Courses
{
    public class Topic :IAuditable
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public Guid CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }
        public List<Lesson> Lessons { get; set; }


        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public ItemState Status { get; set; }

        public void Create(string id = null)
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
