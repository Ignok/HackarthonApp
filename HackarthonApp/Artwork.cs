using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackarthonApp
{
    internal class Artwork
    {
        public string Id { get; set; }
        public Attributes Attributes { get; set; }
    }
    public class Attributes
    {
        public string Date { get; set; }
        public string PlainDescription { get; set; }
    }
}
