using Employees.data;
using Employees.model.domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeesContext context;

        public EmployeesController(EmployeesContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var employee= context.employees.OrderBy(emp=>emp.firstname).ToList();
            return Ok(employee);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = context.employees.Find(id);
            return Ok(employee);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromBody] employees employees)
        {
            var existingemp= context.employees.Update(employees);
            if (existingemp == null)
            {
                return NotFound();

            }
            context.SaveChanges();
            return Ok(existingemp);

        }
        [HttpPost]
        public IActionResult create([FromBody] employees employees)
        {
            context.employees.Add(employees);
            context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = employees.empid }, employees);

        }
       
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            var employee = context.employees.Find(id);
            context.employees.Remove(employee);
            context.SaveChanges();
            return Ok(employee);
        }
       
    }
}
