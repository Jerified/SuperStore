using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SuperStore.Models;

namespace SuperStore.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
}
