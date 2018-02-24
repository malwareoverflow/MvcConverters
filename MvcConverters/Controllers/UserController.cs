using MvcConverters.AbstractRepository;
using MvcConverters.Infrastructure;
using MvcConverters.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcConverters.Controllers
{
    public class UserController : Controller
    {
        private IKernel kernel;
        private readonly ISelectList selectlistRepo;


        public UserController()
        {
            kernel = new StandardKernel(new DependencyInjectionResolver());


            selectlistRepo = kernel.Get<ISelectList>();
        }
        [Authorize]
        public ActionResult Dashboard()
       {
            selectlistRepo.Addtolist("Pdf", "Pdf");
            selectlistRepo.Addtolist("Word", "Word");
            ViewBag.listfrom = selectlistRepo.getList();
            ViewBag.listto = selectlistRepo.getList();
            return View();
        }
        //public ActionResult Dashboard(HttpPostedFileBase file)
        //{


        //}

      


       


    }
}