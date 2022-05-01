using Microsoft.AspNetCore.Mvc;
using ProgressiveForm.Entities;
using ProgressiveForm.Models;
using System.Diagnostics;

namespace ProgressiveForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IndexViewModel viewModel = new IndexViewModel();
            viewModel.ActivePage = "Basic";
            return View(viewModel);
        }

        public IActionResult PostForm(IndexViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                return View("Index", viewModel);
            }


            if (viewModel.ActivePage == "Save")
            {
                // database save

                LuciferContext context = new LuciferContext();

                User user = new User();
                user.FirstName = viewModel.FirstName;
                user.LastName = viewModel.LastName;



                user.CurrentDate = DateTime.ParseExact(viewModel.CurrentDate, "yyyy-MM-dd", null);
                user.LicenseExpiration = DateTime.ParseExact(viewModel.LicenseExpiration, "yyyy-MM-dd", null);
                
                user.TypeId = viewModel.TypeId;
                user.NumberOfCopies = viewModel.NumberOfCopies;




                context.Users.Add(user);
                context.SaveChanges();


                //redirect to index with reseted valued
                viewModel = new IndexViewModel();
                viewModel.ActivePage = "Basic";
                return View("Index", viewModel);

            }
            else
            {
                return View("Index", viewModel);
            }
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
}