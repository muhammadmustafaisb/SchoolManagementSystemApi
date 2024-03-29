using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SMSApi.Core.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StdId { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Number { get; set; }


        public Fee Fee { get; set; }
        public IList<StudentResult> StudentResults { get; set; }

        public int CurrentClassId { get; set; }
        public StudentClass StdClass { get; set; }
    }
}
