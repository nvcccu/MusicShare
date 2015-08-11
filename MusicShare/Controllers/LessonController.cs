using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MusicShareWeb.Models.Lesson;

namespace MusicShareWeb.Controllers {
    public class LessonController : BaseController {
        public ActionResult Index(int? id) {
            return id.HasValue
                ? View("Lesson", new LessonModel(BaseModel, id.Value))
                : View("Index", new LessonListModel(BaseModel));
        }
        public ActionResult MinimizedLesson(int id) {
            return View("MinimizedLesson", new MinimizedLessonModel(BaseModel, id));
        }
        [HttpPost]
        public JsonResult SaveExercisesSpeed(int lessonId, Dictionary<string, string> speeds) {
            new LessonModel(BaseModel) {
                Speeds = speeds.ToDictionary(s => Convert.ToInt32(s.Key), s => Convert.ToInt32(s.Value))
            }.SaveExercisesSpeed(lessonId);
            return null;
        }
    }
}