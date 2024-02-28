using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Empresa
    {
        public static void Add()
        {
            Console.Clear();
            ML.Empresa empresa = new ML.Empresa();
            Console.WriteLine("Dame el Id de la empresa, por favor");
            empresa.IdEmpresa = int.Parse(Console.ReadLine());
            Console.WriteLine("Dame el nombre de la empresa, por favor");
            empresa.Nombre = Console.ReadLine();
            Console.WriteLine("Dame el telefono de la empresa, por favor");
            empresa.Telefono = Console.ReadLine();
            Console.WriteLine("Dame el email de la empresa, por favor");
            empresa.Email = Console.ReadLine();
            Console.WriteLine("Dame la direccion web de la empresa, por favor");
            empresa.DireccionWeb = Console.ReadLine();

            //ML.Result result = BL.Empresa.AddEF(empresa);
            ML.Result result = BL.Empresa.AddLINQ(empresa);
            if (result.Correct)
            {
                Console.WriteLine("Se ha agregado a la empresa {0} correctamente",empresa.Nombre);
            }
            else
            {
                Console.WriteLine("Ocurrio..." + result.ErrorMessage);
            }
            Console.ReadKey();
        }
        public static void Update()
        {
            Console.Clear();
            ML.Empresa empresa = new ML.Empresa();
            Console.WriteLine("Dame el Id de la empresa para ACTUALIZAR, por favor");
            empresa.IdEmpresa = int.Parse(Console.ReadLine());

            Console.WriteLine("Dame el nombre de la empresa, por favor");
            empresa.Nombre = Console.ReadLine();
            Console.WriteLine("Dame el telefono de la empresa, por favor");
            empresa.Telefono = Console.ReadLine();
            Console.WriteLine("Dame el email de la empresa, por favor");
            empresa.Email = Console.ReadLine();
            Console.WriteLine("Dame la direccion web de la empresa, por favor");
            empresa.DireccionWeb = Console.ReadLine();

            //ML.Result result = BL.Empresa.UpdateEF(empresa);
            ML.Result result = BL.Empresa.UpdateLINQ(empresa);
            if (result.Correct)
            {
                Console.WriteLine("Se ha Actualizado a la empresa {0} correctamente", empresa.Nombre);
            }
            else
            {
                Console.WriteLine("Ocurrio..." + result.ErrorMessage);
            }
            Console.ReadKey();

        }
        public static void Delete () 
        {
            Console.Clear();
            ML.Empresa empresa = new ML.Empresa();
            Console.WriteLine("Dame el Id de la empresaa ELIMINAR, por favor");
            empresa.IdEmpresa = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Empresa.DeleteEF(empresa);
            ML.Result result = BL.Empresa.DeleteLINQ(empresa);
            if (result.Correct)
            {
                Console.WriteLine("Se ha eLiminado a la empresa {0} correctamente", empresa.Nombre);
            }
            else
            {
                Console.WriteLine("Ocurrio..." + result.ErrorMessage);
            }
            Console.ReadKey();
        }
        public static void GetAll()
        {
            Console.Clear();
            //ML.Result result = BL.Empresa.GetAllEF();
            ML.Result result = BL.Empresa.GetAllLINQ();
            if (result.Correct)
            {
                foreach(ML.Empresa empresa in result.Objects)
                {
                    Console.WriteLine("Id empresa: "+ empresa.IdEmpresa);
                    Console.WriteLine("Nombre empresa: "+empresa.Nombre);
                    Console.WriteLine("Telefono empresa: "+empresa.Telefono);
                    Console.WriteLine("Email empresa: "+empresa.Email);
                    Console.WriteLine("Direccion web empresa: "+empresa.DireccionWeb);
                    Console.WriteLine("---------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No se pudieron recopilar los datos");
            }
            Console.ReadKey();
        }
        public static void GetById()
        {
            Console.Clear();
            ML.Empresa empresa = new ML.Empresa();
            Console.WriteLine("Indica el Id de la empersa a consultar");
            empresa.IdEmpresa = int.Parse(Console.ReadLine());
            //ML.Result result = BL.Empresa.GetByIdEF(empresa);
            ML.Result result = BL.Empresa.GetByIdLINQ(empresa);
            if (result.Correct)
            {
                Console.WriteLine("Id empresa: " + empresa.IdEmpresa);
                Console.WriteLine("Nombre empresa: " + empresa.Nombre);
                Console.WriteLine("Telefono empresa: " + empresa.Telefono);
                Console.WriteLine("Email empresa: " + empresa.Email);
                Console.WriteLine("Direccion web empresa: " + empresa.DireccionWeb);
            }
            else
            {
                Console.WriteLine("No hay resultados del id consultado");
            }
            Console.ReadKey();  
        }
    }
}
