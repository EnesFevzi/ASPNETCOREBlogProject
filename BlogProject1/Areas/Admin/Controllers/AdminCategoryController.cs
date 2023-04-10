﻿using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.BusinessLayer.ValidationRules;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using BlogProject1.EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace ASPNETCOREBlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index(int page = 1)
        {
            var values = _categoryService.TGetList().ToPagedList(page, 10);

            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {

            CategoryValidator validationRules = new CategoryValidator();
            var results = validationRules.Validate(category);
            if (results.IsValid)
            {
                category.CategoryStatus = true;
                _categoryService.TAdd(category);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult CategoryDelete(int id)
        {
            var value = _categoryService.TGetByID(id);
            _categoryService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var category = _categoryService.TGetByID(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            var existingCategory = _categoryService.TGetByID(category.CategoryID);

            if (existingCategory == null)
            {
                return NotFound();
            }

            existingCategory.CategoryName = category.CategoryName;
            existingCategory.CategoryDescription = category.CategoryDescription;

            _categoryService.TUpdate(existingCategory);

            return RedirectToAction("Index", "Category");
        }


    }
}
