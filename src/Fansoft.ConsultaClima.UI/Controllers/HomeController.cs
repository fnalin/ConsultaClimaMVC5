using System.Web.Mvc;

namespace Fansoft.ConsultaClima.UI.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public ViewResult Index() => View();
        [Route("about")]
        public ViewResult About() => View();
        [Route("contact")]
        public ViewResult Contact() => View();
    }
}
