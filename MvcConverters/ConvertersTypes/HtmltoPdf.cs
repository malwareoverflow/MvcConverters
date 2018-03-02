using MvcConverters.AbstractRepository;
using MvcConverters.AbstractClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NReco.PdfGenerator;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MvcConverters.ConvertersTypes
{
    public class HtmltoPdf:ConvertMe
    {

        [Required, FileExtensions(Extensions = ".html", ErrorMessage = "Incorrect file format")]
        public HttpPostedFileBase File { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }

        public string ContentType { get; set; } = "application/pdf";

        public override MemoryStream Convert()
        {
            // htmltopdf convertion here
            var htmlToPdf = new HtmlToPdfConverter();

            var stream = new MemoryStream();
       
            // processing the stream.
            BinaryReader b = new BinaryReader(File.InputStream);
            byte[] binData = b.ReadBytes(File.ContentLength);

            string html = System.Text.Encoding.UTF8.GetString(binData);
            stream.Write(htmlToPdf.GeneratePdf(html, null), 0, htmlToPdf.GeneratePdf(html, null).Length);
            return stream;
         
        }

       
    }
}


//var result = new HttpResponseMessage(HttpStatusCode.OK)
//{
//    Content = new ByteArrayContent(stream.ToArray())
//};
//result.Content.Headers.ContentDisposition =
//    new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
//    {
//        FileName = "Htmltopdf.pdf"
//    };
//result.Content.Headers.ContentType =
//    new MediaTypeHeaderValue(pdfContentType);

//return result;