using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace elvSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            string dirPath = Directory.GetCurrentDirectory();

            TargetsLocator locator = new TargetsLocator(dirPath, new LocatorSettings());
            FileCreator creator = new FileCreator(dirPath, new FileCreatorSettings());

            creator.CreateAFile(locator.GatherTargets());
        }
    }
}
