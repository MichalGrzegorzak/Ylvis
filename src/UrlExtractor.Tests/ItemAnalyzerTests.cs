using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UrlExtractor.Model;

namespace UrlExtractor.Tests
{
    [TestFixture]
    public class ItemAnalyzerTests
    {
        [Test]
        public void t01()
        {
            string input = @"
            Last update: 12.11.2018
            Preview: Image

                Backup Preview: http://tlba5.com/?img=351.jpg

            Part 1: https://minil.org/veD20/usn.rar

            Part 2: http://dlfree.fr/mrO3

            Backup Link: http://upile.mobi/toi8C

            Link: http://addile.org/3pSX

            Link: http://qtile.com/lOev

            Link: http://files.co/KHr

            Password: =§$$Z /%)(ßihs
            ";

            ItemAnalyzer analyzer = new ItemAnalyzer(input);
            analyzer.AnalyzeByLine();
            //analyzer.Analyze();

            Console.WriteLine(String.Join("\r\n", analyzer.FilteredOutput.ToArray()) );
            Assert.That(analyzer.HasPass, Is.EqualTo(true));
            Assert.That(analyzer.Parts.Count, Is.EqualTo(2));
            Assert.That(analyzer.Previews.Count, Is.EqualTo(1));
            Assert.That(analyzer.Mirrors.Count, Is.EqualTo(4));
            //Assert.That(analyzer.Downloads.Count, Is.EqualTo(4));
        }

        [Test]
        public void t02()
        {
            string input = @"
Part1
https://mifil.org/h8D/How_2_Dan.part1.rar

Part2
http://iigo-up.com/1/download/120.rar

Part3

http://uile.mobi/Q4T4cStnK5K
http://afile.org/zNQFiClC32w


Please say.

DL Key
L@AD2

Passwort
4dZ@HM
            ";

            ItemAnalyzer analyzer = new ItemAnalyzer(input);
            analyzer.AnalyzeByLine();

            Console.WriteLine(String.Join("\r\n", analyzer.FilteredOutput.ToArray()));
            Assert.That(analyzer.HasPass, Is.EqualTo(true));
            Assert.That(analyzer.Passwords.FirstOrDefault(), Is.EqualTo("4dZ@HM"));
            //
            Assert.That(analyzer.Parts.Count, Is.EqualTo(3));
        }

        [Test]
        public void t03()
        {
            string input = @"
will someone have it?
I did not see where to upload the images so I leave 
live image preview
http://upfile.mobi/cpTlZe
-- backup image preview
http://addfile.org/Rgretret
-- name of file archive
234trg

-- link to file archive
http://upfile.mobi/O7S2gvdfgfdg

--password
@qw12e345rtgr
";

            ItemAnalyzer analyzer = new ItemAnalyzer(input);
            analyzer.Analyze();

            Console.WriteLine(String.Join("\r\n", analyzer.FilteredOutput.ToArray()));
            Assert.That(analyzer.HasPass, Is.EqualTo(true));
            Assert.That(analyzer.Passwords.FirstOrDefault(), Is.EqualTo("@qw12e345rtgr"));
            //
            //Assert.That(analyzer.HasPreview, Is.EqualTo(true));
            //
            Assert.That(analyzer.Downloads.Count, Is.EqualTo(1));
            Assert.That(analyzer.Previews.Count, Is.EqualTo(2));
        }

        [Test]
        public void t04()
        {
            string input = @"
Part1
https://mfil.org/hD/Hown.part1.rar

Part2
http://icho-up.com/1/download/20.rar

will someone?
live image preview
http://upile.moi/clZe
";

            ItemAnalyzer analyzer = new ItemAnalyzer(input);
            analyzer.AnalyzeByLine();

            Console.WriteLine(String.Join("\r\n", analyzer.FilteredOutput.ToArray()));
            Assert.That(analyzer.Parts.Count, Is.EqualTo(2));
        }
    }
}
