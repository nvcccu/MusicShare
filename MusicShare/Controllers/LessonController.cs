using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
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
        public JsonResult SaveExercisesSpeed(Dictionary<string, string> speeds) {
            new LessonModel(BaseModel) {
                Speeds = speeds.ToDictionary(s => Convert.ToInt32(s.Key), s => Convert.ToInt32(s.Value))
            }.SaveExercisesSpeed();
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
            return new JsonResult {
                Data = new {
                    redirectUrl = Url.Action("Plan", new {id = createdPlanId})
                }
            };
        }
        [HttpPost]
        public ActionResult AddExrciseToPlan(int planId, int exerciseId) {
            new PlanModel(BaseModel).AddExercise(planId, exerciseId);
            return null;
        }
        [HttpGet]
        public ActionResult Train(int planId) {
            return View("Train", new TrainModel(BaseModel, planId));
        }
        [HttpGet]
        public ActionResult Stat() {
            ServiceManager<IBusinessLogic>.Instance.Service.AddUserAction(GuestId, ActionId.OpenStat);
            return View("Stat", new StatModel(BaseModel));
        }
        [HttpGet]
        public ActionResult Promo() {
            return View("Promo", BaseModel);
        }
        [HttpPost]
        public JsonResult DeleteStatPreset(int statPresetId) {
            return new JsonResult {
                Data = new {
                    success = new StatModel().DeleteStatPreset(statPresetId)
                }
            };
        }
        [HttpPost]
        public JsonResult SaveStatPreset(StatPresetDto statPreset, List<string> exercises) {
            statPreset.Exercises = exercises.Select(e => Convert.ToInt32(e)).ToList();
            statPreset.OwnerAccountId = CurrentUser.Id;
            var savedStatPreset = new StatModel().SaveStatPreset(statPreset);
            return new JsonResult {
                Data = new {
                    success = savedStatPreset != null,
                    statPreset = savedStatPreset
                }
            };
        }
        [HttpPost]
        public JsonResult UpdateStatPreset(int id, string name, List<string> exercises) {
            return new JsonResult {
                Data = new {
                    success = new StatModel().UpdateStatPresetName(id, name, exercises, CurrentUser.Id)
                }
            };
        }
    }
}