using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcConverters.Converters
{
    public class HtmltoPdf
    {

        [Required, FileExtensions(Extensions = ".html", ErrorMessage = "Incorrect file format")]
        public HttpPostedFileBase Html { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}