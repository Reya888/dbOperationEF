using dbOperationEFCORE.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAllCurrenties()
        {
            //var result = this.appDbContext.Currencies.ToList();
            //var result = (from Currency in this.appDbContext.Currencies
            //              select Currency).ToList();
            //var result =await this.appDbContext.Currencies.ToListAsync();
            var result = await (from Currency in this.appDbContext.Currencies
                                select Currency).ToListAsync();
            return Ok(result);
        }
        [HttpGet("{id:INT}")]
        public async Task<IActionResult> GetAllCurrencyByIdAsync([FromRoute] int id)
        {
            var result = await this.appDbContext.Currencies.FindAsync(id);
            return Ok(result);
        }
        //[HttpGet("{Name}")]
        [HttpGet("{Name}/{Description}")]
        public async Task<IActionResult> GetAllCurrencyByName([FromRoute] String Name, [FromRoute] String Description)
        {
            //var result = await this.appDbContext.Currencies.Where(x => x.Title == Name).FirstOrDefaultAsync();
            //var result = await this.appDbContext.Currencies.Where(x => x.Title == Name).FirstAsync();
            //var result = await this.appDbContext.Currencies.FirstAsync(x => x.Title == Name);//THERE WONT BE ANY SEARCHING ONLY IF THE RECORD IS FOUND ,PERFORMANCE BETTER
            var result = await this.appDbContext.Currencies.FirstOrDefaultAsync(x => x.Title == Name && x.Description == Description);

            return Ok(result);
        }
        [HttpGet("{Name}")]
        public async Task<IActionResult> GetAllCurrencyMULPara([FromRoute] String Name, [FromQuery] String? Description)
        {
            var result = await this.appDbContext.Currencies.FirstOrDefaultAsync(x => x.Title == Name &&
            (string.IsNullOrEmpty(x.Description) || x.Description == Description));

            return Ok(result);
        }

        [HttpPost("All")]
        public async Task<IActionResult> GetMultipleIds([FromBody] List<int> ids )
        {
            //var ids = new List<int> { 3, 2 };
            var result = await this.appDbContext.Currencies
                .Where(x => ids.Contains(x.Id))
                //.Select(x => new THE OTHER COLUMN NAMES WILL NOT BE VISIBLE ALSO AS FOR THE BELOW STATEMENT IT DISPLAYS WITH NULL , BUT WITH THIS IT WON'T
                .Select(x=>new Currency()
                {
                    Id = x.Id,
                    Title = x.Title,
                })
                .ToListAsync();
            return Ok(result);
        }
    }
}
