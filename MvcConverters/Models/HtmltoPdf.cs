using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MvcConverters.Models
{
    public class HtmltoPdf
    {

        [Required, FileExtensions(Extensions = ".html", ErrorMessage = "Incorrect file format")]
        public HttpPostedFileBase Html { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}