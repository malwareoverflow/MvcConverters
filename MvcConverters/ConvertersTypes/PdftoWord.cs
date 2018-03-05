
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
            PDDocument doc = null;
            var stream = new MemoryStream();
            var fileName = Path.GetFileName(File.FileName);
            string newfilename = DateTime.Now.ToString("yyyyMMdd_hhmmss");
          
            File.SaveAs(Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/test/"),$"{newfilename}.pdf"));
            doc = PDDocument.load(System.Web.HttpContext.Current.Server.MapPath($"~/test/{newfilename}.pdf"));
            PDFTextStripper textStrip = new PDFTextStripper();
            string PdfText = textStrip.getText(doc);
            doc.close();

            string wordsavePath = System.Web.HttpContext.Current.Server.MapPath($"~/test/{newfilename}.docx");
            var wordDoc = DocX.Create(wordsavePath);
            wordDoc.InsertParagraph(PdfText);
            wordDoc.Save();
            System.Diagnostics.Process.Start("WINWORD.EXE", wordsavePath);
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



        public static byte[] ReadFile(string filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }
    }
}