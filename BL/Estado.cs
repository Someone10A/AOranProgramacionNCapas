using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static ML.Result GetByIdPais(int IdPais)
        {
            ML.Result result = new ML.Result();
            
            try
            {
                using (DL_EF.AOranProgramacionNCapasEntities context = new DL_EF.AOranProgramacionNCapasEntities())
                {
                    var query = context.EstadoGetByIdPais(IdPais).ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Estado estado = new ML.Estado();
                            estado.IdEstado = item.IdEstado;
                            estado.NombreEstado = item.NombreEstado;
                            estado.Pais = new ML.Pais();
                            estado.Pais.IdPais = IdPais;

                            result.Objects.Add(estado);
                            result.Correct = true;  
                        }
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
    }
}
