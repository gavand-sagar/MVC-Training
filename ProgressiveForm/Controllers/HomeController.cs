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
            viewModel.CurrentActivePage = "Basic";
            viewModel.NextActivePage = "Basic";
            return View(viewModel);
        }

        public IActionResult PostForm(IndexViewModel viewModel)
        {





            if (viewModel.NextActivePage == "Final" && viewModel.CurrentActivePage == "Basic")
            {
                viewModel.NextActivePage = "Basic";
                viewModel.CurrentActivePage = "Basic";
                return View("Index", viewModel);
            }



            if (!ModelState.IsValid)
            {
                viewModel.NextActivePage = viewModel.CurrentActivePage;
                return View("Index", viewModel);
            }





            viewModel.CurrentActivePage = viewModel.NextActivePage;

            if (viewModel.NextActivePage == "Final" || viewModel.NextActivePage == "Basic" || viewModel.NextActivePage == "Middle")
            {
                return View("Index", viewModel);
            }


            if (viewModel.NextActivePage == "Save")
            {
                // database save



                // checking if same entry ther or not? LINQ
                LuciferContext context = new LuciferContext();


                //var result = from u in context.Users2s
                //             where u.FirstName == viewModel.FirstName
                //             select u;

                var result = context.Users2s.Where(x => x.FirstName == viewModel.FirstName);

                if (result.Count() > 0)
                {
                    viewModel.IsAlreadyPresent = true;
                    viewModel.OldRecords = result.ToList();
                    return View("Index", viewModel);
                }
                

                Users2 user = new Users2();
                user.FirstName = viewModel.FirstName;
                user.LastName = viewModel.LastName;



                user.CurrentDate = DateTime.ParseExact(viewModel.CurrentDate, "yyyy-MM-dd", null);
                user.LicenseExpiration = DateTime.ParseExact(viewModel.LicenseExpiration, "yyyy-MM-dd", null);

                user.Type = viewModel.TypeId;
                user.NumberOfCopies = viewModel.NumberOfCopies;




                context.Users2s.Add(user);
                context.SaveChanges();


                //redirect to index with reseted valued
                viewModel = new IndexViewModel();
                viewModel.NextActivePage = "Basic";
                return View("Index", viewModel);

            }
            else
            {
                var OldRecordId = Convert.ToInt32(viewModel.NextActivePage);
                LuciferContext context = new LuciferContext();

                var oldRecord = context.Users2s.Where(x => x.Id == OldRecordId).FirstOrDefault();

                oldRecord.LastName = viewModel.LastName;
                oldRecord.NumberOfCopies = viewModel.NumberOfCopies;

                context.SaveChanges();


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