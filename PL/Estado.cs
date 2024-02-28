using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Estado
    {
        public static void PaisGetAll()
        {
            
            ML.Result result = BL.Pais.GetAllEF();
            if (result.Correct)
            {
                foreach (ML.Pais pais in result.Objects)
                {
                    Console.WriteLine(pais.IdPais);
                    Console.WriteLine(pais.NombrePais);
                }
                Console.ReadKey();
            }
        }
        public static void EstadoGetByIdPais()
        {
            ML.Pais pais = new ML.Pais();
            Console.WriteLine("Dame Id");
            pais.IdPais = int.Parse(Console.ReadLine());

            ML.Result result = BL.Estado.GetByIdPais(pais.IdPais.Value);
            if (result.Correct)
            {
                foreach (ML.Estado estado in result.Objects)
                {
                    
                    Console.WriteLine(estado.IdEstado);
                    Console.WriteLine(estado.NombreEstado);
                    Console.WriteLine(estado.Pais.IdPais);
                }
            }
            Console.ReadKey();
        }
        public static void MunicipioGetByIdEstado()
        {
            ML.Estado estado = new ML.Estado();
            Console.WriteLine("Dame Id");
            estado.IdEstado = int.Parse(Console.ReadLine());

            ML.Result result = BL.Municipio.GetByIdEstado(estado.IdEstado.Value);
            if (result.Correct)
            {
                foreach (ML.Municipio municipio in result.Objects)
                {
                    Console.WriteLine(municipio.IdMunicipio);
                    Console.WriteLine(municipio.NombreMunicipio);
                    Console.WriteLine(municipio.Estado.IdEstado);
                }
            }
            Console.ReadKey();
        }
        public static void ColoniaGetByIdMunicipio()
        {
            ML.Municipio municipio = new ML.Municipio();
            Console.WriteLine("Dame Id");
            municipio.IdMunicipio= int.Parse(Console.ReadLine());   

            ML.Result result = BL.Colonia.GetByIdMunicipio(municipio.IdMunicipio.Value);
            if (result.Correct)
            {
                foreach (ML.Colonia colonia in result.Objects)
                {
                    Console.WriteLine(colonia.IdColonia);
                    Console.WriteLine(colonia.NombreColonia);
                    Console.WriteLine(colonia.CodigoPostal);
                    Console.WriteLine(colonia.Municipio.IdMunicipio);
                }
            }
            Console.ReadKey();
        }
    }
}

