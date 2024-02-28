using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empresa
    {
        //CRUD Entity Framework
        public static ML.Result AddEF(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.AOranProgramacionNCapasEntities context = new DL_EF.AOranProgramacionNCapasEntities()) 
                {
                    var query = context.EmpresaAdd(empresa.Nombre, empresa.Telefono, empresa.Email, empresa.DireccionWeb);

                    if (query>0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudieron ingresar los registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result UpdateEF(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AOranProgramacionNCapasEntities context = new DL_EF.AOranProgramacionNCapasEntities())
                {
                    var query = context.EmpresaUpdate(empresa.IdEmpresa,empresa.Nombre,empresa.Telefono,empresa.Email,empresa.DireccionWeb);
                    if (query>0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct= false;
                        result.ErrorMessage = "No se pudo actuaizar el registro";
                    }
                }    
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex= ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result DeleteEF(ML.Empresa empresa) 
        {
            ML.Result result= new ML.Result();
            try
            {
                using(DL_EF.AOranProgramacionNCapasEntities context = new DL_EF.AOranProgramacionNCapasEntities())
                {
                    var query = context.EmpresaRemove(empresa.IdEmpresa);
                    if (query>0)
                    { 
                        result.Correct = true; 
                    }
                    else
                    {
                        result.Correct =  false;
                        result.ErrorMessage = "No se pudo eliminar a la empresa";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage= ex.Message;
            }
            return result;
        }
        public static ML.Result GetAllEF()
        {
            ML.Result result= new ML.Result();
            try
            {
                using(DL_EF.AOranProgramacionNCapasEntities context = new DL_EF.AOranProgramacionNCapasEntities())
                {
                    var query = (context.EmpresaGetAll());
                    if (query !=null)
                    {
                        result.Objects = new List<object>();
                        foreach(var item in query)
                        {
                            ML.Empresa empresa = new ML.Empresa();
                            empresa.IdEmpresa = item.IdEmpresa;
                            empresa.Nombre = item.Nombre;
                            empresa.Telefono = item.Telefono;
                            empresa.Email = item.Email;
                            empresa.DireccionWeb = item.DireccionWeb;

                            result.Objects.Add(empresa);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                //throw;
            }
            return result;
        }
        public static ML.Result GetByIdEF(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.AOranProgramacionNCapasEntities context = new DL_EF.AOranProgramacionNCapasEntities())
                {
                    var query = context.EmpresaGetById(empresa.IdEmpresa);
                    if (query != null)
                    {
                        var item = query.FirstOrDefault();
                        empresa.IdEmpresa = item.IdEmpresa.Value;
                        empresa.Nombre = item.Nombre;
                        empresa.Telefono = item.Telefono;
                        empresa.Email = item.Email;
                        empresa.DireccionWeb = item.DireccionWeb;

                        result.Object = empresa;
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                //throw;
            }
            return result;
        }
        //CRUD LINQ
        public static ML.Result AddLINQ(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.AOranProgramacionNCapasEntities context = new DL_EF.AOranProgramacionNCapasEntities())
                {
                    DL_EF.Empresa empresaLINQ = new DL_EF.Empresa();
                    empresaLINQ.Nombre = empresa.Nombre;
                    empresaLINQ.Telefono = empresa.Telefono.ToString();
                    empresaLINQ.Email = empresa.Email;
                    empresaLINQ.DireccionWeb = empresa.DireccionWeb;

                    context.Empresas.Add(empresaLINQ);
                    int RowsAffected = context.SaveChanges();
                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.ErrorMessage = "Ocurrio un error al agregar el usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage= ex.Message;
                throw;
            }
            return result;
        }
        public static ML.Result UpdateLINQ( ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AOranProgramacionNCapasEntities context = new DL_EF.AOranProgramacionNCapasEntities())
                {
                    var queryLINQ = (from empresaLINQ in context.Empresas
                                     where empresaLINQ.IdEmpresa == empresa.IdEmpresa
                                     select empresaLINQ).SingleOrDefault();
                    if (queryLINQ != null)
                    {
                        queryLINQ.IdEmpresa = empresa.IdEmpresa;
                        queryLINQ.Nombre = empresa.Nombre;
                        queryLINQ.Telefono = empresa.Telefono;
                        queryLINQ.Email = empresa.Email;
                        queryLINQ.DireccionWeb = empresa.DireccionWeb;

                        context.SaveChanges();
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage=(ex.Message);
                //throw;
            }
            return result;
        }
        public static ML.Result DeleteLINQ(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AOranProgramacionNCapasEntities context = new DL_EF.AOranProgramacionNCapasEntities())
                {
                    var queryLINQ = (from empresaLINQ in context.Empresas
                                     where empresaLINQ.IdEmpresa == empresa.IdEmpresa
                                     select empresaLINQ).First();
                    if (queryLINQ != null)
                    {
                        context.Empresas.Remove(queryLINQ);
                        context.SaveChanges();
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct  = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.AOranProgramacionNCapasEntities context = new DL_EF.AOranProgramacionNCapasEntities())
                {
                    var queryLINQ = (from empresaLINQ in context.Empresas
                                     select new{
                                     IdEmpresa = empresaLINQ.IdEmpresa,
                                     Nombre = empresaLINQ.Nombre,
                                     Telefono = empresaLINQ.Telefono,
                                     Email = empresaLINQ.Email,
                                     DireccionWeb = empresaLINQ.DireccionWeb
                                     });
                    if (queryLINQ != null )
                    {
                        result.Objects = new List<object>();
                        foreach(var item in queryLINQ)
                        {
                            ML.Empresa empresa = new ML.Empresa();
                            empresa.IdEmpresa = item.IdEmpresa;
                            empresa.Nombre = item.Nombre;
                            empresa.Telefono = item.Telefono;
                            empresa.Email = item.Email;
                            empresa.DireccionWeb = item.DireccionWeb;
                            result.Objects.Add(empresa);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetByIdLINQ(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.AOranProgramacionNCapasEntities context = new DL_EF.AOranProgramacionNCapasEntities())
                {
                    var queryLINQ = (from empresaLINQ in context.Empresas
                                 where empresaLINQ.IdEmpresa == empresa.IdEmpresa
                                 select new
                                 {
                                     IdEmpresa = empresaLINQ.IdEmpresa,
                                     Nombre = empresaLINQ.Nombre,
                                     Telefono = empresaLINQ.Telefono,
                                     Email = empresaLINQ.Email,
                                     DireccionWeb = empresaLINQ.DireccionWeb
                                 });
                    if (queryLINQ != null)
                    {
                        var item = queryLINQ.First();
                        empresa.IdEmpresa = item.IdEmpresa;
                        empresa.Nombre = item.Nombre;
                        empresa.Telefono = item.Telefono;
                        empresa.Email = item.Email;
                        empresa.DireccionWeb = item.DireccionWeb;

                        result.Object = empresa;
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
   }
}
