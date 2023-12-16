using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroCSharpBackend
{
    public class People
    {
        public string Name { get; set; }
        public int Age { get; set; }

        // static method sample
        public static string Get() => "Hola";
    }
}
