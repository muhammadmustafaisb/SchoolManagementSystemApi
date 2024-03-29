using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SMSApi.Core.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeachId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
