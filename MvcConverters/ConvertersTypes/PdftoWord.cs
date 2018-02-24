using MvcConverters.Convert;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcConverters.Converters
{
    public class PdftoWord: ConvertMe
    {
        public string Name { get; set; }
        [Required, FileExtensions(Extensions = ".pdf", ErrorMessage = "Incorrect file format")]
        public HttpPostedFileBase Pdf { get; set; }

        public override void Convert()
        {
         // pdftoword convertion here
        }
    }
}