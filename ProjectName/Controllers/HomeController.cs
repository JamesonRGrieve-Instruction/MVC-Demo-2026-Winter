using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectName.Models;

namespace ProjectName.Controllers;

public class HomeController : Controller
{

    private static List<Example> examples = new List<Example>();
    [Authorize]
    public IActionResult Index(string name)
    {
        if (!string.IsNullOrWhiteSpace(name)) examples.Add(new Example()
        {
            name = name,
            UserName =  User.Identity.Name
        });
        ViewData["Examples"] = examples.Where(example => example.UserName == User.Identity.Name).ToArray();
        return View();
    }



    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
