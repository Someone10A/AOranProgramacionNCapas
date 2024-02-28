using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class EmpresaController : Controller
    {
        //GET: Empresa
        public ActionResult GetAll()
        {
            ML.Result result = BL.Empresa.GetAllEF();
            ML.Empresa empresa = new ML.Empresa();

            if (result.Correct)
            {
                empresa.Empresas = result.Objects;
            }
            return View(empresa);
        }


        [HttpGet]
        public ActionResult Form(int? IdEmpresa)
        {
            ML.Empresa empresa = new ML.Empresa();

            if (IdEmpresa == null)
            {
                ViewBag.Accion = "Agregar Empresa";
            }
            else
            {
                empresa.IdEmpresa = IdEmpresa.Value;
                ML.Result result = BL.Empresa.GetByIdEF(empresa);

                if (result.Correct)
                {
                    empresa = (ML.Empresa)result.Object;
                }
                ViewBag.Accion = "Actualizar Empresa";
            }
            return View(empresa);
        }

        [HttpPost]
        public ActionResult Form(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            if (empresa.IdEmpresa == 0)
            {
                result = BL.Empresa.AddEF(empresa);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se ha ingresado la empresa exitosamente";
                }
                else
                {
                    ViewBag.Mensaje = "No se pudo ingresar la empresa";
                }
                
            }
            else
            {
                result = BL.Empresa.UpdateLINQ(empresa);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se ha actualizado correctamente la empresa";
                }
                else
                {
                    ViewBag.Mensaje = "No se pudo actualizar";
                }
            }
            return View("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int IdEmpresa)
        {
            ML.Empresa empresa = new ML.Empresa();
            empresa.IdEmpresa = IdEmpresa;
            ML.Result result = BL.Empresa.GetByIdEF(empresa);
            result = BL.Empresa.DeleteEF(empresa);
            if (result.Correct)
            {
                empresa = (ML.Empresa)result.Object;
                ViewBag.Mensaje = "Se ha eliminado correctamente al usuario";
            }
            return View("Modal");
        }

    }
}