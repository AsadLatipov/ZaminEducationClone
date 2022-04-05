using System;
using System.ComponentModel.DataAnnotations;

namespace ZaminEducationClone.Service.DTOs.SectionDto
{
    public class SectionUpdateDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
