using Microsoft.AspNetCore.Mvc;
using ClientOrderManager.API.Data;
using ClientOrderManager.API.Models;
using Microsoft.Extensions.Logging;
using ClientOrderManager.API.Helpers;

namespace ClientOrderManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<OrdersController> _logger;
        private readonly EmailService _emailService;

        public OrdersController(AppDbContext context, ILogger<OrdersController> logger, EmailService emailService)
        {
            _context = context;
            _logger = logger;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            _logger.LogInformation("Fetching all orders");
            return Ok(_context.Orders.ToList());
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            _logger.LogInformation("Created order for {ClientName}", order.ClientName);

            _emailService.SendOrderCreatedEmail(order);
            return CreatedAtAction(nameof(GetOrders), new { id = order.Id }, order);
        }
    }
}