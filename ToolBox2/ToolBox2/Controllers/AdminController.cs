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
    public class AdminController : Controller
    {
        //conexion de la db
        ToolBoxEntities ctx = new ToolBoxEntities();
        //vistas
        public ActionResult ADInicio()
        {
            return View();
        }
        public ActionResult Usuarios()
        {
            return View();
        }
        public ActionResult CrearUsuario()
        {
            return View();
        }

        public ActionResult EditarUsuarios() 
        {
            return View();
        }
        //Consulta de Tecnicos
        public JsonResult GetListTecnicos()
        {
            var listadoUsuarios = ListaUsuariosT();
            return Json(listadoUsuarios, JsonRequestBehavior.AllowGet);
        }
        public List<Tecnico> ListaUsuariosT()
        {
            try
            {
                var data = ctx.Database.SqlQuery<Tecnico>("SP_ConsultarTecnico ").ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Consulta de Coordinadores
        public JsonResult GetListCoord()
        {
            var listadoUsuarios = ListaUsuariosC();
            return Json(listadoUsuarios, JsonRequestBehavior.AllowGet);
        }
        public List<Coord> ListaUsuariosC()
        {
            try
            {
                var data = ctx.Database.SqlQuery<Coord>("SP_ConsultarCoord ").ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Insertar usuario Tecnicos
        [HttpPost]
        public JsonResult PostInsertTec(Tecnico model) {
            var responseData = Insert_Tec(model.Nombre, model.Cargo, model.Usuario, model.Contrasena, model.Telefono, model.Correo,model.IdProyecto);
            return Json(responseData, JsonRequestBehavior.AllowGet);
        }
        public TRespuestaSQL Insert_Tec(string Nombre, string Cargo, string Usuario, string Contrasena, Nullable<decimal> Telefono, string Correo,int IdProyecto)
        {
            try
            {
                var data = ctx.Database.SqlQuery<TRespuestaSQL>("SP_InsertTec @Nombre, @Cargo, @Usuario, @Contrasena, @Telefono, @Correo, @IdProyecto",
                    new SqlParameter("@Nombre",Nombre), new SqlParameter("@Cargo",Cargo),
                    new SqlParameter("@Usuario", Usuario), new SqlParameter("@Contrasena", Contrasena),
                    new SqlParameter("@Telefono",Telefono), new SqlParameter("@Correo",Correo),
                    new SqlParameter("@IdProyecto", IdProyecto)).FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }
        //Insertar usuario Coordinador
        [HttpPost]
        public JsonResult PostInsertCoord(Coord model)
        {
            var responseData = Insert_Coord(model.Nombre, model.Usuario, model.Contrasena, model.Telefono, model.Correo,model.IdProyecto);
            return Json(responseData, JsonRequestBehavior.AllowGet);
        }
        public CRespuestaSQL Insert_Coord(string Nombre, string Usuario, string Contrasena, Nullable<decimal> Telefono, string Correo,int IdProyecto)
        {
            try
            {
                var data = ctx.Database.SqlQuery<CRespuestaSQL>("SP_InsertCoord @Nombre, @Usuario, @Contrasena, @Telefono, @Correo, @IdProyect",
                    new SqlParameter("@Nombre", Nombre),new SqlParameter("@Usuario", Usuario), new SqlParameter("@Contrasena", Contrasena),
                    new SqlParameter("@Telefono", Telefono), new SqlParameter("@Correo", Correo),new SqlParameter("@IdProyect", IdProyecto)).FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }
        //Editar Tecnico
        [HttpPost]
        public JsonResult PostEditTec(Tecnico model)
        {
            var responseData = Edit_Tec(model.Id,model.Nombre, model.Cargo, model.Usuario, model.Contrasena, model.Telefono, model.Correo, model.IdProyecto);
            return Json(responseData, JsonRequestBehavior.AllowGet);
        }
        public TRespuestaSQL Edit_Tec(int Id,string Nombre, string Cargo, string Usuario, string Contrasena, Nullable<decimal> Telefono, string Correo, int IdProyecto)
        {
            try
            {
                var data = ctx.Database.SqlQuery<TRespuestaSQL>("SP_EditarTec @id, @Nombre, @Cargo, @Usuario, @Contrasena, @Telefono, @Correo,@IdProyect",
                    new SqlParameter("@Id",Id),new SqlParameter("@Nombre", Nombre), new SqlParameter("@Cargo", Cargo),
                    new SqlParameter("@Usuario", Usuario), new SqlParameter("@Contrasena", Contrasena),
                    new SqlParameter("@Telefono", Telefono), new SqlParameter("@Correo", Correo),
                    new SqlParameter("@IdProyect", IdProyecto)).FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }
        //Editar Cordinador
        [HttpPost]
        public JsonResult PostEditCoord(Coord model)
        {
            var responseData = Edit_Coord(model.Id,model.Nombre, model.Usuario, model.Contrasena, model.Telefono, model.Correo, model.IdProyecto);
            return Json(responseData, JsonRequestBehavior.AllowGet);
        }
        public CRespuestaSQL Edit_Coord(int Id,string Nombre, string Usuario, string Contrasena, Nullable<decimal> Telefono, string Correo, int IdProyecto)
        {
            try
            {
                var data = ctx.Database.SqlQuery<CRespuestaSQL>("SP_EditarCoord @Id,@Nombre, @Usuario, @Contrasena, @Telefono, @Correo, @IdProyect",
                    new SqlParameter("@Id",Id),new SqlParameter("@Nombre", Nombre), new SqlParameter("@Usuario", Usuario), new SqlParameter("@Contrasena", Contrasena),
                    new SqlParameter("@Telefono", Telefono), new SqlParameter("@Correo", Correo), new SqlParameter("@IdProyect", IdProyecto)).FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }
    }

}