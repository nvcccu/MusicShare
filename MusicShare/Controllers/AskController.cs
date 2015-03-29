﻿using System.Web.Mvc;
using MusicShareWeb.Models.Ask;

namespace MusicShareWeb.Controllers {
    public class AskController : Controller {
        [HttpGet]
        public ActionResult Index(long? q) {
            return q.HasValue
                ? View("Thread", new AskThreadModel(q.Value))
                : View("Index", new QuestionListModel());
        }
    }
}