using Microsoft.AspNetCore.Mvc;
using UpSchoolChainOfResponsibility.ChainOfResponsibility;
using UpSchoolChainOfResponsibility.DAL.Entities;

namespace UpSchoolChainOfResponsibility.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(WithDrawModel p)
        {
            Employee treasurer = new Treasurer();
            Employee managerHelper = new ManagerHelper();
            Employee manager = new Manager();
            Employee regionManager = new RegionManager();

            treasurer.SetNextApprover(managerHelper);
            managerHelper.SetNextApprover(manager);
            manager.SetNextApprover(regionManager);

            treasurer.ProcessRequest(p);
            return View();
        }
    }
}
