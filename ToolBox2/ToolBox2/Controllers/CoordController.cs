using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolBox2.Class;
using ToolBox2.Models;

namespace ToolBox2.Controllers
{
    public class CoordController : Controller
    {
        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        { 
            return new JsonResult() 
        { 
                Data = data,
                ContentType = contentType, 
                ContentEncoding = contentEncoding, 
                JsonRequestBehavior = behavior,
                MaxJsonLength = Int32.MaxValue 
            }; 
        }

        ToolBoxEntities ctx = new ToolBoxEntities();
        // GET: Coord
        public ActionResult COInicio()
        {
            return View();
        }
        public ActionResult Herramientas()
        {
            return View();
        }
        public ActionResult CoordEcopetrol()
        {
            return View();
        }
        public ActionResult CoordCompensar()
        {
            return View();
        }
        public ActionResult Equipos()
        {
            return View();
        }
        public ActionResult AgregarHerr()
        {
            if (TempData["Message"] != null)
                ViewBag.Message = TempData["Message"].ToString();
            return View();
        }

        //Lista Herramientas
        public JsonResult GetListHerra()
        {
            var listadoUsuarios = ListaHerra();
            return Json(listadoUsuarios, JsonRequestBehavior.AllowGet);
        }
        public List<Herramienta> ListaHerra()
        {
            try
            {
                var data = ctx.Database.SqlQuery<Herramienta>("SP_ConsultarHerra ").ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Lista Equipos
        public JsonResult GetListEquipo()
        {
            var listadoUsuarios = ListaEquipo();
            return Json(listadoUsuarios, JsonRequestBehavior.AllowGet);
        }
        public List<Equipos> ListaEquipo()
        {
            try
            {
                var data = ctx.Database.SqlQuery<Equipos>("SP_ConsultarEquipos").ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Lista Coordinador Ecopetrol
        public JsonResult GetListCoord()
        {
            var listadoUsuarios = ListaCoord();
            return Json(listadoUsuarios, JsonRequestBehavior.AllowGet);
        }
        public List<Coord> ListaCoord()
        {
            try
            {
                var data = ctx.Database.SqlQuery<Coord>("SP_ConsultarCoord").ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Lista TenicosEcopetrol
        public JsonResult GetListTec()
        {
            var listadoUsuarios = ListaTec();
            return Json(listadoUsuarios, JsonRequestBehavior.AllowGet);
        }
        public List<Tecnico> ListaTec()
        {
            try
            {
                var data = ctx.Database.SqlQuery<Tecnico>("SP_ConsultarTecnico").ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Subir Herramientas
        [HttpPost]
        public ActionResult Save(Archivo model) 
        {
            try
            {
                string RutaSitio = Server.MapPath("~/Datos/");
                model.Link = Path.Combine(RutaSitio + model.Archivo1.FileName);

                var data = ctx.Database.SqlQuery<CRespuestaSQL>("SP_InsertHerra @Nombre, @Descripcion,@N_Archivo, @IdProyecto",
                    new SqlParameter("@Nombre", model.Nombre), new SqlParameter("@Descripcion",model.Descripcion),
                    new SqlParameter("@N_Archivo", model.Archivo1.FileName), new SqlParameter("@IdProyecto",model.IdProyecto)).FirstOrDefault();
                if (!ModelState.IsValid)
                {
                    return View("AgregarHerr", model);
                }
                model.Archivo1.SaveAs(model.Link);
                @TempData["Message"] = "Se cargo el archivo"+data;
                return RedirectToAction("AgregarHerr");
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }
    }
}