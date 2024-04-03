using System.ComponentModel.DataAnnotations;

namespace SMSApi.Core.Dto.FeeDto
{
    public class FeeCreateDto
    {
        [Required]
        public string Amount { get; set; }
    }
}
