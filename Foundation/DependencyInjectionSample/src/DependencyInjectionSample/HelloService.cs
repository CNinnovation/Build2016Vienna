namespace DependencyInjectionSample
{
    public class HelloService : IHelloService
    {
        public string Hello(string name) =>
            $"Hello, {name}";
    }
}
