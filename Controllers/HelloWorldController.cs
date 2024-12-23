using webapi.Services;

namespace webapi.Controllers;
using Microsoft.AspNetCore.Mvc;



[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;
     TareasContext dbContext;
    
    public HelloWorldController(IHelloWorldService helloWorld, TareasContext dbContext)
    {
        helloWorldService = helloWorld;
        dbContext = dbContext;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(helloWorldService.GetHelloWorld());
    }
    
    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
       dbContext.Database.EnsureCreated();
        return Ok();
    }
}
