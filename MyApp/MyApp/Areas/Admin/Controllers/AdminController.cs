﻿using MyApp.Areas.Admin.Extentions;
using MyApp.Areas.Admin.Repository.Models;
using MyApp.Areas.Admin.Models;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApp.Areas.Admin.Controllers
{
    [HandleError]
    public class AdminController : BaseController
    {
        [HttpGet]
        public ActionResult Edit()
        {
            var text = textData.GetText(userId);
            var model = new EditPageViewModel()
            {
                Title = text.Title,
                Description = text.Description,
                Profile_1 = text.Profile_1
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditPageViewModel model)
        {
            textData.SaveText(new RegisterTextRequest(userId, model.Title, model.Description, model.Profile_1));
            model.ExecuteResultMessage = "変更しました";

            return View(model);
        }

        [HttpGet]
        public ActionResult Preview()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult GetPreviewPage()
        {
            var text = textData.GetText(userId);

            return PartialView("_PreviewPartial" ,new PreviewPartialViewModel(text.Title, text.Description, text.Profile_1));
        }
    }
}