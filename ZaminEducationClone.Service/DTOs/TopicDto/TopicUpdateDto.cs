using System;
using System.ComponentModel.DataAnnotations;

namespace ZaminEducationClone.Service.DTOs.TopicDto
{
    public class TopicUpdateDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public Guid CourseId { get; set; }
    }
}
