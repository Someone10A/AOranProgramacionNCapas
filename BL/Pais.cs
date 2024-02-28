using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AOranProgramacionNCapasEntities context = new DL_EF.AOranProgramacionNCapasEntities ()) 
                {
                    var query = context.PaisGetAll().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Pais pais = new ML.Pais();
                            pais.IdPais = item.IdPais;
                            pais.NombrePais = item.NombrePais;

                            result.Objects.Add(pais);
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
