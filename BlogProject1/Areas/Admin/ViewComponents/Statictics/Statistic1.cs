using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace ASPNETCOREBlogProject.Areas.Admin.ViewComponents.Statictics
{
    public class Statistic1 : ViewComponent
    {

        private readonly TContext _context;
        private readonly IBlogService _blogService;

        public Statistic1(TContext context, IBlogService blogService)
        {
            _context = context;
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = _blogService.TGetList().Count;
            ViewBag.v2 = _context.Contacts.Count();
            ViewBag.v3 = _context.Comments.Count();

            string api = "64d476e683236d625b8f0a39392c240a";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;


            return View();
        }
    }
}
