﻿using MvcConverters.AbstractRepository;
using MvcConverters.Infrastructure;
using MvcConverters.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcConverters.Controllers
{
    //PLEASE DO NOT DELETE ANY COMMENT....//
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


        /// <summary>
        /// Get the Dashboard
        /// </summary>
        /// <returns></returns>

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

 
        /// <summary>
        /// /Post file and download output
        /// </summary>
        /// <param name="file"></param>
        /// <param name="typeofmodel"></param>
        /// <returns></returns>
        [HttpPost]
        
        public async Task<ActionResult> Dashboard(HttpPostedFileBase file,string typeofmodel)
        {
          
            //Fetching assembly
            Type model = Type.GetType($"{Assembly.GetExecutingAssembly().GetName().Name}.ConvertersTypes.{typeofmodel}");
            if (model!=null)
            {
              //Initializing assembly
                object modelInstance = Activator.CreateInstance(model);
                //Reading properties
                PropertyInfo properties = modelInstance.GetType().GetProperty("File", BindingFlags.Public | BindingFlags.Instance);
                if (null != properties && properties.CanWrite)
                {
                    properties.SetValue(modelInstance, file);
                }
             
                 //Calling method of assembly
                 MethodInfo method = modelInstance.GetType().GetMethod("Convert");

                //object[] parametersArray = new object[] { "Hello" };

                byte[] ObjectToByteArray(object obj)
                {
                    if (obj == null)
                        return null;
                    BinaryFormatter bf = new BinaryFormatter();
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bf.Serialize(ms, obj);
                        return ms.ToArray();
                    }
                }
                string ContentType =  modelInstance.GetType().GetProperty("ContentType").GetValue(modelInstance, null).ToString();
                FileContentResult filecontent = new FileContentResult( ObjectToByteArray( method.Invoke(modelInstance, null)), ContentType);
                Session["Downloads"] = filecontent;
                TempData["file"] = "true";
                return PartialView("Htmltopdf");


            }

            TempData["Error"] = "No File Found";
            return PartialView("Htmltopdf");

        }

        /// <summary>
        /// this method always call to download file
        /// </summary>
        /// <returns></returns>
        public ActionResult downloadfile()
        {
            if (Session["download"] != null)
            {
                var file = (FileContentResult)Session["Downloads"];
                return file;
            }
            return null;


        }

        public ActionResult HtmltoPdf()
        {

            return PartialView();
        }




    }
}