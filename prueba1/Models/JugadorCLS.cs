using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prueba1.Models
{
    public class JugadorCLS : Controller
    {
        [Display(Name = "ID")]
        public int id { get; set; }
        [Display(Name = "APELLIDO")]
        public String apellido { get; set; }
        [Display(Name = "NOMBRE")]
        public String nombre { get; set; }
              
    }
}