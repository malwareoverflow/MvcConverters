using MvcConverters.AbstractClasses;
using NReco.PdfGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using WordToPDF;

namespace MvcConverters.ConvertersTypes
{
    public class WordtoPdf:ConvertMe
    {
        public string Name { get; set; }
        [Required, FileExtensions(Extensions = ".docx,.docm,.dotx", ErrorMessage = "Incorrect file format")]
        public HttpPostedFileBase File { get; set; }
        public string ContentType { get; set; } = "application/pdf";
        public override MemoryStream Convert()
        {
            Word2Pdf objWorPdf = new Word2Pdf();
            MemoryStream stream = new MemoryStream();
            string newfilename = DateTime.Now.ToString("yyyyMMdd_hhmmss");

            File.SaveAs(Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/test/"), $"{newfilename}{Path.GetExtension(File.FileName)}"));
            string pdfFile = System.Web.HttpContext.Current.Server.MapPath($"~/test/{newfilename}.pdf");
            string testfolder = System.Web.HttpContext.Current.Server.MapPath($"~/test");
            string strFileName = $"{newfilename}.docx";
            object FromLocation = testfolder + "\\" + strFileName;
            string FileExtension = Path.GetExtension(strFileName);
            string ChangeExtension = strFileName.Replace(FileExtension, ".pdf");
            if (FileExtension == ".doc" || FileExtension == ".docx")
            {
                object ToLocation = testfolder + "\\" + ChangeExtension;
                objWorPdf.InputLocation = FromLocation;
                objWorPdf.OutputLocation = ToLocation;
                objWorPdf.Word2PdfCOnversion();
                stream.Write(System.IO.File.ReadAllBytes(ToLocation.ToString()), 0, System.IO.File.ReadAllBytes(ToLocation.ToString()).Length);
                stream.Flush();
                stream.Close();
            }
            return stream;
        
        }
    }
}