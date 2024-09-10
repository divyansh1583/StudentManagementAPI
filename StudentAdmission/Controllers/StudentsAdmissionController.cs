using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAdmission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsAdmissionController : ControllerBase
    {
        // GET: api/<StudentsAdmissionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "StudentsAdmissionController get Api Working", "OK" };
        }

        // GET api/<StudentsAdmissionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentsAdmissionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentsAdmissionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentsAdmissionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
