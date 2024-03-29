using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SMSApi.Core.Models
{
    public class Result
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResId { get; set; }
        public string Name { get; set; }


        public IList<StudentResult> StudentResults { get; set; }
    }
}
