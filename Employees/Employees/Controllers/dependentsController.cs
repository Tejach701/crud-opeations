using Employees.data;
using Employees.model.domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class dependentsController : ControllerBase
    {
        private readonly EmployeesContext context;

        public dependentsController(EmployeesContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dependent= context.dependents.ToList();
            return Ok(dependent);
            
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var Dependent = context.dependents.Find(id);
            if (Dependent == null)
            {
                return NotFound();

            }
            return Ok(Dependent);
        }
        [HttpPost]
        public IActionResult create([FromBody ] dependents dependent)
        {
            context.dependents.Add(dependent);
            context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = dependent.dependentid }, dependent);
        }
        [HttpPut]
        public IActionResult update([FromBody] dependents dependents)
        {
            context.dependents.Update(dependents);
            context.SaveChanges();
            return Ok(dependents);
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            var dependent = context.dependents.Find(id);
            context.dependents.Remove(dependent);
            context.SaveChanges();
            return Ok(dependent);  
        }


    }
}
