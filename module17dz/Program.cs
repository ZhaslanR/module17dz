using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace module17dz
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>();
            XmlDocument xmlDocument = new XmlDocument();

            const string path = @"https://habrahabr.ru/rss/interesting/";
            xmlDocument.Load(path);
            XmlNode root = xmlDocument.LastChild.LastChild;
            foreach (XmlNode node in root)
            {
                if (node.Name == "item")
                {
                    Item item = new Item();

                    var nodes = node.ChildNodes;
                    foreach (XmlNode childNode in nodes)
                    {
                        if (childNode.Name == "title") item.Title = childNode.InnerText;
                        else if (childNode.Name == "link") item.Link = childNode.InnerText;
                        else if (childNode.Name == "desription") item.Description = childNode.InnerText;
                        else if (childNode.Name == "pubDate") item.PubDate = DateTime.Parse(childNode.InnerText);
                    }
                    items.Add(item);
                }
            }

            for (int i = 0; i < items.Count; i++) items[i].Save();

            Console.ReadLine();
        }
    }
}
