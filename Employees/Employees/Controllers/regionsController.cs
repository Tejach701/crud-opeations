using Employees.data;
using Employees.model.domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class regionsController : ControllerBase
    {
        private readonly EmployeesContext context;

        public regionsController( EmployeesContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var region= context.regions.ToList();
            return Ok(region);

            
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetByid(int id)
        {
            var Region = context.regions.Find(id);
            if (Region == null)
            {
                return NotFound();

            }
            return Ok(Region);

        }
        [HttpPost]
        public IActionResult create([FromBody] regions regions )
        {
            context.regions.Add(regions);
            context.SaveChanges();
            return CreatedAtAction(nameof(GetByid), new { id = regions.regionid }, regions);
        } 
        
        [HttpPut]
        public IActionResult update ([FromBody] regions regions)
        {
            context.regions.Update(regions);
            context.SaveChanges();
            return Ok(regions);
        }
        [HttpDelete]
        public IActionResult deletebyID(int id)
        {
            var region = context.regions.Find(id);
            context.regions.Remove(region);
            context.SaveChanges();
            return Ok(region);
        }
        

    }
}
