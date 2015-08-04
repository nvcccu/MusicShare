using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MusicShareWeb.Models.Lesson;

namespace MusicShareWeb.Controllers {
    public class LessonController : BaseController {
        public ActionResult Index(int id) {
            return View("Index", new LessonModel(BaseModel, id));
        }
        [HttpPost]
        public JsonResult SaveExercisesSpeed(int lessonId, Dictionary<string, string> speeds) {
            new LessonModel(BaseModel, lessonId, speeds.ToDictionary(s => Convert.ToInt32(s.Key), s => Convert.ToInt32(s.Value))).SaveExercisesSpeed();
            return null;
        }
    }
}