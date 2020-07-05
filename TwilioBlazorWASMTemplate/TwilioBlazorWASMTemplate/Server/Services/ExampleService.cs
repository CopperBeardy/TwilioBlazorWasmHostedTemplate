using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwilioBlazorWASMTemplate.Server.Models;
using TwilioBlazorWASMTemplate.Shared;

namespace TwilioBlazorWASMTemplate.Server.Services
{
    //example Service 
    public class ExampleService : IExampleService
    {


        private readonly TwilioAccountDetails _twilioAccountDetails;

        public ExampleService(IOptions<TwilioAccountDetails> twilioAccountDetails) =>
            // Get value from the DI option 
            _twilioAccountDetails = twilioAccountDetails.Value ?? throw new ArgumentException(nameof(twilioAccountDetails));


        public string DoSomething() => $"{_twilioAccountDetails.AccountSID},{_twilioAccountDetails.AuthToken}";
                
    }
}
