using Microsoft.AspNetCore.Mvc;
namespace TaskWebApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    // GET
    [HttpGet]
    public async Task<IActionResult> GetContentAsync()
    {
        var myTask = new HttpClient().GetStringAsync("https://www.google.com");

        var data = await myTask;
        return Ok(data);

    }
}
