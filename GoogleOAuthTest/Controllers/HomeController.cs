using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("Home")]
public class HomeController : Controller
{
    [Authorize]
    public IActionResult SecurePage()
    {
        return View();
    }
}
