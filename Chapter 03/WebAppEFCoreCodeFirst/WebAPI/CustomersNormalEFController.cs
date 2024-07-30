using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppEFCoreCodeFirst.Database;
using WebAppEFCoreCodeFirst.Pages;

namespace WebAppEFCoreCodeFirst.WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersNormalEFController : ControllerBase
    {
        private readonly SampleDbContext sampleDbContext;
        public CustomersNormalEFController(SampleDbContext dbContext)
        {
            sampleDbContext = dbContext;
        }

        [HttpGet("Customers/{id}")]
        public IActionResult GetById( int id)
        {
            return new OkObjectResult(sampleDbContext.Customers.FirstOrDefault(x => x.Id == id));
        }
        [HttpGet("Customers")]
        public IActionResult GetAll()
        {
            return Ok(sampleDbContext.Customers.ToList());
        }
        [HttpPost("Customer")]
        public IActionResult PostSingle([FromBody] Customer customer)
        {
            sampleDbContext.Customers.Add(customer);
            sampleDbContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }
        [HttpPut("Customer")]
        public IActionResult PutSingle([FromBody] Customer customer)
        {
            if (!sampleDbContext.Customers.Any(x => x.Id == customer.Id))
                return NotFound();


            sampleDbContext.Customers.Update(customer);
            sampleDbContext.SaveChanges();

            return NoContent();
        }
        [HttpDelete("Customers/{id}")]
        public IActionResult Delete(int id)
        {
            var obj = sampleDbContext.Customers.Include(x=>x.Products).FirstOrDefault(x => x.Id == id);
            if (obj ==null)
                return NotFound();

            sampleDbContext.Products.RemoveRange(obj.Products);
            sampleDbContext.Customers.Remove(obj);
            sampleDbContext.SaveChanges();

            return NoContent();
        }
    }
}
