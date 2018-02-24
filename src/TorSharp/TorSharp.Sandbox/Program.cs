using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Knapcode.TorSharp.Sandbox
{
    internal class Program
    {
        private static void Main()
        {
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task<TorSharpSettings> PrepareEnvironment()
        {
            // configure
            var settings = new TorSharpSettings
            {
                ZippedToolsDirectory = Path.Combine(Path.GetTempPath(), "TorZipped"),
                ExtractedToolsDirectory = Path.Combine(Path.GetTempPath(), "TorExtracted"),
                PrivoxyPort = 1337,
                TorSocksPort = 1338,
                TorControlPort = 1339,
                TorControlPassword = "foobar222",
                ToolRunnerType = ToolRunnerType.VirtualDesktop
            };

            // download tools
            await new TorSharpToolFetcher(settings, new HttpClient()).FetchAsync();
            return settings;
        }

        private static HttpClient CreateHttpClient(TorSharpSettings settings, out TorSharpProxy torProxy)
        {
            torProxy = new TorSharpProxy(settings);
            var handler = new HttpClientHandler
            {
                Proxy = new WebProxy(new Uri("http://localhost:" + settings.PrivoxyPort)),
                AllowAutoRedirect = true,
                UseCookies = true,
                CookieContainer = new CookieContainer()
            };

            var httpClient = new HttpClient(handler);
            httpClient.Timeout = TimeSpan.FromMinutes(10);

            torProxy.ConfigureAndStartAsync().Wait();

            return httpClient;
        }

        private static void VerifyProxy(HttpClient httpClient, TorSharpProxy torProxy)
        {
            string s1 = httpClient.GetStringAsync("http://api.ipify.org").Result;
            Console.WriteLine(s1);

            var task1 =  torProxy.GetNewIdentityAsync();
            task1.Wait();

            string s2 = httpClient.GetStringAsync("http://api.ipify.org").Result;
            Console.WriteLine(s2);

            bool isOk = !(s1 == s2);
            if(!isOk)
                throw new Exception("Proxy returned same IP - something wrong!");
            //await torProxy.GetNewIdentityAsync();
            //Console.WriteLine(await httpClient.GetStringAsync("http://api.ipify.org"));
        }

        private static async Task DownloadFileFrom_Dl_free_fr(HttpClient httpClient, string target, string saveFileName)
        {
            string html = await httpClient.GetStringAsync(target); //this is require to create cookie
            //html.
            //fileName is inside span id= 'coin2'

            var frmContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("file", "/0qOqSID5")
            });

            //get content
            var result = await httpClient.PostAsync("http://dl.free.fr/getfile.pl", frmContent);

            //save content
            string pathname = Path.GetFullPath(saveFileName);
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(pathname, FileMode.Create, FileAccess.Write, FileShare.None);
                await result.Content.CopyToAsync(fileStream)
                    .ContinueWith((copyTask) => {
                        fileStream.Close();
                    });
            }
            catch
            {
                fileStream?.Close();
                throw;
            }
        }

        private static async Task MainAsync()
        {
            var settings = await PrepareEnvironment();

            // execute
            var httpClient = CreateHttpClient(settings, out TorSharpProxy torProxy);
            VerifyProxy(httpClient, torProxy);

            //orginal LINK is "http://dl.free.fr/getfile.pl?file=/0qOqSID5"
            await DownloadFileFrom_Dl_free_fr(httpClient, "http://dl.free.fr/getfile.pl/0qOqSID5", "result2.mp4");
            //string file = @"http://www.thinkchiropractic.co.uk/ThinkChiropractic/Gym_Ball_Exercises_files/droppedImage_3.jpg";

            Console.WriteLine("finished downloading");
            torProxy.Stop();
            Console.ReadLine();
        }
    }
}