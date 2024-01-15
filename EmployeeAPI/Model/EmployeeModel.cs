using EmployeeAPI.EFCore;

namespace EmployeeAPI.Model
{
    public class EmployeeModel
    {
        public int id { get; set; }
        public string first_name { get; set; } = string.Empty;
        public string last_name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string phone_num { get; set; } = string.Empty;
        public DateTime hire_date { get; set; }
        public int Job_idid{ get; set; }
    }
}
