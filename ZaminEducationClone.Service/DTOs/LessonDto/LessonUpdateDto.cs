using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace ZaminEducationClone.Service.DTOs.LessonDto
{
    public class LessonUpdateDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        public IFormFile Video { get; set; }
        public string VideoDuration { get; set; }

        [Required]
        public Guid TopicId { get; set; }
    }
}
