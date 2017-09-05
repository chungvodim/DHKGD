using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tearc.Repository
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class NonUnicodeAttribute : Attribute
    {
    }
}
