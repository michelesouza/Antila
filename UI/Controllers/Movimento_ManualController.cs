using ENT;
using NEG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class Movimento_ManualController : Controller
    {  
        // GET: Movimento_Manual
        [HttpGet]
        public ActionResult Index()
        {
            Movimento_ManualModel models = new Movimento_ManualModel();
            models.popularGrid();
            models.popularCheksBox();

            return View(models);
        }

        // POST: Movimento_Manual
        [HttpPost]
        public ActionResult Index(Movimento_ManualModel models)
        {
            models.GravarDados(models);

            return RedirectToAction("Index"); 
        }
    }
}