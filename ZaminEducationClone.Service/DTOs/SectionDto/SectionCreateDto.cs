using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ZaminEducationClone.Service.DTOs.SectionDto
{
    public class SectionCreateDto
    {
        public string NameUz { get; set; }

        public string NameRu { get; set; }

        public string NameEng { get; set; }
        public string Description { get; set; }
    }
}
