using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Api.Controllers
{
    [Route("api/[controller")]
    [ApiController]
    public class CountController : ControllerBase
    {
        // Fields
        static private int count = 0;
        private readonly ILogger<CountController> _logger;

        // Constructors
        public CountController(ILogger<CountController> logger)
        {
            this._logger = logger;
        }

        // Methods

        // Every tume we call the Get method, I want to return the number of times the mothod has been called
        // GET: api/CountController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            count++;
            _logger.LogInformation("Count.Get executed. Count: {count}", count);
            return new string[] { count.ToString() };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        





    }

}
