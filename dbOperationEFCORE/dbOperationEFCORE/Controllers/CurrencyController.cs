using dbOperationEFCORE.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dbOperationEFCORE.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public CurrencyController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        [HttpGet("")]
        public IActionResult GetAllCurrenties()
        {
            var result = this.appDbContext.Currencies.ToList();
            return Ok(result);
        }

    }
}
