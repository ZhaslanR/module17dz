using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module17dz
{
    public class Item
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public DateTime PubDate { get; set; }
        public void Save()
        {
            using (StreamWriter writer = new StreamWriter("file.txt", true))
            {
                writer.WriteLine(Title);
                writer.WriteLine(Link);
                writer.WriteLine(Description);
                writer.WriteLine(PubDate);
            }
        }
    }
}
