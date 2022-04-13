using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace myFirstServer.SampleController
{
    // ASP.NET uses 'reflection' to automatically find classes that follow a naming convention
    // ("_________Controller")

    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        // A controller's job is to handle a subset of requests to the server
        // based on the URL path and the HTTP method

        // Each category of request (GET, PUT, etc) with the same things to do
        // will be one method in this class

        private static readonly List<int> s_sample = new() { 12 };

        private readonly ILogger<SampleController> logger;
        
        public SampleController(ILogger<SampleController> logger)
        {
            this.logger = logger;
        }

        // logging is important
        // focus on the 6 levels of logging
        // 0 - Trace
        // 1 - Debug
        // 2 - Information
        // 3 - Warning
        // 4 - Error
        // 5 - Critical

        [HttpGet("/sample")]
        public ContentResult GetSample()
        {

            string json = JsonSerializer.Serialize(s_sample);

            var result = new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };
            logger.LogCritical("Critical Event");
            logger.LogInformation("Information Event");
            logger.LogTrace("Trace Event");

            return result;
        }

        [HttpPost("/sample")]
        public ContentResult AddSample([FromBody] int sample)
        {
            s_sample.Add(sample);
            string json = JsonSerializer.Serialize(s_sample);

            return new ContentResult()
            {
                StatusCode = 201,
                ContentType = "application/json",
                Content = json
            };
        }

        [HttpDelete("/sample")]
        public ContentResult RemoveLastSample()
        {
            s_sample.RemoveAt(s_sample.Count - 1);
            string json = JsonSerializer.Serialize(s_sample);

            return new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };
        }

        //[HttpDelete("/sample")]
        //public ContentResult RemoveSample([FromBody] int sample)
        //{
        //    s_sample.Remove(sample);
        //    string json = JsonSerializer.Serialize(s_sample);

        //    return new ContentResult()
        //    {
        //        StatusCode = 200,
        //        ContentType = "application/json",
        //        Content = json
        //    };
        //}

        //[HttpDelete("/sample")]
        //public ContentResult ClearSample()
        //{
        //    s_sample.Clear();
        //    string json = JsonSerializer.Serialize(s_sample);

        //    return new ContentResult()
        //    {
        //        StatusCode = 200,
        //        ContentType = "application/json",
        //        Content = json
        //    };
        //}

        [HttpPut("/sample")]
        public ContentResult ChangeLastSample([FromBody] int sample)
        {
            s_sample[s_sample.Count - 1] = sample;
            string json = JsonSerializer.Serialize(s_sample);

            return new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };
        }

    }
}
