using Employees.data;
using Employees.model.domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class departmentController : ControllerBase
    {
        private readonly EmployeesContext context;

        public departmentController(EmployeesContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var department= context.Departments.ToList();
             return Ok(department);



        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var Department = context.Departments.Find(id);
                if (Department == null)
                {
                return NotFound();
                }
            return Ok(Department);
        }
        [HttpPost]
        public IActionResult create([FromBody] Departments departments)
        {
            context.Departments.Add(departments);
            context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = departments.departmentid }, departments);
        }
        [HttpPut]
        public IActionResult update([FromBody] Departments departments)
        {
            context.Departments.Update(departments);
            context.SaveChanges();
            return Ok(departments);
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            var department = context.Departments.Find(id);
            context.Departments.Remove(department);
            context.SaveChanges();
            return Ok(department);
        }

    }
}
