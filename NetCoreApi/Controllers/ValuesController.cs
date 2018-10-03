using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestASMXServiceReference;

namespace NetCoreApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public string Get()
        {
            EndpointAddress endPointAddress = new EndpointAddress("http://localhost:57429/WebService1.asmx");

            //Send to LanDesk SOAP service.
            WebService1SoapClient soapClient = new WebService1SoapClient(WebService1SoapClient.EndpointConfiguration.WebService1Soap, 
                endPointAddress);
            var response = soapClient.HelloWorldAsync().Result;            

            return response.Body.HelloWorldResult;
        }        
    }
}
