using Coffee_Shop_Lab.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Coffee_Shop_Lab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        CoffeeShopContext db = new CoffeeShopContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();

            return RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            List<Customer> customers = db.Customers.ToList();
            Customer customer = customers.Last();
            return View(customer);
        }

        public IActionResult ProductIndexView()
        {
            List <Product> products = db.Products.ToList();
            return View(products);
        }

        public IActionResult ProductDetailView(string Name)
        {
            List <Product> productList = db.Products.ToList();
            Product selectedProduct = productList.Single(x => x.Name == Name);
            return View(selectedProduct);
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