using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SMSApi.Core.Models
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubId { get; set; }
        public string Name { get; set; }

        public IList<StudentResult> StudentResults { get; set; }

        public Teacher Teacher { get; set; }
    }
}
