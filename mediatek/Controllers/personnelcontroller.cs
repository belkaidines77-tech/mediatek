using Microsoft.AspNetCore.Mvc;
using mediatek.Models;
using mediatek.dal;

namespace mediatek.Controllers
{
    public class personnelcontroller : Controller
    {
        private personneldal personneldal;

        public personnelcontroller()
        {
            personneldal = new personneldal();
        }

        public IActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        [HttpGet]
        public JsonResult GetAllPersonnels()
        {
            return Json(personneldal.GetAllPersonnels());
        }

        [HttpPost]
        public JsonResult AddPersonnel([FromBody] personnel personnel)
        {
            personneldal.AddPersonnel(personnel);
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult UpdatePersonnel([FromBody] personnel personnel)
        {
            personneldal.UpdatePersonnel(personnel);
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult DeletePersonnel(int id)
        {
            personneldal.DeletePersonnel(id);
            return Json(new { success = true });
        }
    }
}
