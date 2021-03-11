using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class RegUserModel
    {
        public int usr_id { get; set; }
        [Required(ErrorMessage ="Este campo es requerido")]
        public string usr_nom { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string email { get; set; }
        public int priv { get; set; }
        public bool activo { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [DataType(DataType.Password)]
        [DisplayName("Confirmar Contraseña")]
        [Compare("password")]
        public string Confirmpassword { get; set; }
    }
}