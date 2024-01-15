using EmployeeAPI.EFCore;
using EmployeeAPI.Model;
using Microsoft.AspNetCore.Mvc;
using ShoppingWebApi.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeManageAPIController : ControllerBase
    {

        private readonly DbHelper _db; 
        public EmployeeManageAPIController(EF_DataContext eF_DataContext)
        {
            _db = new DbHelper(eF_DataContext);
        }
        
        // GET: api/<EmployeeManageAPIController>
        [HttpGet]
        [Route("GetJobList")]
        public IActionResult GetAllJob()
        {
           ResponseType type = ResponseType.Success;
           try
            {
                IEnumerable<JobModel> data = _db.GetAllJob();

                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET api/<EmployeeManageAPIController>/5
        [HttpGet]
        [Route("GetJobByID/{id}")]
        public IActionResult GetJobByID(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                JobModel data = _db.GetJobById(id);
                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch(Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }


        // GET: api/<EmployeeManageAPIController>
        [HttpGet]
        [Route("GetAllEmployee")]
        public IActionResult GetAllEmployee()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<EmployeeModel> data = _db.GetAllEmployee();

                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }


        [HttpGet]
        [Route("GetEmployeeByID/{id}")]
        public IActionResult GetEmployeeByID(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                EmployeeModel data = _db.GetEmployeeById(id);
                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }


        // POST api/<EmployeeManageAPIController>
        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult Post([FromBody] EmployeeModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.AddEmployee(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<EmployeeManageAPIController>/5
        [HttpPut]
        [Route("UpdateEmployee")]
        public IActionResult Put([FromBody] EmployeeModel model)
        {
            try
            { 
                ResponseType type = ResponseType.Success;
                _db.UpdateEmployee(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch(Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<EmployeeManageAPIController>/5
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteEmployee(id);
                return Ok(ResponseHandler.GetAppResponse(type,"Delete Successful"));
            }
            catch(Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
