﻿using System.Web.Mvc;
using MusicShareWeb.Models;

namespace MusicShareWeb.Controllers {
    public class DesignerController : BaseController {
        public ActionResult Index() {
            var model = new DesignerModel(BaseModel);
            return View("Index", model);
        }
    }
}