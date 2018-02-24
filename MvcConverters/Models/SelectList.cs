using MvcConverters.AbstractRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MvcConverters.Models
{
    public class SelectList : ISelectList
    {


        List<SelectListItem> listitems = new List<SelectListItem>();

        public void Addtolist(string Text, string Value)
        {

            listitems.Add(new SelectListItem { Text = Text, Value = Value});
        }

        public IEnumerable<SelectListItem> getList()
        {
             return listitems;
        }
    }
}