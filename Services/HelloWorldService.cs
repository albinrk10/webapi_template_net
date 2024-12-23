namespace webapi.Services;

public class HelloWorldService : IHelloWorldService
{
    public string GetHelloWorld()
    {
        return "Hello Albin!";
    }
    
}

public interface IHelloWorldService
{
    string GetHelloWorld();
}