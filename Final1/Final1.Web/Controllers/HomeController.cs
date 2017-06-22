using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace Final1.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : Final1ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}