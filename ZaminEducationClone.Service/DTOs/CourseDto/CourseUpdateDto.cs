using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace ZaminEducationClone.Service.DTOs.CourseDto
{
    public class CourseUpdateDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        [Required]
        public Guid SectionId { get; set; }
    }
}
