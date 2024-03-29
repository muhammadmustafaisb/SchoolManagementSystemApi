using System.ComponentModel.DataAnnotations;

namespace SMSApi.Core.Repositories.Dto.StudentDto
{
    public class StudentCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public string Number { get; set; }
    }
}
