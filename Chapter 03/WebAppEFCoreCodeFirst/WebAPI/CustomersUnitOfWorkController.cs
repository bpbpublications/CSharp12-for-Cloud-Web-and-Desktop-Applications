using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppEFCoreCodeFirst.Database;

namespace WebAppEFCoreCodeFirst.WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersUnitOfWorkController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;
        public CustomersUnitOfWorkController(SampleDbContext dbContext)
        {
            unitOfWork = new UnitOfWork(dbContext);
        }
        [HttpGet("Customers/{id}")]
        public IActionResult GetById(int id)
        {
            return new OkObjectResult(unitOfWork.CustomerRepository.GetByID(id));
        }
        [HttpGet("Customers")]
        public IActionResult GetAll()
        {
            return Ok(unitOfWork.CustomerRepository.Get());
        }
        [HttpPost("Customer")]
        public IActionResult PostSingle([FromBody] Customer customer)
        {
            unitOfWork.CustomerRepository.Insert(customer);
            unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }
        [HttpPut("Customer")]
        public IActionResult PutSingle([FromBody] Customer customer)
        {
            unitOfWork.CustomerRepository.Update(customer);
            unitOfWork.Save();

            return NoContent();
        }
        [HttpDelete("Customers/{id}")]
        public IActionResult Delete(int id)
        {
            var customer = unitOfWork.CustomerRepository.Get(x => x.Id.Equals(id), includeProperties: "Products").FirstOrDefault();
            foreach (var item in customer.Products)
                unitOfWork.ProductRepository.Delete(item.Id);

            unitOfWork.CustomerRepository.Delete(id);
            unitOfWork.Save();

            return NoContent();
        }
    }
}
