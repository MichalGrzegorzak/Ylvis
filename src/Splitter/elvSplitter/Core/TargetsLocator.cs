using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace elvSplitter
{
    public class TargetsLocator
    {
        private readonly string dirPath;
        private LocatorSettings settings;
        public TargetsLocator(string dirPath, LocatorSettings settings)
        {
            this.dirPath = dirPath;
            this.settings = settings;
        }

        public List<TargetInfo> GatherTargets()
        {
            var dirInfo = new DirectoryInfo(dirPath);

            List<TargetInfo> allTargets = dirInfo.GetDirectories()
                                                 .Select(dirSize => new { dirSize.Name, Size = 
                                                        dirSize.GetFiles("*", SearchOption.AllDirectories)
                                                        .Where(y => !settings.ExcludeExtension.Contains(y.Extension))
                                                        .Sum(y => y.Length), IsDir = true }) //let in method syntax
                                                 .Where(x => x.Size > MB(10))
                                                 .Select(x => new TargetInfo(x.Name, x.Size, x.IsDir))
                                                 .ToList();

            allTargets.AddRange(
                dirInfo.GetFiles("*", SearchOption.TopDirectoryOnly)
                       .Watch()
                       .Where(x => !settings.ExcludeExtension.Contains(x.Extension))
                       .Watch()
                       .Where(x => x.Length > MB(settings.MinFileSize))
                       .Select(x => new TargetInfo(x.Name, x.Length, false, x.Extension))
                );

            return allTargets;
        }

        public static long MB(int input)
        {
            return input * 1024 * 1024;
        }
    }
}