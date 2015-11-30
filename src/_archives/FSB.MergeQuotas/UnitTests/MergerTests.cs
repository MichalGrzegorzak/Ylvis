using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FSB_mergeQuotas;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class MergetTests
    {
        const string path = "..\\..\\..\\FSB-mergeQuotas\\bin\\Debug";
        string oldFile = Directory.GetFiles(path + "//" + Merger.fromDir)[1];
        string newFile = Directory.GetFiles(path + "//" + Merger.targetDir)[1];
        Merger merger = new Merger(path);

        [Test]
        public void T1_Can_find_directories()
        {
            bool exists = Directory.Exists(path);
            Assert.IsTrue(exists);

            Assert.IsTrue(newFile.Contains("GBPUSD240.csv"));
        }

        [Test]
        public void T2_Can_find_files()
        {
            var files = Directory.GetFiles(path + "//" + Merger.fromDir);
            Assert.IsTrue(files.Count() == 2);

            files = Directory.GetFiles(path + "//" + Merger.targetDir);
            Assert.IsTrue(files.Count() == 2);
        }

        [Test]
        public void T3_Can_read_oginal()
        {
            var content = merger.GetOrginalFileContent(oldFile);
            Assert.IsTrue(content != null);
        }

        [Test]
        public void T4_adjustDate_works()
        {
            string line = "2011-01-07	00:00	1.54488	1.5474	1.54345	1.5447	19136";
            string shouldBe = "07/01/11	00:00	1.54488	1.5474	1.54345	1.5447	19136";
            string result = merger.AdjustDate(line);

            Assert.IsTrue(shouldBe == result);
        }

        [Test]
        public void T5_adjustDate_dont_change_normal_date()
        {
            string line = "07/01/11	00:00	1.54488	1.5474	1.54345	1.5447	19136";
            string shouldBe = "07/01/11	00:00	1.54488	1.5474	1.54345	1.5447	19136";
            string result = merger.AdjustDate(line);

            Assert.IsTrue(shouldBe == result);
        }

        [Test]
        public void T6_reads_newFile_from_date()
        {
            var content = merger.GetAdjustedNewFileContent(newFile, merger.lookForDate);
            Assert.IsTrue(content.Length == 1931);
        }

        [Test]
        public void T7_read_full_file_if_no_matching_date()
        {
            var content = merger.GetAdjustedNewFileContent(newFile, "");
            Assert.IsTrue(content.Length > 100);
        }

        
        
    }
}
