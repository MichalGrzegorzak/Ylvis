using System.IO;

namespace Ylvis.Utils.Helpers
{
    public abstract class FileHlp
    {
        public static bool IsFileLocked(string fullPath)
        {
            FileInfo fInfo = new FileInfo(fullPath);

            FileStream stream = null;
            try
            {
                stream = fInfo.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }
    }
}
