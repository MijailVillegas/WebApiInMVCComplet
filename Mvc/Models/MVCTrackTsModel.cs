using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class MVCTrackTsModel
    {
        public int id { get; set; }
        public int album_id { get; set; }
        public string title { get; set; }
        public int track_num { get; set; }
        public int duration { get; set; }
    }
}