using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace MvcConverters.AbstractClasses
{
   public abstract class ConvertMe
    {

        abstract public MemoryStream Convert();
    }
}