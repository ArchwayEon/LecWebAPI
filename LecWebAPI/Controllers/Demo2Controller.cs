using Microsoft.AspNetCore.Mvc;

namespace LecWebAPI.Controllers;

[Route("[controller]/[action]")]
public class Demo2Controller : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return Content("Another simple GET request");
    }

    [HttpGet("{id}")]
    public IActionResult Details(int id)
    {
        return Content($"Details of {id}");
    }
}
