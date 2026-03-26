using DotnetApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DotnetApplication.Controllers
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
            var vm = new Models.IndexViewModel
            {
                Options = new List<Models.OptionItem>
                {
                    new Models.OptionItem { Id = 1, Title = "Option A", Description = "Details about Option A." },
                    new Models.OptionItem { Id = 2, Title = "Option B", Description = "Details about Option B." },
                    new Models.OptionItem { Id = 3, Title = "Option C", Description = "Details about Option C." }
                },
                Items = new List<Models.PropertyItem>
                {
                    new Models.PropertyItem { Name = "A FRAME", AreaSqFt = 847m, RatePerSqFt = 2536m, Amount = 2148123.42m },
                    new Models.PropertyItem { Name = "DELTA 1BHK", AreaSqFt = 400m, RatePerSqFt = 2616m, Amount = 1046346.40m },
                    new Models.PropertyItem { Name = "DELTA 2 BHK", AreaSqFt = 822m, RatePerSqFt = 2515m, Amount = 2067308.23m },
                    new Models.PropertyItem { Name = "DELTA 3 BHK", AreaSqFt = 1466m, RatePerSqFt = 2071m, Amount = 3036047.55m },
                    new Models.PropertyItem { Name = "DELTA STUDIO A", AreaSqFt = 410m, RatePerSqFt = 2302m, Amount = 943904.15m },
                    new Models.PropertyItem { Name = "DELTA STUDIO B", AreaSqFt = 445m, RatePerSqFt = 2195m, Amount = 976877.18m }
                }
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Models.IndexViewModel vm)
        {
            // repopulate options after post
            vm.Options = new List<Models.OptionItem>
            {
                new Models.OptionItem { Id = 1, Title = "Option A", Description = "Details about Option A." },
                new Models.OptionItem { Id = 2, Title = "Option B", Description = "Details about Option B." },
                new Models.OptionItem { Id = 3, Title = "Option C", Description = "Details about Option C." }
            };

            // repopulate the property items so totals can be calculated after post
            vm.Items = new List<Models.PropertyItem>
            {
                new Models.PropertyItem { Name = "A FRAME", AreaSqFt = 847m, RatePerSqFt = 2536m, Amount = 2148123.42m },
                new Models.PropertyItem { Name = "DELTA 1BHK", AreaSqFt = 400m, RatePerSqFt = 2616m, Amount = 1046346.40m },
                new Models.PropertyItem { Name = "DELTA 2 BHK", AreaSqFt = 822m, RatePerSqFt = 2515m, Amount = 2067308.23m },
                new Models.PropertyItem { Name = "DELTA 3 BHK", AreaSqFt = 1466m, RatePerSqFt = 2071m, Amount = 3036047.55m },
                new Models.PropertyItem { Name = "DELTA STUDIO A", AreaSqFt = 410m, RatePerSqFt = 2302m, Amount = 943904.15m },
                new Models.PropertyItem { Name = "DELTA STUDIO B", AreaSqFt = 445m, RatePerSqFt = 2195m, Amount = 976877.18m }
            };

            // The view will show only name and rate initially. If vm.SelectedPropertyName is set
            // the selected property's full details will be displayed.
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRate(string editPropertyName)
        {
            var vm = BuildViewModel();
            vm.EditPropertyName = editPropertyName;
            return View("Index", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveRate(string editPropertyName, decimal newRate)
        {
            var vm = BuildViewModel();
            var item = vm.Items.FirstOrDefault(i => i.Name == editPropertyName);
            if (item != null)
            {
                item.RatePerSqFt = newRate;
                item.Amount = item.AreaSqFt * newRate;
            }
            vm.EditPropertyName = string.Empty;
            return View("Index", vm);
        }

        private Models.IndexViewModel BuildViewModel()
        {
            return new Models.IndexViewModel
            {
                Options = new List<Models.OptionItem>
                {
                    new Models.OptionItem { Id = 1, Title = "Option A", Description = "Details about Option A." },
                    new Models.OptionItem { Id = 2, Title = "Option B", Description = "Details about Option B." },
                    new Models.OptionItem { Id = 3, Title = "Option C", Description = "Details about Option C." }
                },
                Items = new List<Models.PropertyItem>
                {
                    new Models.PropertyItem { Name = "A FRAME", AreaSqFt = 847m, RatePerSqFt = 2536m, Amount = 2148123.42m },
                    new Models.PropertyItem { Name = "DELTA 1BHK", AreaSqFt = 400m, RatePerSqFt = 2616m, Amount = 1046346.40m },
                    new Models.PropertyItem { Name = "DELTA 2 BHK", AreaSqFt = 822m, RatePerSqFt = 2515m, Amount = 2067308.23m },
                    new Models.PropertyItem { Name = "DELTA 3 BHK", AreaSqFt = 1466m, RatePerSqFt = 2071m, Amount = 3036047.55m },
                    new Models.PropertyItem { Name = "DELTA STUDIO A", AreaSqFt = 410m, RatePerSqFt = 2302m, Amount = 943904.15m },
                    new Models.PropertyItem { Name = "DELTA STUDIO B", AreaSqFt = 445m, RatePerSqFt = 2195m, Amount = 976877.18m }
                }
            };
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
