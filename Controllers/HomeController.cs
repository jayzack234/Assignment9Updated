using Assignment9Updated.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment9Updated.Controllers
{
    public class HomeController : Controller
    {
        //Bring in a tasklistocntext
        private TaskListContext context { get; set; }
        //Constructor, which will build an instance of TaskListContext when called
        public HomeController(TaskListContext con)
        {
            context = con;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterTask()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EnterTask(TaskItem t)
        {
            //Passes a model that will then add an entry in the database
            //Add the EnterTask information that was just passed in
            if (ModelState.IsValid)
            {
                context.Tasks.Add(t);
                context.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public IActionResult Display()
        {
            return View(context.Tasks);
        }
        [HttpPost]
        public IActionResult Display(TaskItem t)
        {
            if (ModelState.IsValid)
            {
                context.Tasks.Remove(t);
                context.SaveChanges();
            }
            return View();
        }
        //The ability to edit a submission using get and post
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //match up passed id with id stored in database
            var movie = context.Tasks.Where(s => s.MovieId == id).FirstOrDefault();

            return View(movie);
        }
        [HttpPost]
        public IActionResult Edit(TaskItem task)
        {
            //match up passed id with id stored in database
            var mov = context.Tasks.Where(s => s.MovieId == task.MovieId).FirstOrDefault();

            context.Tasks.Remove(mov);
            context.Tasks.Add(task);

            //Save changes
            context.SaveChanges();
            //Make sure these changes make it to the display page, and context.tasks coordinates with what is in the dbcontext file
            return RedirectToAction("Display", context.Tasks);
        }
        //The ability to delete a submission
        public IActionResult Delete(int id)
        {
            //match up passed id with id stored in database
            var movie = context.Tasks.Where(s => s.MovieId == id).FirstOrDefault();

            //Use the remove functionality built into ASP
            context.Tasks.Remove(movie);
            context.SaveChanges();

            return RedirectToAction("Display");
        }
        public IActionResult MyPodcasts()
        {
            return View();
        }
    }
}
