using MvcConverters.AbstractClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcConverters.ConvertersTypes
{
    public class PdftoWord: ConvertMe
    {
        public string Name { get; set; }
        [Required, FileExtensions(Extensions = ".pdf", ErrorMessage = "Incorrect file format")]
        public HttpPostedFileBase File { get; set; }

        public override void Convert()
        {
         // pdftoword convertion here
        }
    }
}