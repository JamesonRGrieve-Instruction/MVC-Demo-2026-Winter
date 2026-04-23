using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectName.Models;

namespace ProjectName.Controllers;

public class ExampleController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Details()
    {
        return View();
    }
    public IActionResult Create()
    {
        return View();
    }
    public IActionResult Edit()
    {
        return View();
    }
    public IActionResult Delete()
    {
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
