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
        private readonly IConveters convertersRepo;

        public UserController()
        {
            kernel = new StandardKernel(new DependencyInjectionResolver());

            convertersRepo = kernel.Get<IConveters>();
            selectlistRepo = kernel.Get<ISelectList>();
        }
       //hghjgj
        public ActionResult Dashboard()
        {

            convertersRepo.PdftoHtml(new ConvertersTypes.PdftoHtml());
            selectlistRepo.Addtolist("Pdf", "Pdf");
            selectlistRepo.Addtolist("Word", "Word");
            ViewBag.listfrom = selectlistRepo.getList();
            ViewBag.listto = selectlistRepo.getList();
            return View();
        }
      







    }
}