using MvcConverters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MvcConverters.AbstractRepository
{
    interface IConveters
    {

        HttpResponseMessage HtmltoPdf(HtmltoPdf model);
        
        void PdftoWord(PdftoWord model);
        void PdftoHtml(PdftoHtml model);
        void WordtoPdf(WordtoPdf model);
        void TexttoImage(SteganographyTexttoImage model);

    }
}
