using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREBlogProject.ViewComponents.Category
{
    public class CategoryList : ViewComponent
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository(new TContext()));
        public IViewComponentResult Invoke()
        {
            var values = categoryManager.TGetList();
            return View(values);
        }
    }
}
