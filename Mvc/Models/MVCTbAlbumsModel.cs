using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class MVCTbAlbumsModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string artis { get; set; }
        public string label { get; set; }
        public System.DateTime released { get; set; }
        public double price { get; set; }
        public string category { get; set; }
    }
}