using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lesson8; 
using Microsoft.EntityFrameworkCore;

namespace Lesson8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CustomersController(MyDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            if (_context.Customer == null)
            {
                return Problem("Entity set 'MyDbContext.Customer' is null.");
            }


            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }
    }
}