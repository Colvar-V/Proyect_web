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
    public class AccesoController : Controller
    {
        ToolBoxEntities ctx = new ToolBoxEntities();
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult PostVerficarUsuario(Tecnico model)
        {
            var responseData = Verificar_usuario(model.Usuario, model.Contrasena);
            return Json(responseData, JsonRequestBehavior.AllowGet);
        }

        public RespuestaSQL Verificar_usuario(string Usuario, string Contrasena)
        {
            try
            {
                var data = ctx.Database.SqlQuery<RespuestaSQL>("SP_VerificarU @Usuario, @Contrasena",
                    new SqlParameter("@Usuario",Usuario),new SqlParameter("@Contrasena",Contrasena)).FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }
    }
}