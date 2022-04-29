using prueba1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace prueba1.Controllers
{
    public class AccountController : Controller
    {
        private pIIWebEntities db = new pIIWebEntities();

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /*[HttpPost]
        public ActionResult Verify(AccountCLS acc)
        {
            var usuarioExiste = db.usuario
                        .SqlQuery("select * from dbo.usuario where usuario='"
                        + acc.user + "'and password='" + acc.password + "'");
        }*/
    }
}