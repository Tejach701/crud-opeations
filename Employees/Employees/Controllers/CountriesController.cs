using Employees.data;
using Employees.model.domain;
using Employees.model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly EmployeesContext dbcontext;

        public CountriesController(EmployeesContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var countries = dbcontext.countries.ToList();
            return Ok(countries);

        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var country = dbcontext.countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }
        [HttpPost]
        public IActionResult create([FromBody] countries countries)
        {
            dbcontext.countries.Add(countries);
            dbcontext.SaveChanges();

          
            return CreatedAtAction(nameof(GetById), new { id = countries.countryid }, countries);
        }
        [HttpPut]
        public IActionResult update([FromBody]countries countries)
        {
            dbcontext.countries.Update(countries);
            dbcontext.SaveChanges();
            return Ok(countries);

        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
             var country= dbcontext.countries.Find(id);
            dbcontext.countries.Remove(country);
            dbcontext.SaveChanges();
            return Ok();
        }


        

       
    }
}
