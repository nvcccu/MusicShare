using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Core.Enums;
using Core.TransportTypes;
using MusicShareWeb.Models.Lesson;

namespace MusicShareWeb.Controllers {
    public class LessonController : BaseController {
        [HttpGet]
        public ActionResult Index(int? id) {
            return id.HasValue
                ? View("Lesson", new LessonModel(BaseModel, id.Value, false))
                : View("Index", new LessonListModel(BaseModel));
        }
        [HttpGet]
        public ActionResult MinimizedLesson(int id) {
            return View("Lesson", new LessonModel(BaseModel, id, true));
        }
        [HttpPost]
        public JsonResult SaveExercisesSpeed(int lessonId, Dictionary<string, string> speeds) {
            new LessonModel(BaseModel) {
                Speeds = speeds.ToDictionary(s => Convert.ToInt32(s.Key), s => Convert.ToInt32(s.Value))
            }.SaveExercisesSpeed(lessonId);
            return null;
        }
        [HttpGet]
        public ActionResult Plan(int? id) {
            return View("Plan", id.HasValue ? new PlanModel(BaseModel, id.Value) : new PlanModel(BaseModel));
        }
        [HttpPost]
        public JsonResult SavePlan(PlanDto plan) {
            plan.OwnerAccountId = CurrentUser.Id;
            var createdPlanId = new PlanModel(BaseModel).Save(plan);
            var url = Url.Action("Plan", new {id = createdPlanId});
            return new JsonResult {
                Data = new {
                    redirectUrl = url
                }
            };
        }
        [HttpPost]
        public JsonResult UpdatePlan(PlanDto plan) {
            plan.OwnerAccountId = CurrentUser.Id;
            new PlanModel(BaseModel).Update(plan);
            var createdPlanId = new PlanModel(BaseModel, plan.Id);
            var url = Url.Action("Plan", new {id = createdPlanId});
            return new JsonResult {
                Data = new {
                    redirectUrl = url
                }
            };
        }
    }
}