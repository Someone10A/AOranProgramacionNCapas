using ML;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        //GET: Usuario
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result resultRol = BL.Rol.GetAllEF();
            usuario.Rol = new ML.Rol();
            usuario.Rol.Roles = resultRol.Objects;


            ML.Result result = BL.Usuario.GetAllEF(usuario);
            usuario.Rol.Roles = resultRol.Objects;

            if (result.Correct && result.Objects.Count>0)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.Message = "No hay elementos recuperados";
            }
            

            return View(usuario);
        }
        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario)
            {
            ML.Result result = BL.Usuario.GetAllEF(usuario);

            ML.Result resultRol = BL.Rol.GetAllEF();
            usuario.Rol = new ML.Rol();
            usuario.Rol.Roles = resultRol.Objects;

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }

                return View(usuario);
        }


        [HttpGet]
        public ActionResult Form(int? IdUsuario)
            {
            ML.Usuario usuario = new ML.Usuario();
            //get Roles
            ML.Result resultRol = BL.Rol.GetAllEF();
            usuario.Rol = new ML.Rol();
            usuario.Rol.Roles =  resultRol.Objects;

            ML.Result resultPais = BL.Pais.GetAllEF();
            usuario.Direccion = new ML.Direccion();
            //Pais
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
            usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
            //Estado
            //ML.Result resultEstado = BL.Estado.GetByIdPais();
            //usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstado.Objects;
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
            

            if (IdUsuario == null)
            {
                ViewBag.Accion = "Agregar Usuario";

                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;

            }
            else
                {
                usuario.IdUsuario = IdUsuario.Value;
                    ML.Result result = BL.Usuario.GetByIdEF(usuario);
                
                if (result.Correct)
                {
                    

                    usuario = ((ML.Usuario)result.Object);

                    if(usuario.Direccion.IdDireccion != null)
                    {
                        ML.Result resultEstados = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais.Value);
                        ML.Result resultMunicipios = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado.Value);
                        ML.Result resultColonias = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio.Value);

                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                        usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;
                        usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipios.Objects;
                        usuario.Direccion.Colonia.Colonias = resultColonias.Objects;
                    }

                }
                
                usuario.Rol.Roles = resultRol.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;

                ViewBag.Accion = "Actualizar Usuario";
                
            }

            return View(usuario);
        }   
        [HttpPost]
        public ActionResult Form([Bind(Exclude = "idUsuario")] ML.Usuario usuario, HttpPostedFileBase fuImagen)
        {
            {
                ML.Result result = new ML.Result();
                //ML.Rol rol = new ML.Rol();

                if (ModelState.IsValid)
                {
                    if ((usuario.Imagen != null && fuImagen != null) || (usuario.Imagen == null && fuImagen != null))
                    {
                        usuario.Imagen = convertFileToByteArray(fuImagen);
                    }



                    if (usuario.IdUsuario == 0)
                    {
                        result = BL.Usuario.AddEF(usuario);

                        if (result.Correct)
                        {
                            ViewBag.Mensaje = "Se ha ingresado correctamente al usuario";

                        }
                        else
                        {
                            ViewBag.Mensaje = "No se ingreso, ocurrio " + result.ErrorMessage;
                        }
                        return View("Modal");
                    }
                    else
                    {
                        if (usuario.Direccion.IdDireccion == 0 || usuario.Direccion.IdDireccion == null)
                        {
                            usuario.Accion = 0;
                        }
                        else
                        {
                            usuario.Accion = 1;
                        }
                        result = BL.Usuario.UpdateEF(usuario);
                        if (result.Correct)
                        {
                            ViewBag.Mensaje = "Se ha actualizado correctamente al usuario";
                        }
                        else
                        {
                            ViewBag.Mensaje = "No se pudo actualizar";
                        }
                        return View("Modal");
                    }
                }
                else
                {
                    ML.Result resultRol = BL.Rol.GetAllEF();
                    usuario.Rol = new ML.Rol();
                    usuario.Rol.Roles = resultRol.Objects;

                    ML.Result resultPais = BL.Pais.GetAllEF();
                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                    return View(usuario);
                }
            }
        }

        
        [HttpGet]
        public ActionResult Delete(int IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.IdUsuario = IdUsuario;
            ML.Result result = BL.Usuario.GetByIdEF(usuario);
            result = BL.Usuario.RemoveEF(usuario);
            if (result.Correct)
            {
                usuario = (ML.Usuario)result.Object;
                ViewBag.Mensaje = "Se ha eliminado correctamente al usuario";
            }
            return View("Modal");
        }

        public byte[] convertFileToByteArray(HttpPostedFileBase fuImagen)
        {
            MemoryStream target = new MemoryStream();
            fuImagen.InputStream.CopyTo(target);
            byte[] data = target.ToArray();
            return data;
        }

        public JsonResult GetEstado(int IdPais)
        {
            var result = BL.Estado.GetByIdPais(IdPais);

            return Json(result.Objects);
        }
        public JsonResult GetMunicipio(int IdEstado)
        {
            var result = BL.Municipio.GetByIdEstado(IdEstado);

            return Json(result.Objects);
        }
        public JsonResult GetColonia(int IdMunicipio)
        {
            var result = BL.Colonia.GetByIdMunicipio(IdMunicipio);

            //return Json(result.Objects);
            return Json(result.Objects);
        }

        [HttpPost]
        public JsonResult CambiarStatus(int idUsuario, bool estatus)
        {
            ML.Result result = BL.Usuario.ChangeStatus(idUsuario, estatus);

            return Json(result);
        }
    }
}