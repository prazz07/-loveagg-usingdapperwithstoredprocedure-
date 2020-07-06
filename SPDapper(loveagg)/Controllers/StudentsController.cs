using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SPDapper.IServices;
using SPDapper.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SPDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
      
        private IStudentService _oStudentService;
        // GET: api/Students
        public StudentsController(IStudentService ostudentService)
        {
            _oStudentService = ostudentService;
        }
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _oStudentService.Gets();
        }

        // GET api/Students>/5
        [HttpGet("{id}",Name ="Get")]
        public Student Get(int id)
        {
            return _oStudentService.Get(id);
        }

        // POST api/Students
        [HttpPost]
        public Student Post([FromBody] Student oStudent)
        {
           // if (ModelState.IsValid)
            return _oStudentService.Save(oStudent);
           // return null;

        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Students/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _oStudentService.Delete(id);
        }
    }
}
