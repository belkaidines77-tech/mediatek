using Microsoft.AspNetCore.Mvc;
using mediatek.Models;
using mediatek.dal;
using System;

namespace mediatek.Controllers
{
    public class AbsenceController : Controller
    {
        public IActionResult Index(int idpersonnel)
        {
            ViewBag.IdPersonnel = idpersonnel;
            return View("~/Views/Absence/Index.cshtml");
        }

        [HttpGet]
        public JsonResult GetAbsences(int idpersonnel)
        {
            AbsenceDal dal = new AbsenceDal();
            return Json(dal.GetAbsencesByPersonnel(idpersonnel));
        }

        [HttpPost]
        public JsonResult AddAbsence([FromBody] absence a)
        {
            AbsenceDal dal = new AbsenceDal();
            string result = dal.AddAbsence(a);
            return Json(new { success = result == "OK", message = result });
        }

        public class UpdateAbsenceRequest
        {
            public int idpersonnel { get; set; }
            public DateTime datedebut { get; set; }
            public DateTime datefin { get; set; }
            public int idmotif { get; set; }
            public DateTime ancienneDebut { get; set; }
        }

        [HttpPost]
        public JsonResult UpdateAbsence([FromBody] UpdateAbsenceRequest req)
        {
            absence a = new absence
            {
                idpersonnel = req.idpersonnel,
                datedebut = req.datedebut,
                datefin = req.datefin,
                idmotif = req.idmotif
            };
            AbsenceDal dal = new AbsenceDal();
            string result = dal.UpdateAbsence(a, req.ancienneDebut);
            return Json(new { success = result == "OK", message = result });
        }

        [HttpPost]
        public JsonResult DeleteAbsence(int idpersonnel, DateTime datedebut)
        {
            AbsenceDal dal = new AbsenceDal();
            int result = dal.DeleteAbsence(idpersonnel, datedebut);
            return Json(new { success = result > 0 });
        }
    }
}