using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAttendance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsAttendanceController : ControllerBase
    {
        // GET: api/<StudentsAttendanceController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Attendance API Working", "OK" };
        }

        // GET api/<StudentsAttendanceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentsAttendanceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentsAttendanceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentsAttendanceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
