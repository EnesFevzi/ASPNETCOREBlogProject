﻿using ASPNETCOREBlogProject.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ASPNETCOREBlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            List<CategoryModel> list = new List<CategoryModel>();
            list.Add(new CategoryModel
            {
                categoryname = "Teknoloji",
                categorycount = 14
            });
            list.Add(new CategoryModel
            {
                categoryname = "Yazılım",
                categorycount = 5
            });
            list.Add(new CategoryModel
            {
                categoryname = "Spor",
                categorycount = 2
            });
            return Json(new { jsonlist = list });
        }
    }
}
