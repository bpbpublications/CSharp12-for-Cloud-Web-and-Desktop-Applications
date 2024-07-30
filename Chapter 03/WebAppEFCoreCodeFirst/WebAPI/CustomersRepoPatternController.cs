using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppEFCoreCodeFirst.Database;

namespace WebAppEFCoreCodeFirst.WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersRepoPatternController : ControllerBase
    {
        private readonly GenericRepository<Customer> customerRepository;
        private readonly GenericRepository<Product> productRepository;
        public CustomersRepoPatternController(GenericRepository<Customer> customerRepository, GenericRepository<Product> productRepository)
        {
            this.customerRepository = customerRepository;
            this.productRepository = productRepository;
        }

        [HttpGet("Customers/{id}")]
        public IActionResult GetById(int id)
        {
            return new OkObjectResult(customerRepository.GetByID(id));
        }
        [HttpGet("Customers")]
        public IActionResult GetAll()
        {
            return Ok(customerRepository.Get());
        }
        [HttpPost("Customer")]
        public IActionResult PostSingle([FromBody] Customer customer)
        {
            customerRepository.Insert(customer);
            customerRepository.context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }
        [HttpPut("Customer")]
        public IActionResult PutSingle([FromBody] Customer customer)
        {
            customerRepository.Update(customer);
            customerRepository.context.SaveChanges();

            return NoContent();
        }
        [HttpDelete("Customers/{id}")]
        public IActionResult Delete(int id)
        {
            var customer = customerRepository.Get(x=> x.Id.Equals( id), includeProperties: "Products").FirstOrDefault();
            foreach (var item in customer.Products)
                productRepository.Delete(item.Id);

            customerRepository.Delete(id);
            customerRepository.context.SaveChanges();

            return NoContent();
        }
    }
}
