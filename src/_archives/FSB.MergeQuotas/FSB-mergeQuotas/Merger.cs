using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FSB_mergeQuotas
{
    public class Merger
    {
        public const string fromDir = "Data_ORG";
        public const string targetDir = "Data_NEW";
        
        public string lookForDate = "10/06/11"; //check the last date in old file
        private string outputDir = string.Empty;

        public Merger(string currDir, string lookForDate = "10/06/11")
        {
            outputDir = currDir;
            this.lookForDate = lookForDate;
        }

        public void Execute()
        {
            Console.WriteLine("Merging from date -> " + lookForDate);

            var filesList = Directory.GetFiles(outputDir + "//" + targetDir);
            foreach (string file in filesList)
            {
                string fileName = new FileInfo(file).Name;
                Console.WriteLine("Processed file: " + fileName);

                var orgContent = GetOrginalFileContent(file);
                var newContent = GetAdjustedNewFileContent(file, lookForDate);
                if(newContent.Count() == 0)
                    newContent = GetAdjustedNewFileContent(file, ""); //read full file

                Console.WriteLine("Lines org: " + orgContent.Count() + " lines new: " + newContent.Count());
                string outPath = outputDir + "//" + fileName;
                MakeNewFile(outPath, orgContent, newContent);
            }
        }

        public string[] GetOrginalFileContent(string newFilePath)
        {
            FileInfo f = new FileInfo(newFilePath);
            string name = f.Name;
            string fullPAth = fromDir + "//" + name;

            string[] preResults = null;
            List<string> results = new List<string>();

            if (File.Exists(fullPAth))
            {
                preResults = File.ReadAllLines(fullPAth);
                foreach (string s in preResults)
                {
                    results.Add(AdjustDate(s));
                }
            }
            return results.ToArray();
        }

        public string[] GetAdjustedNewFileContent(string newFilePath, string fromDate)
        {
            List<string> content = new List<string>();
            FileInfo f = new FileInfo(newFilePath);
            if (!f.Exists)
                return null;

            bool foundDate = false;
            if (fromDate == string.Empty) //disable if empty
            {
                foundDate = true;
                fromDate = "<DISABLE>";
            }

            foreach (string line in File.ReadAllLines(newFilePath))
            {
                if(line.Length == 0) 
                    continue;

                string s = AdjustDate(line);
                if (s.Contains(fromDate)) //skip date
                {
                    foundDate = true;
                    continue;
                }

                if (foundDate) //will add only from next day
                    content.Add(s);
            }


            return content.ToArray();
        }

        public void MakeNewFile(string fullPathFilefileName, string[] oldFileContent, string[] newContent)
        {
            using (var sw = File.CreateText(fullPathFilefileName))
            {
                foreach (string oldLine in oldFileContent)
                {
                    sw.WriteLine(oldLine);
                }

                foreach (string newLine in newContent)
                {
                    sw.WriteLine(newLine);
                }

                sw.Flush();
                sw.Close();
            }

        }

        //should be:
        //03/04/01	20:00	1.43280	1.43430	1.43210	1.43310	936
        //04/04/01	00:00	1.43270	1.43430	1.43210	1.43330	651
        //is:
        //2011-01-02	20:00	1.55118	1.55838	1.55118	1.55694	3845
        public string AdjustDate(string line)
        {
            if (line.Contains("-"))
            {
                string restOfLine = line.Substring(10);
                string yy = line.Substring(2, 2);
                string mm = line.Substring(5, 2);
                string dd = line.Substring(8, 2);
                line = String.Format("{0}/{1}/{2}", dd, mm, yy) + restOfLine;
            }
            return line;
        }
    }
}
