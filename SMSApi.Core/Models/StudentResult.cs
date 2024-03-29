using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSApi.Core.Models
{
    public class StudentResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResId { get; set; }
        public Result Result { get; set; }

        public int StdId { get; set; }
        public Student Student { get; set; }

        public int SubjectID { get; set; }
        public Subject Subject { get; set; }
    }
}
