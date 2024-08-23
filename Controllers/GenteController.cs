using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MVC_CRUD.Models;
using MVC_CRUD.Models.ViewModels;

namespace MVC_CRUD.Controllers
{
    public class GenteController : Controller
    {
        // GET: Gente
        public ActionResult Index()
        {
            List<listatablaviewmodel> lst;
            using (CRUDEntities4 db = new CRUDEntities4())
            {
                lst = (from d in db.Gente
                       select new listatablaviewmodel
                       {
                           id = d.ID,
                           Nombre = d.Nombre,
                           Correo = d.Correo
                       }).ToList();
            }
            return View(lst);
        }
        public ActionResult Nuevo() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo (GenteviewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CRUDEntities4 db = new CRUDEntities4 ())
                    {
                        var Gente = new Gente();
                        
                        Gente.Correo = model.Correo;
                        Gente.FechaNacimeiento = model.Fecha_Nacimiento;
                        Gente.Nombre = model.Nombre;
                        
                        db.Gente.Add(Gente);
                        db.SaveChanges();
                    }
                
                   return Redirect("/Gente");
                }
                return View (model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}