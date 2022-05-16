using prueba1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Mvc;

namespace prueba1.Controllers
{
    public class JugadoresController : Controller
    {

        private pIIWebEntities db = new pIIWebEntities();


        // GET: Jugadores
        public ActionResult Index()
        {
            return View(db.jugador.ToList());
        }
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(usuario user)
        {

            if(ModelState.IsValid)
            {
                using (var db = new pIIWebEntities())
                {
                    var obj = db.usuario.Where(a => a.nombreUsuario.Equals(user.nombreUsuario) && a.passwordUsuario.Equals(user.passwordUsuario)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.idUsuario.ToString();
                        Session["UserName"] = obj.nombreUsuario.ToString();
                        return RedirectToAction("lista_jugadores_db");
                    }
                }
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult lista_jugadores_db()
        {
            return View(db.jugador.ToList());
        }
        

        public ActionResult Agregar_jugador()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar_jugador(JugadorCLS jCLS)
        {
            if (!ModelState.IsValid) 
            {
                return View(jCLS);
            }
            else
            {
                using(var bd = new pIIWebEntities())
                {
                    jugador j = new jugador();
                    j.apellido = jCLS.apellido;
                    j.nombre = jCLS.nombre;
                    bd.jugador.Add(j);
                    bd.SaveChanges();                    
                }
            }
            return RedirectToAction("lista_jugadores_db");
        }

        public ActionResult Detalle_jugador(int? id)
        {
            try
            {
                using (var db = new pIIWebEntities())
                {
                    jugador jugador = db.jugador.Find(id);
                    return View(jugador);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al mostrar detalles del jugador", ex);
                return RedirectToAction("lista_jugadores_db");
            }
        }

        public ActionResult Editar_jugador(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            jugador j = db.jugador.Find(id);
            if(j == null)
            {
                return HttpNotFound();
            }
            return View(j);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar_jugador(jugador j)
        {
            if (ModelState.IsValid)
            {
                db.Entry(j).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("lista_jugadores_db");
            }
            return View(j);
        }

        public ActionResult Borrar_jugador(int? id)
        {
            jugador j = db.jugador.Find(id);
            if (id ==null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            if (j == null)
            {
                return HttpNotFound();
            }            
            db.jugador.Remove(j);
            db.SaveChanges();
            return RedirectToAction("lista_jugadores_db");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Confirmar_borrar_jugador(int id)
        {
            jugador j = db.jugador.Find(id);
            db.jugador.Remove(j);
            db.SaveChanges();
            return RedirectToAction("lista_jugadores_db");
        }

    }
}




/*public ActionResult lista_jugadores_linq()
        {
            List<JugadorCLS> lista = null;
            using (var db = new pIIWebEntities())
            {
                lista = (from jugador in db.jugador
                         select new JugadorCLS
                         {
                             id = jugador.id,
                             apellido = jugador.apellido,
                             nombre = jugador.nombre
                         }).ToList();
            }
            return View(lista);
        }*/

/*public ActionResult obj_jugador() 
{
    JugadorCLS jugador = new JugadorCLS {id = 1, apellido = "Messi", nombre = "Lionel"};
    return View(jugador); 
}

public ActionResult lista_jugadores()
{
    JugadorCLS j = new JugadorCLS { id = 1, apellido = "Di Maria", nombre = "Angel" };
    JugadorCLS j2 = new JugadorCLS { id = 1, apellido = "Romero", nombre = "Cuti" };
    JugadorCLS j3 = new JugadorCLS { id = 1, apellido = "Martinez", nombre = "Dibu" };

    List<JugadorCLS> lista = new List<JugadorCLS>();
    lista.Add(j);
    lista.Add(j2);
    lista.Add(j3);
    return View(lista);
}*/

/*public ActionResult Agregar_jugador()
{
    return View();
}
[HttpPost]
[ValidateAntiForgeryToken]  
public ActionResult Agregar_jugador(jugador j) 
{
    if (!ModelState.IsValid)
        return View();

    try
    {
        db.jugador.Add(j);
        db.SaveChanges();
        return RedirectToAction("lista_jugadores");
    }
    catch (Exception)
    {
        throw;
    }

}*/