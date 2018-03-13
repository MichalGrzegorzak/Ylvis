using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Internal;
using UrlExtractor.Model;

namespace UrlExtractor.Tests
{
    [TestFixture]
    public class LiteDBTests
    {
        [Test]
        public void t01_insert_new_post()
        {
            int count = 0;
            var post = PostFactory.CreatePost(PostFactory.Test1(), "http://test.com/");

            using (var db = new LiteDatabase("test.db"))
            {
                var allPosts = db.GetCollection<ClipboardPost>("posts");
                allPosts.Insert(post);
                count = allPosts.Count();
                foreach (ClipboardPost ps in allPosts.FindAll())
                {
                    Console.WriteLine(PrintPost(ps));
                }
                //var postFromDb = allPosts.FindAll().FirstOrDefault();
                //int id = postFromDb.Id;
            }
            Assert.That(count, Is.GreaterThan(0));
        }

        [Test]
        public void t02_post_find_by_ID()
        {
            ClipboardPost post;
            using (var db = new LiteDatabase("test.db"))
            {
                var allPosts = db.GetCollection<ClipboardPost>("posts");
                post = allPosts.FindOne(x => x.Id == 1);
                Console.WriteLine(PrintPost(post));
            }
            Assert.That(post.Id, Is.EqualTo(1));
        }

        [Test]
        public void t03_post_find_by_name()
        {
            ClipboardPost post;
            using (var db = new LiteDatabase("test.db"))
            {
                var allPosts = db.GetCollection<ClipboardPost>("posts");
                post = allPosts.FindOne(x => x.Pass == "=)(§$$Z /%)(ßihs");
                Console.WriteLine(PrintPost(post));
            }
            Assert.That(post, Is.Not.Null);
        }

        private string PrintPost(ClipboardPost ps)
        {
            //string psString = JsonConvert.SerializeObject(ps);
            string psString = $"ID:{ps.Id}, Len:{ps.RawText.Length}, Count:{ps.Downloads.Count}, Pass:{ps.Pass}";
            return psString;
        }
    }
}
