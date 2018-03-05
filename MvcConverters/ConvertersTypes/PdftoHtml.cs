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

            string pathToPdf = @"d:\simple text.pdf";
            string pathToWord = @"d:\result.doc";

            //Convert PDF file to Word file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            f.OpenPdf(File.FileName);

            if (f.PageCount > 0)
            {
                int result = f.ToWord(pathToWord);

                //Show Word document
                if (result == 0)
                {
                    System.Diagnostics.Process.Start(pathToWord);
                }
            }
            //convert to html
            return null;
        }
    }
}