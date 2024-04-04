using System.ComponentModel.DataAnnotations;

namespace SMSApi.Core.Dto.StudentDto
{
    public class StudentUpdateDto
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
