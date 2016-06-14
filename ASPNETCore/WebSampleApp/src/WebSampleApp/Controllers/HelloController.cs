using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSampleApp.Services;

namespace WebSampleApp.Controllers
{
    public class HelloController
    {
        private IHelloService _helloService;
        public HelloController(IHelloService helloService)
        {
            _helloService = helloService;
        }
        public string Index(string name)
        {
            return $"<h2>{_helloService.Hello(name)}</h2>";
        }
    }
}
