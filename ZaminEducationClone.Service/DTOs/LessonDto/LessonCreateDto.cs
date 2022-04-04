using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaminEducationClone.Service.DTOs.LessonDto
{
    public class LessonCreateDto
    {
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
