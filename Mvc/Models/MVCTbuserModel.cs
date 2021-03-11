using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class MVCTbuserModel
    {
        public int usr_id { get; set; }
        [Required(ErrorMessage ="Este campo es necesasio")]
        public string usr_nom { get; set; }
        public string email { get; set; }
        public int priv { get; set; }
        public bool activo { get; set; }
        public string password { get; set; }
    }
}