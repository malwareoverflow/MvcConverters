using MvcConverters.AbstractClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace MvcConverters.ConvertersTypes
{
    public class PdftoHtml:ConvertMe
    {
        public string Name { get; set; }
        [Required, FileExtensions(Extensions = ".pdf", ErrorMessage = "Incorrect file format")]
        public HttpPostedFileBase File { get; set; }

        public override HttpResponseMessage Convert()
        {
            //convert to html
            return null;
        }
    }
}