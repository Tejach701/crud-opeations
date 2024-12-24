using Employees.data;
using Employees.model.domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class locationController : ControllerBase
    {
        private readonly EmployeesContext context;

        public locationController( EmployeesContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var locations = context.locations.ToList();
            return Ok(locations);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var location = context.locations.Find(id);
            if (location == null)
            {
                return NotFound();

            }
            return Ok(location);
        }
        [HttpPost]
        public IActionResult create([FromBody] location location)
        {
            context.locations.Add(location);
            context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id=location.locationid }, location);
        }
        [HttpPut]
        public IActionResult update([FromBody] location location)
        {
            context.locations.Update(location);
            context.SaveChanges();
            return Ok(location);
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            var location = context.locations.Find();
            context.locations.Remove(location);
            context.SaveChanges();
            return Ok(location);
        }
    }
}
