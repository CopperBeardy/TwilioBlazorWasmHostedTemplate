using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using TwilioBlazorWASMTemplate.Server.Services;
using TwilioBlazorWASMTemplate.Shared;

namespace TwilioBlazorWASMTemplate.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly IExampleService exampleService;

        public SampleController(IExampleService exampleService)
        {
            this.exampleService = exampleService;
           
        }

        [HttpGet]
        public SampleData Get() {
            // code of doing someting for example purposes           
            return new SampleData
            {
                Data = exampleService.DoSomething() 
            };
        }

           
        
    }
}
