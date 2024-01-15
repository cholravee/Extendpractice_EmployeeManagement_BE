using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAPI.EFCore
{

    [Table("employee")]
    public class Employee
    {
        [Key, Required]
        public int id { get; set; }
        public string first_name { get; set; } = string.Empty;  
        public string last_name { get; set;} = string.Empty;
        public string email { get; set; } = string.Empty;
        public string phone_num { get; set; } = string.Empty;
        public DateTime hire_date { get; set; } 
        public virtual Job Job_id{ get; set; }
        
    }
}
