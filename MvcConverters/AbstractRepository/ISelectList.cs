using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcConverters.AbstractRepository
{
    interface ISelectList
    {

        void Addtolist(string Text, string Value);
        IEnumerable<SelectListItem> getList();

    }
}
