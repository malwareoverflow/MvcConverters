using MvcConverters.AbstractClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace MvcConverters.ConvertersTypes
{
    public class WordtoPdf:ConvertMe
    {
        public string Name { get; set; }
        [Required, FileExtensions(Extensions = ".docx,.docm,.dotx", ErrorMessage = "Incorrect file format")]
        public HttpPostedFileBase File { get; set; }
        public string ContentType { get; set; } = "application/pdf";
        public override HttpResponseMessage Convert()
        {
            //convert word to pdf here
            return null;
        }
    }
}