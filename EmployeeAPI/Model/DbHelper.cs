using EmployeeAPI.EFCore;
using EmployeeAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace EmployeeAPI.Model
{
    public class DbHelper
    {
        private EF_DataContext _context;
        public DbHelper(EF_DataContext context)
        {
            _context = context;
        }

        public List<JobModel> GetAllJob()
        {
            List<JobModel> response = new List<JobModel>();
            var datalist = _context.Job.ToList();
            datalist.ForEach(row => response.Add(new JobModel()
            {
                id = row.id,
                job_title = row.job_title,
                min_salary = row.min_salary,
                max_salary = row.max_salary
            }));
            return response;
        }


        public JobModel GetJobById(int id)
        {
            JobModel response = new JobModel();
            var row = _context.Job.Where(d => d.id.Equals(id)).FirstOrDefault();
            if (row != null)
            {
                return new JobModel()
                {
                    id = row.id,
                    job_title = row.job_title,
                    min_salary = row.min_salary,
                    max_salary = row.max_salary
                };
            }
            return null;
        }


        public List<EmployeeModel> GetAllEmployee() 
        {
            List<EmployeeModel> response = new List<EmployeeModel>();
            var datalist = _context.Employees.ToList();
            datalist.ForEach(row => response.Add(new EmployeeModel()
            {
                id = row.id,
                first_name = row.first_name,
                last_name = row.last_name,
                email = row.email,
                phone_num = row.phone_num,
                hire_date = row.hire_date
            }));
            return response;
        }

        public EmployeeModel GetEmployeeById(int id)
        {
            EmployeeModel response = new EmployeeModel();
            var row = _context.Employees.Where(d => d.id.Equals(id)).FirstOrDefault();
            if (row != null)
            {
                return new EmployeeModel()
                {
                    id = row.id,
                    first_name = row.first_name,
                    last_name = row.last_name,
                    email = row.email,
                    phone_num = row.phone_num,
                    hire_date = row.hire_date,
                };
            }
            return null;
        }

        public void AddEmployee(EmployeeModel employeeModel)
        {
            Employee dbTable = new Employee();

            int newId = _context.Employees.Any() ? _context.Employees.Max(e => e.id) + 1 : 1;     //=> handle the case when there are no elements in the sequence. One way to do this is by checking if there are any elements before calling Max. Here's an updated version of your code:

            dbTable = new Employee
              {
                 id = newId,
                 first_name = employeeModel.first_name,
                 last_name = employeeModel.last_name,
                 email = employeeModel.email,
                 phone_num = employeeModel.phone_num,
                 hire_date = DateTime.SpecifyKind(employeeModel.hire_date, DateTimeKind.Utc),
                 Job_id = _context.Job.FirstOrDefault(f => f.id.Equals(employeeModel.Job_idid))
              };

            _context.Employees.Add(dbTable);
            
            _context.SaveChanges();
        }


        public void UpdateEmployee(EmployeeModel employeeModel)
        {
            Employee dbTable = new Employee();
            dbTable = _context.Employees.Find(employeeModel.id);

            if (dbTable != null)
            {
                dbTable.first_name = employeeModel.first_name;
                dbTable.last_name = employeeModel.last_name;
                dbTable.email = employeeModel.email;
                dbTable.phone_num = employeeModel.phone_num;
                dbTable.hire_date = DateTime.SpecifyKind(employeeModel.hire_date, DateTimeKind.Utc);
                Job job = _context.Job.FirstOrDefault(j => j.id.Equals(employeeModel.Job_idid));
                if( job != null)
                {
                    dbTable.Job_id = job;
                }
            }
            _context.SaveChanges();
        }


        public void DeleteEmployee(int id)
        {
            var Employee_P = _context.Employees.Where(d => d.id == id).FirstOrDefault();
            if(Employee_P != null)
            {
                _context.Remove(Employee_P);
                _context.SaveChanges();
            }
        }






    }
}




