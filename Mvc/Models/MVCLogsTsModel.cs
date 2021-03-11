using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class MVCLogsTsModel
    {
        public int id_log { get; set; }
        public System.DateTime log_date { get; set; }
        public int fkuser_id { get; set; }
    }
}