using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {       
        public IActionResult Index()
        {            
            return View();
        }
    }
}
