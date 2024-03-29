using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSApi.Core.Models
{
    public class Fee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeeId { get; set; }
        public string Amount { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
