using MvcConverters.AbstractClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
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
        public string ContentType { get; set; } = "application/html";
        public override MemoryStream Convert()
        {


            string newfilename = DateTime.Now.ToString("yyyyMMdd_hhmmss");

            File.SaveAs(Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/test/"), $"{newfilename}.pdf"));
            string pdfFile = System.Web.HttpContext.Current.Server.MapPath($"~/test/{newfilename}.pdf");
            MemoryStream stream = new MemoryStream();
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            using (FileStream pdfStream = new FileStream(pdfFile, FileMode.Open, FileAccess.Read))
            {

                f.OpenPdf(pdfStream);
                if (f.PageCount > 0)
                {
                    int result = f.ToHtml(System.Web.HttpContext.Current.Server.MapPath($"~/test/{newfilename}.html"));

                    //Show Word document
                    if (result == 0)
                    {
                        string htmlFile = Path.ChangeExtension(pdfFile, ".html");
                        System.IO.File.WriteAllBytes(htmlFile, stream.ToArray());
                        System.Diagnostics.Process.Start(htmlFile);
                    }
                }
            }
          

           
            //convert to html
            return null;
        }
    }
}