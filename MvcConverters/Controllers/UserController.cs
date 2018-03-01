using MvcConverters.AbstractRepository;
using MvcConverters.Infrastructure;
using MvcConverters.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MvcConverters.Controllers
{
    public class UserController : Controller
    {
        private IKernel kernel;
        private readonly ISelectList selectlistRepo;
        private readonly IConveters convertersRepo;
        private readonly IMethods methodsRepo;

        public UserController()


        {
            kernel = new StandardKernel(new DependencyInjectionResolver());

            convertersRepo = kernel.Get<IConveters>();
            selectlistRepo = kernel.Get<ISelectList>();
            methodsRepo = kernel.Get<IMethods>();
        }


      
        public ActionResult Dashboard()
        {
            methodsRepo.Addtolist("HtmltoPdf");
            methodsRepo.Addtolist("PdftoHtml");
            methodsRepo.Addtolist("PdftoWord");
            methodsRepo.Addtolist("WordtoPdf");
            ViewBag.RenderView = methodsRepo.getList();
            selectlistRepo.Addtolist("Pdf", "Pdf");
            selectlistRepo.Addtolist("Word", "Word");
            ViewBag.listfrom = selectlistRepo.getList();
            ViewBag.listto = selectlistRepo.getList();
            return View();
        }

      

      [HttpPost]
      public HttpResponseMessage Dashboard(HttpPostedFileBase file,string typeofmodel)
        {
           
            Type model = Type.GetType($"MvcConverters.ConvertersTypes.{typeofmodel}");
            if (model!=null)
            {
              
                object modelInstance = Activator.CreateInstance(model);
                PropertyInfo properties = modelInstance.GetType().GetProperty("File", BindingFlags.Public | BindingFlags.Instance);
                if (null != properties && properties.CanWrite)
                {
                    properties.SetValue(modelInstance, file);
                }
             
        
                MethodInfo method = modelInstance.GetType().GetMethod("Convert");


                //object[] parametersArray = new object[] { "Hello" };
         
                return (HttpResponseMessage)method.Invoke(modelInstance, null);

            }


            return new HttpResponseMessage();

        }







    }
}