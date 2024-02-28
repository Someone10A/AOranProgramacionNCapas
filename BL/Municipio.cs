using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {
        public static ML.Result GetByIdEstado(int IdEstado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.AOranProgramacionNCapasEntities context = new DL_EF.AOranProgramacionNCapasEntities())
                {
                    var query = context.MunicipioGetByIdEstado(IdEstado).ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Municipio municipio = new ML.Municipio();
                            municipio.IdMunicipio = item.IdMunicipio;
                            municipio.NombreMunicipio = item.NombreMunicipio.ToString();
                            municipio.Estado = new ML.Estado(); 
                            municipio.Estado.IdEstado = int.Parse(item.IdEstado.ToString());

                            result.Objects.Add(municipio);
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
