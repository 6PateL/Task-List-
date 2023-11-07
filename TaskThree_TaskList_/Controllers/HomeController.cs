using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskThree_TaskList_.Data;
using TaskThree_TaskList_.Models;

namespace TaskThree_TaskList_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _db; 

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            List<TaskListModel> models = _db.TaskListModels.ToList(); 
            return View(models);
        }

        public IActionResult Create()
        {
            return View(); 
        }
        [HttpPost]
        public IActionResult Create(TaskListModel model)
        {
            if (ModelState.IsValid)
            {
                _db.TaskListModels.Add(model);
                _db.SaveChanges(); 
                return RedirectToAction("Index");
            }
            return View(); 
        }

        public IActionResult Edit(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound(); 
            }
            var currentTask = _db.TaskListModels.Find(Id);
            if (currentTask == null)
            {
                return NotFound();
            }
            return View(currentTask); 
        }
        [HttpPost]
        public IActionResult Edit(TaskListModel model)
        {
            if (ModelState.IsValid)
            {
                _db.TaskListModels.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return View(); 
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var currentTask = _db.TaskListModels.Find(Id);
            if (currentTask == null)
            {
                return NotFound();
            }
            return View(currentTask);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? Id)
        {
            var currentTask = _db.TaskListModels.Find(Id);
            if(currentTask == null)
            {
                return NotFound(); 
            }
            if (ModelState.IsValid)
            {
                _db.TaskListModels.Remove(currentTask);
                _db.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return View();
        }
    }
}