using System.ComponentModel.DataAnnotations;

namespace SMSApi.Core.Dto.StudentClassDto
{
    public class StudentClassCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
