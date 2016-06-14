namespace DependencyInjectionSample
{
    public class HelloController
    {
        private readonly IHelloService _helloService;
        public HelloController(IHelloService helloService)
        {
            _helloService = helloService;
        }

        public string Index(string name) => $"<h1>{_helloService.Hello(name)}</h1>";

    }
}
