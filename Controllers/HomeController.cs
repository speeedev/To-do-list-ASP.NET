using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _1.Models;
using _1.Models.Entities;

namespace _1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    TododbContext db = new TododbContext();

    [Route("/")]
    public IActionResult Index()
    {
        var model = new TodoViewModel() { Todos = db.Todos.OrderByDescending(x => x.Id).ToList(), };
        return View(model);
    }


    [HttpPost]
    [IgnoreAntiforgeryToken]
    [Route("/add-todo")]
    public IActionResult AddTodo(Todo postedData)
    {
        Todo toAdd = new Todo();
        toAdd.Title = postedData.Title;
        toAdd.IsComplated = false;
        db.Add(toAdd);
        db.SaveChanges();

        return Redirect("/");
    }

    [Route("/delete-todo/{id}")]
    public IActionResult DeleteTodo(int id)
    {
        Todo toDelete = db.Todos.Find(id)!;

        db.Remove(toDelete);
        db.SaveChanges();

        return Content("Kayıt başarıyla silindi.");
    }

    [Route("/update-todo/{id}")]
    public IActionResult UpdateTodo(int id)
    {
        Todo toUpdate = db.Todos.Find(id)!;

        toUpdate.IsComplated = !toUpdate.IsComplated;
        db.Entry(toUpdate).CurrentValues.SetValues(toUpdate);
        db.SaveChanges();

        return Content(toUpdate.IsComplated.ToString());
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }
}
