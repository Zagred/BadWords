using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadWords
{
    internal class Program:CheckComments
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\PlamenPandev\Desktop\BadWords\BadWords";
            List<string> comments = new List<string>()
            {
                "everything is fine",
                "руски комент гандон ",
                "buceta",
                "нещо си pillu",
                "ich bin neshto si"
            };
            CheckComments.test(path, comments);
        }
    }
}
