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

        public IActionResult Index()
        {

            // jsut to provide form to add user form
            //return View();
            //dont require the rest of code



            // to provide list of dummy records //
            //UserListViewModel userListVm = new UserListViewModel();
            //userListVm.users.Add(new UserViewModel() { Name = "Sagar", Age = "50", City = "Mumbai" });
            //userListVm.users.Add(new UserViewModel());
            //userListVm.users.Add(new UserViewModel());
            //userListVm.users.Add(new UserViewModel() { Name = "Mike", Age = "55", City = "London" });


            // fetching from warehouse ; in this case its a static file
            UserListViewModel userListVm = new UserListViewModel();
            userListVm.users = UserManager.users;

            userListVm.CurrentUser = "Mike";

            return View("Index", userListVm);
        }

        public IActionResult AddUser(UserViewModel user)
        {
            //data base insersion may be here
            UserManager.users.Add(user);

            //UserListViewModel userListVm = new UserListViewModel();
            //userListVm.users = UserManager.users;

            return View();
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