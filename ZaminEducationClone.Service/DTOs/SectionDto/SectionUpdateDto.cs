using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
