using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZaminEducationClone.Domain.Enums;

namespace ZaminEducationClone.Domain.Entities.Courses
{
    public class Section
    {
        [Key]
        public Guid Id { get; set; }

        [NotMapped]
        public string Name { get; set; }

        [JsonIgnore]
        public string NameUz { get; set; }
        
        [JsonIgnore]
        public string NameRu { get; set; }
     
        [JsonIgnore]
        public string NameEng { get; set; }

        public string Description { get; set; }
        public virtual ICollection<Course> Courses { get; set; }



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
