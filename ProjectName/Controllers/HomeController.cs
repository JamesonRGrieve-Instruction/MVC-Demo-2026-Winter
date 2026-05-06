using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectName.Models;
using ProjectName.Models.Exceptions;

namespace ProjectName.Controllers;

public class HomeController : Controller
{

    private static List<Example> examples = new List<Example>();
    [Authorize]
    public IActionResult Index(string name)
    {
        ViewBag.Exception = new CompositeException();
        if (string.IsNullOrWhiteSpace(name)) 
        {
            ViewBag.Exception.SubExceptions.Add(new Exception("Must provide name."));
        }
        

        if (ViewBag.Exception.SubExceptions.Count == 0) {
            examples.Add(new Example()
            {
                name = name,
                UserName =  User.Identity.Name
            });
        }



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
