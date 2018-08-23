using Newtonsoft.Json;
using SwallowCore.Models;
using SwallowCore.Core;
using SwallowCore.Models.QueryExtension;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;



namespace InternalTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start.");

            using (var context = new SwallowContext())
            {
                var t = context.Travel.GetByCurrentUser().FirstOrDefault();
            }

            Console.WriteLine("End.");
            Console.ReadKey();
        }
    }
}
