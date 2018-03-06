
using MvcConverters.AbstractClasses;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;
using Xceed.Words.NET;

namespace MvcConverters.ConvertersTypes
{
    public class PdftoWord: ConvertMe
    {
        public string Name { get; set; }
        [Required, FileExtensions(Extensions = ".pdf", ErrorMessage = "Incorrect file format")]
        public HttpPostedFileBase File { get; set; }
        public string ContentType { get; set; } = "application/docx";
        public override MemoryStream Convert()
        {

       
          
            string newfilename = DateTime.Now.ToString("yyyyMMdd_hhmmss");

            File.SaveAs(Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/test/"),$"{newfilename}.pdf"));
            string pdfFile = System.Web.HttpContext.Current.Server.MapPath($"~/test/{newfilename}.pdf");
            MemoryStream stream = new MemoryStream();
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            using (FileStream pdfStream = new FileStream(pdfFile, FileMode.Open, FileAccess.Read))
            {

                f.OpenPdf(pdfStream);
                if (f.PageCount > 0)
                {
                 

                    int res = f.ToWord(stream);
                    if (res == 0)
                    {

                        string docxFile = Path.ChangeExtension(pdfFile, ".docx");
                      System.IO.File.WriteAllBytes(docxFile, stream.ToArray());
                        System.Diagnostics.Process.Start(docxFile);
                    }
                }
            }

            using (MemoryStream ms = new MemoryStream())
            using (FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath($"~/test/{newfilename}.docx"), FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[file.Length];
                file.Read(bytes, 0, (int)file.Length);
                ms.Write(bytes, 0, (int)file.Length);
                stream = ms;
                stream.Flush();
                stream.Close();
            }


            return stream;

        }



     
    }
}