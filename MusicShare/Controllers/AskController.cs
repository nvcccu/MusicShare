﻿using System.Web.Mvc;
using MusicShareWeb.Models.Ask;

namespace MusicShareWeb.Controllers {
    public class AskController : BaseController {
        [HttpGet]
        public ActionResult Index(long? q) {
            return q.HasValue
                ? View("Thread", new AskThreadModel(BaseModel, q.Value))
                : View("List", new QuestionListModel(BaseModel));
        }
        [HttpGet]
        public ActionResult New() {
            return View("New");
        }
        [HttpPost]
        public ActionResult New(QuestionModel question) {
            return RedirectToAction("Index", new {q = question.CreateNewQuestion()});
        }
    }
}