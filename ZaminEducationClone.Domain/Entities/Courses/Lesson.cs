using System;
using System.ComponentModel.DataAnnotations.Schema;
using ZaminEducationClone.Domain.Commons;
using ZaminEducationClone.Domain.Enums;

namespace ZaminEducationClone.Domain.Entities.Courses
{
    public class Lesson : IAuditable
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public string VideoDuration { get; set; }
        public Guid TopicId { get; set; }
        
        [ForeignKey(nameof(TopicId))]
        public Topic Topic { get; set; }



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
        public void Update(string id=null)
        {
            ModifiedDate = DateTime.Now;
            Status = ItemState.Updated;
            ModifiedBy = id;
        }
        public void Deleted(string id=null)
        {
            ModifiedDate = DateTime.Now;
            Status = ItemState.Deleted;
            ModifiedBy = id;
        }
    }
}