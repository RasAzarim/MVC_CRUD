﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
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
        public ActionResult Editar(int Id)
        {
            GenteviewModel model = new GenteviewModel();
            using (CRUDEntities4 db = new CRUDEntities4())
            {
                var Gente = db.Gente.Find(Id);
                model.Nombre = Gente.Nombre;
                model.Correo = Gente.Correo;
                model.Fecha_Nacimiento = Gente.FechaNacimeiento;
                model.Id = Gente.ID;

            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(GenteviewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CRUDEntities4 db = new CRUDEntities4())
                    {
                        var Gente = db.Gente.Find(model.Id);

                        Gente.Correo = model.Correo;
                        Gente.FechaNacimeiento = model.Fecha_Nacimiento;
                        Gente.Nombre = model.Nombre;

                        db.Entry(Gente).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("/Gente");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpGet]
        public ActionResult eliminar( int Id)
        {
            using (CRUDEntities4 db = new CRUDEntities4())
            {
                var otabla = db.Gente.Find(Id);
                db.Gente.Remove(otabla);
                db.SaveChanges();
            }
            return Redirect("/Gente");
        }
    }
}