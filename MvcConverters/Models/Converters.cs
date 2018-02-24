using MvcConverters.AbstractRepository;
using MvcConverters.Converters;
using NReco.PdfGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MvcConverters.Models
{
    public class Converters : IConveters
    {


        public HttpResponseMessage HtmltoPdf(HtmltoPdf model)
        {

            var htmlToPdf = new HtmlToPdfConverter();
            var stream = new MemoryStream();
            var pdfContentType = "application/pdf";
            // processing the stream.

            stream.Write(htmlToPdf.GeneratePdf(new StreamReader(model.Html.InputStream).ReadToEnd(), null), 0, htmlToPdf.GeneratePdf(new StreamReader(model.Html.InputStream).ReadToEnd(), null).Length);

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(stream.ToArray())
            };
            result.Content.Headers.ContentDisposition =
                new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = model.Name
                };
            result.Content.Headers.ContentType =
                new MediaTypeHeaderValue(pdfContentType);

            return result;
        }

        public void PdftoHtml(PdftoHtml model)
        {
          
        }

   

        public void PdftoWord(PdftoWord model)
        {
         
        }

        public void TexttoImage(SteganographyTexttoImage model)
        {
            
        }

        public void WordtoPdf(WordtoPdf model)
        {
     
        }
    }
}