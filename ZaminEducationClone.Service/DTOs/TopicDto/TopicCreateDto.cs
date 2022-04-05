using System;
using System.ComponentModel.DataAnnotations;

namespace ZaminEducationClone.Service.DTOs.TopicDto
{
    public class TopicCreateDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public Guid CourseId { get; set; }


    }
}

