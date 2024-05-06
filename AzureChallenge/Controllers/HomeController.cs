using AzureChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AzureChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
            //TODO: pull all the images from storage and add their urls to the photos list (hint: not a known count!)
            var photos = new AllPhotos();
            photos.PhotoURLs.Add("https://images.pexels.com/photos/21412136/pexels-photo-21412136/free-photo-of-klakkur-near-klaksvik-mountainous-island-shot-from-the-ocean-in-the-faroe-islands.jpeg");
            photos.PhotoURLs.Add("https://images.pexels.com/photos/9754/mountains-clouds-forest-fog.jpg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1");
            photos.PhotoURLs.Add("https://images.pexels.com/photos/618833/pexels-photo-618833.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1");

            var commonNonSecretShared = _config["SharedCommon"]?.ToString() ?? "Common shared value Not Set!";
            var commonSecretShared = _config["SharedSecret"]?.ToString() ?? "Secret value Not Set!";
            ViewData["SecretShared"] = commonSecretShared;
            ViewData["NonSecretShared"] = commonNonSecretShared;

            return View(photos);
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
