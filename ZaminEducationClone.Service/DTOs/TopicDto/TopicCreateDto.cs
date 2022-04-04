using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaminEducationClone.Domain.Entities.Courses;

namespace ZaminEducationClone.Service.DTOs.TopicDto
{
    public class TopicCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CourseId { get; set; }
        
        
    }
}

