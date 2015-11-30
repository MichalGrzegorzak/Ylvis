using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace SVNKiller
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute(args);
        }

        //static void Main()
        //{
        //    string[] args = new string[] { @"D:\Downloads\SVNKiller\" };
        //    Execute(args);
        //}

        static void Execute(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Write("Error=1. Musisz przekazac sciezke do katalogu, jako parametr!!!");
                return;
            }

            string path = args[0];
            if (!Directory.Exists(path))
            {
                Console.Write("Error=2. Nie znaleziono podanej scie¿ki!!!");
                return;
            }

            //string orginalPath = path;
            //path = path.Substring(0, path.Length - 1) + "__COPY__";
            //CopyDirectory(orginalPath, path);

            Deleter del = new Deleter(path);
            string result = del.CleanAll();

            //ZipHelper zip = new ZipHelper(path);
            //zip.Pack(@"D:\out.7z");

            Console.Write(result);
        }

        public static void CopyDirectory(string src, string dst)
        {
            String[] files;

            if (dst[dst.Length - 1] != Path.DirectorySeparatorChar)
                dst += Path.DirectorySeparatorChar;
            if (!Directory.Exists(dst))
                Directory.CreateDirectory(dst);

            files = Directory.GetFileSystemEntries(src);
            foreach (string element in files)
            {
                if (Directory.Exists(element))
                {
                    // Sub directories
                    if (element + Path.DirectorySeparatorChar != dst)
                    {
                        CopyDirectory(element, dst + Path.GetFileName(element));
                    }
                }
                else
                {
                    // Files in directory
                    File.Copy(element, dst + Path.GetFileName(element), true);
                }
            }
        }

    }
}
