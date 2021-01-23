using Octokit;
using System;
using System.IO;
using System.Net;

namespace NR_Map_Downloader
{
    class Program
    {
        static void Main(string[] args)
        {

            var client = new GitHubClient(new ProductHeaderValue("MyAmazingApp"));
            var downloader = new WebClient();


            var releases = client.Repository.Release.GetAll("New-Republic-Clan", "MBII-Custom-Events").Result;

            var latest = releases[0];

            foreach( ReleaseAsset asset in latest.Assets)
            {


                Console.WriteLine("Downloading: " + Path.GetFileName(asset.BrowserDownloadUrl));

                if (File.Exists(Path.GetFileName(asset.BrowserDownloadUrl)))
                {
                    File.Delete(Path.GetFileName(asset.BrowserDownloadUrl));
                }

                downloader.DownloadFile(asset.BrowserDownloadUrl, Path.GetFileName(asset.BrowserDownloadUrl));

                Console.WriteLine("Done");

            }



        }
    }
}
