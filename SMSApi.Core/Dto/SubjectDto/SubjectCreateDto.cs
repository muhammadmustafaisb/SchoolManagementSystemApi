using System.ComponentModel.DataAnnotations;

namespace SMSApi.Core.Dto.SubjectDto
{
    public class SubjectCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
