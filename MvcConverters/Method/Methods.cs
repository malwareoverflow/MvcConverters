using MvcConverters.AbstractRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcConverters.Method
{
    public class Methods : IMethods
    {
        List<dynamic> list = new List<dynamic>();
        public void Addtolist(dynamic Value)
        {
            list.Add(Value);
        }
        public List<dynamic> getList()
        {
            return list;
        }
    }
}