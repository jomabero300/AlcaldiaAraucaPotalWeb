using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Controllers.Estrategias
{
    public class CulturaController : Controller
    {
        public IActionResult Index()
        {
            Models.ContentModelView obj;
            List<Models.ContentModelView> lobj = new List<Models.ContentModelView>();

            obj = new Models.ContentModelView
            {
                title = "Card Layout 1",
                text = "Hello every this video I want to show how to use cardbootstrap 4 with data binding sourcer.",
                img = "https://image.shutterstock.com/image-vector/breaking-news-background-tv-channel-260nw-731436349.jpg"
            };

            lobj.Add(obj);

            obj = new Models.ContentModelView
            {
                title = "Card Layout 2",
                text = "Hello every this video I want to show how to use cardbootstrap 4 with data binding sourcer.",
                img = "https://t4.ftcdn.net/jpg/03/31/19/05/360_F_331190574_qlCiuR5fWBaQuC7jMFGasykUP1TAnTqT.jpg"
            };

            lobj.Add(obj);

            obj = new Models.ContentModelView
            {
                title = "Card Layout 3",
                text = "Hello every this video I want to show how to use cardbootstrap 4 with data binding sourcer.",
                img = "https://media.gettyimages.com/vectors/live-breaking-news-headline-with-blue-and-red-color-background-vector-id1221950506?s=612x612"
            };


            obj = new Models.ContentModelView
            {
                title = "Card Layout 4",
                text = "Hello every this video I want to show how to use cardbootstrap 4 with data binding sourcer.",
                img = "https://media.gettyimages.com/vectors/breaking-news-background-stock-illustration-vector-id1219181572?s=612x612"
            };

            lobj.Add(obj);


            lobj.Add(obj);


            return View(lobj);
        }
    }
}
