using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;

namespace HtmlBotOrnegi
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri url = new Uri("https://kodblogum.com/");
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string html = client.DownloadString(url);

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);

            HtmlNodeCollection titles = document.DocumentNode.SelectNodes("//h3[@class='entry-title td-module-title']");

            foreach (HtmlNode item in titles)
            {
                string baslik = item.InnerText;
                Console.WriteLine(baslik);
            }

            Console.Read();
        }
    }
}
