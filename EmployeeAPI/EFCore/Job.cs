using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAPI.EFCore
{
    [Table("job")]
    public class Job
    {
        [Key,Required]
        public int id { get; set; } 
        public string job_title { get; set; } = string.Empty;
        public int min_salary { get; set; } = 0;
        public int max_salary { get; set; } = 0;
    }
}
