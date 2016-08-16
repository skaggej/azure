using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using System.Xml;

namespace rssjob
{
    class Program
    {
        static void Main()
        {
            //var xmlReader = XmlReader.Create("https://mva.microsoft.com/RSS.aspx?type=liveevents&culture=en-US");
            var xmlReader = XmlReader.Create("https://mva.microsoft.com/RSS.aspx?type=recordedevents&culture=en-US");
            var feed = System.ServiceModel.Syndication.SyndicationFeed.Load(xmlReader);
            foreach(var item in feed.Items)
            {
                Console.WriteLine("[{0}]\t{1}", item.Id,item.Title.Text);
            }
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
