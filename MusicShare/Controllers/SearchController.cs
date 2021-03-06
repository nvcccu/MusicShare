﻿using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BusinessLogic.Interfaces;
using CommonUtils;
using Core.TransportTypes;
using MusicShareWeb.Models;

namespace MusicShareWeb.Controllers {
    public class SearchController : BaseController {
        [HttpGet]
        public ActionResult Index() {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Search(GuitarTransportType gtp) {
            var sr = ServiceManager<IBusinessLogic>.Instance.Service.Search(gtp.Brand, gtp.Form, gtp.Color);
            var dataModel = new SearchResultModel(sr);
            return View("Index", dataModel);
        }

        [HttpGet]
        public JsonResult GetSampleGuitar(short? brand, short? form, short? color) {
            var sample = ServiceManager<IBusinessLogic>.Instance.Service.GetSampleGuitar(brand, form, color);
            return new JsonResult {
                Data = new KeyValuePair<string, string>("Url", sample.Image),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
            };
        }
    }
}