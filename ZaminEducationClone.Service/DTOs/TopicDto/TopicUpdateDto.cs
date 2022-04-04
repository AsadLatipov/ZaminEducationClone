using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaminEducationClone.Service.DTOs.TopicDto
{
    public class TopicUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CourseId { get; set; }
    }
}
