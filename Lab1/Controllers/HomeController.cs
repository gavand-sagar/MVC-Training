using Lab1.Models;
using Lab1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        string name = "sagar";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult index()
        {
            // fetching from warehouse ; in this case its a static file
            UserListViewModel userListVm = new UserListViewModel();

            userListVm.users = UserManager.users;

            userListVm.CurrentUser = "Mike";

            return View("Index", userListVm);


            //return View("Index");
        }

        public IActionResult AddUser(UserViewModel sadfsadfsadf)
        {
            //data base insersion may be here
            //UserManager.users.Add(user);
            UserManager.AddUser(sadfsadfsadf);

            //UserListViewModel userListVm = new UserListViewModel();
            //userListVm.users = UserManager.users;

            return View();
        }


        public IActionResult Edit(int id)
        {
            UserListViewModel userListVm = new UserListViewModel();
            
            userListVm.users = UserManager.users;

            userListVm.user = UserManager.users.Where(x => x.Id == id).FirstOrDefault();


            return View("Index", userListVm);
        }

        public IActionResult Delete(int id)
        {
            UserManager.DeleteUser(id);

            return View("Delete");
        }

        public IActionResult Privacy()
        {
            ViewData["Title"] = "Privacy";
            ViewData["UserName"] = "Sagar";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}