﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UrlExtractor.Model;

namespace UrlExtractor.Tests
{
    [TestFixture]
    public class GroupingLinksTests
    {
        [Test]
        public void t01()
        {
            string input = @"
            Last update: 12.11.2018
            Preview: Image

                Backup Preview: http://twlba5.com/?img=351.jpg

            Part 1: https://minfil.org/veD20/usn.rar

            Part 2: http://dl.free.fr/mrO3

            Backup Link: http://upfile.mobi/toi8C

            Link: http://addfile.org/3pSX

            Link: http://qtfile.com/lOev

            Link: http://9files.co/KHr

            Password: =)(§$$Z /%)(ßihs
            ";

            ItemAnalyzer analyzer = new ItemAnalyzer(input);
            analyzer.Analyze();

            Console.WriteLine(String.Join("\r\n", analyzer.FilteredOutput.ToArray()) );
            Assert.That(analyzer.HasPass, Is.EqualTo(true));
            Assert.That(analyzer.Parts.Count, Is.EqualTo(2));
            Assert.That(analyzer.Downloads.Count, Is.EqualTo(4));
        }

        [Test]
        public void t02()
        {
            string input = @"
Part1
https://minfil.org/h8D/How_2_Dan.part1.rar

Part2
http://ichigo-up.com/1/download/1520.rar

Part3

http://upfile.mobi/Q4T4cStnK5K
http://addfile.org/zNQFiClC32w


Please say thank you if you enjoy my post.

DL Key
L@AD2

Passwort
4$F%R13NdZ@HM
            ";

            ItemAnalyzer analyzer = new ItemAnalyzer(input);
            analyzer.Analyze();

            Console.WriteLine(String.Join("\r\n", analyzer.FilteredOutput.ToArray()));
            Assert.That(analyzer.HasPass, Is.EqualTo(true));
            Assert.That(analyzer.Passwords.FirstOrDefault(), Is.EqualTo("4$F%R13NdZ@HM"));
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
    }
}