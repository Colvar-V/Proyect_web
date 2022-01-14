using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolBox2.Class;
using ToolBox2.Models;

namespace ToolBox2.Controllers
{
    public class TecnicoController : Controller
    {
        ToolBoxEntities ctx = new ToolBoxEntities();
        // GET: Tecnico
        public ActionResult TCInicio()
        {
            return View();
        }
        public ActionResult TCEcopetrol()
        {
            return View();
        }
        public ActionResult TCCompensar()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public JsonResult PostInsertError(Error model)
        {
            var responseData = Insert_Error(model.Nombre, model.Descripcion, model.Solucion, model.IdModelo);
            return Json(responseData, JsonRequestBehavior.AllowGet);
        }
        public ERespuesta Insert_Error(string Nombre, string Descripcion, string Solucion, int IdModelo)
        {
            try
            {
                var data = ctx.Database.SqlQuery<ERespuesta>("SP_InsertError @Nombre, @Descripcion, @Solucion, @IdModelo",
                    new SqlParameter("@Nombre", Nombre), new SqlParameter("@Descripcion", Descripcion),
                    new SqlParameter("@Solucion", Solucion), new SqlParameter("@IdModelo", IdModelo)).FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }
        public JsonResult GetListError()
        {
            var listadoUsuarios = ListaError();
            return Json(listadoUsuarios, JsonRequestBehavior.AllowGet);
        }
        public List<Error> ListaError()
        {
            try
            {
                var data = ctx.Database.SqlQuery<Error>("SP_ConsultarError ").ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}