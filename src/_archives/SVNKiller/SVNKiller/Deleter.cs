using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SVNKiller
{
    public class Deleter
    {
        private string _rootPath = "";

        public Deleter(string rootPath)
        {
            _rootPath = rootPath;
        }

        public string CleanAll()
        {
            string result = "ALL DONE!";
            
            try
            {
                RemoveReadOnlyAtribFromFilesInDir();

                DeleteAllFoldersNamedAs("obj");
                DeleteAllFoldersNamedAs("bin");
                DeleteAllFoldersNamedAs(".svn");
                DeleteAllFoldersNamedAs("_ReSharper*");
                DeleteAllFoldersNamedAs("_UpgradeReport*");

                RemoveFilesNammedAs(_rootPath, @"UpgradeLog.xml");
                RemoveFilesNammedAs(_rootPath, @"*.iloprj");
            }
            catch (Exception ex)
            {
                result = "Error3. " + ex.Message;
            }

            return result;
        }
        
        private void RemoveReadOnlyAtribFromFilesInDir()
        {
            DirectoryInfo dir = new DirectoryInfo(_rootPath);
            FileInfo[] filesInfo = dir.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (FileInfo fInf in filesInfo)
            {
                if (fInf.IsReadOnly)
                    File.SetAttributes(fInf.FullName, FileAttributes.Normal);
            }
        }

        private void DeleteAllFoldersNamedAs(string pattern)
        {
            string[] dirs = Directory.GetDirectories(_rootPath, pattern, SearchOption.AllDirectories);
            foreach (string path in dirs)
            {
                RemoveFilesNammedAs(path, "*.*"); //all files
                Directory.Delete(path, true);
            }
        }

        private void RemoveFilesNammedAs(string path, string pattern)
        {
            string[] files = Directory.GetFiles(path, pattern, SearchOption.AllDirectories);
            foreach (string p in files)
                File.Delete(p);
        }

        

    }
}
