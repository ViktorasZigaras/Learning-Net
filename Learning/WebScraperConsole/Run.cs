using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WebScraperConsole
{
    class Run
    {
        static async Task Main(string[] args)
        {
            string url = "https://www.cvonline.lt/darbo-skelbimai/informacines-technologijos";

            List<string> results = await ParseAsync(url);
            if (results.Count == 0)
            {
                Console.WriteLine("No results found.");
            }
            else
            {
                foreach (var result in results)
                {
                    Console.WriteLine(result);
                }
            }
        }

        static async Task<List<string>> ParseAsync(string url)
        {
            string responseBody = await HttpResponse(url);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(responseBody);
            List<HtmlNode> links = htmlDoc.DocumentNode.Descendants().Where(node => node.HasClass("offer_primary_info")).ToList();
            return links.Select(link => link.FirstChild.FirstChild.InnerHtml).ToList();
        }
        static async Task<string> HttpResponse(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }
            return await response.Content.ReadAsStringAsync();
        }
    }
}
