namespace EmployeeAPI.Model
{
    public class JobModel
    {
        public int id { get; set; }
        public string job_title { get; set; } = string.Empty;
        public int min_salary { get; set; } = 0;
        public int max_salary { get; set; } = 0;
    }
}
