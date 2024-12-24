using Employees.data;
using Employees.model.domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class jobsController : ControllerBase
    {
        private readonly EmployeesContext context;

        public jobsController( EmployeesContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var jobs = context.jobs.ToList();
            var totaljobs = jobs.Count;
            var maxsalary = jobs.Max(x => x.maxsalary);
            var minsalary = jobs.Min(x => x.minsalary);
            

            return Ok(new
            {
                totaljobs,
                maxsalary,
                minsalary,
                Jobs=jobs
            });
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById([FromBody] int id )
        {
            var job = context.jobs.Find(id);
            if (job == null)
            {
                return NotFound();

            }
            return Ok(job);
        }
        [HttpPost]
        public ActionResult create([FromBody] jobs jobs)
        {
            context.jobs.Add(jobs);
            context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id= jobs.jobid }, jobs);


        }
        [HttpPut]
        public  ActionResult update([FromBody] jobs jobs)
        {
            context.jobs.Update(jobs);
             context.SaveChanges();
            return Ok(jobs);

        }
        [HttpDelete]
        public ActionResult deletebyid(int id)
        {
            var job = context.jobs.Find(id);
            context.jobs.Remove(job);
            context.SaveChanges();
            return Ok(job);
        }
    }
}
