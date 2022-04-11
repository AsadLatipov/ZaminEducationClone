using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace ZaminEducationClone.Service.DTOs.SectionDto
{
    public class SectionUpdateDto
    {
        [Required]
        public Guid Id { get; set; }

        [JsonIgnore]
        public string NameUz { get; set; }

        [JsonIgnore]
        public string NameRu { get; set; }

        [JsonIgnore]
        public string NameEng { get; set; }
        public string Description { get; set; }
    }
}
