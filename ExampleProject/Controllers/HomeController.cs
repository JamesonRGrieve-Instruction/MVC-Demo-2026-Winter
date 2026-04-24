using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExampleProject.Models;

namespace ExampleProject.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Input()
    {
        return View();
    }

    public IActionResult Output(string name, string town, string food, string footwear, string vehicle, string colour)
    {
        if (string.IsNullOrWhiteSpace(name) || 
        string.IsNullOrWhiteSpace(town) || 
        string.IsNullOrWhiteSpace(food) || 
        string.IsNullOrWhiteSpace(footwear) || 
        string.IsNullOrWhiteSpace(vehicle) || 
        string.IsNullOrWhiteSpace(colour)
        )
        {
            return RedirectToAction(nameof(Input));
        }
        ViewData["Name"] = name;
        ViewData["Town"] = town;
        ViewData["Food"] = food;
        ViewData["Footwear"] = footwear;
        ViewData["Vehicle"] = vehicle;
        ViewData["Colour"] = colour;
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
