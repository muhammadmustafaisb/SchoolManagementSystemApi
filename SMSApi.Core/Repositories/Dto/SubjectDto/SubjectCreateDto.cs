using System.ComponentModel.DataAnnotations;

namespace SMSApi.Core.Repositories.Dto.SubjectDto
{
    public class SubjectCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
