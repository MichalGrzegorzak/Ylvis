using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FSB_mergeQuotas
{
    class Program
    {
        static void Main(string[] args)
        {
            Merger merger = null;
            merger = new Merger(Directory.GetCurrentDirectory());
            
            if(args.Count() == 1)
                merger = new Merger(Directory.GetCurrentDirectory(), args[0]);

            merger.Execute();

            Console.WriteLine("ALL DONE");
            Console.ReadLine();
        }
    }
}
