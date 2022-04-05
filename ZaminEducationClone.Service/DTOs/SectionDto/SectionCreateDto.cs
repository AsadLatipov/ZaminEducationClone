using System.ComponentModel.DataAnnotations;

namespace ZaminEducationClone.Service.DTOs.SectionDto
{
    public class SectionCreateDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
