using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace Ylvis.DataManipulation.Compression.Compressors
{
    public class SharpZipLib
    {
        public static void ZipFiles(string archivePath, params string[] targetFilesPath)
        {
            using (ZipOutputStream s = new ZipOutputStream(File.Create(archivePath)))
            {

                s.SetLevel(9); // 0 - store only to 9 - means best compression

                byte[] buffer = new byte[64 * 1024];

                foreach (string file in targetFilesPath)
                {

                    // Using GetFileName makes the result compatible with XP
                    // as the resulting path is not absolute.
                    ZipEntry entry = new ZipEntry(System.IO.Path.GetFileName(file));

                    // Setup the entry data as required.

                    // Crc and size are handled by the library for seakable streams
                    // so no need to do them here.

                    // Could also use the last write time or similar for the file.
                    entry.DateTime = DateTime.Now;
                    s.PutNextEntry(entry);

                    using (FileStream fs = File.OpenRead(file))
                    {

                        // Using a fixed size buffer here makes no noticeable difference for output
                        // but keeps a lid on memory usage.
                        int sourceBytes;
                        do
                        {
                            sourceBytes = fs.Read(buffer, 0, buffer.Length);
                            s.Write(buffer, 0, sourceBytes);
                        } while (sourceBytes > 0);
                    }
                }

                // Finish/Close arent needed strictly as the using statement does this automatically

                // Finish is important to ensure trailing information for a Zip file is appended.  Without this
                // the created file would be invalid.
                s.Finish();

                // Close is important to wrap things up and unlock the file.
                s.Close();
            }
        }
    }
}
