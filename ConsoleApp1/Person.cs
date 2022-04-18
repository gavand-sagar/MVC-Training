using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Person
    {
        public string Name { get; set; }
    }

    public static class Container
    {
        public static Person person { get; set; }
    }
}
