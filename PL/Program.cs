using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool superkey = true;
            do
            {
                Console.Clear();
                Console.WriteLine("¿Donde quieres acceder?\n1.Usuarios\n2.Empresa\n3.Salir");
                int acceso = int.Parse(Console.ReadLine());
                switch (acceso)
                {
                    case 1:
                        bool keyusuario = true;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Dime ¿Que quieres realizar? \n1.Ingresar Usuario. \n2.Actualizar Usuario. \n3.Eliminar Usuario. \n4.Visualizar Usuarios. \n5.Salir.:");
                            int opcionEmpresa = int.Parse(Console.ReadLine());

                            switch (opcionEmpresa)
                            {
                                case 1:
                                    PL.Usuario.Add();
                                    break;
                                case 2:
                                    PL.Usuario.Update();
                                    break;
                                case 3:
                                    PL.Usuario.Remove();
                                    break;
                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("¿Que quieres visualizar?\n1.Todos los Usuarios.\n2.Usuario Especifico.");
                                    int nuevaOpcion = int.Parse(Console.ReadLine());
                                    switch (nuevaOpcion)
                                    {
                                        case 1:
                                            PL.Usuario.GetAll();
                                            break;
                                        case 2:
                                            PL.Usuario.GetById();
                                            break;
                                        default:
                                            Console.WriteLine("No haz especificado una opcion valida, regresando al menu principal...");
                                            Console.ReadKey();
                                            break;
                                    }
                                    break;
                                case 5:
                                    keyusuario = false;
                                    break;
                                default:
                                    Console.WriteLine("No es alguna opcion valida");
                                    Console.ReadKey();
                                    break;
                            }
                        } while (keyusuario == true);
                        Console.WriteLine("Saliendo de usuarios");
                        Console.ReadKey();
                        break;
                    case 2:
                        bool keyempresa = true;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Que quieres hacer?\n1.Ingresar Empresa\n2.Actualizar Empresa\n3.Eliminar Empresa\n4.Ver Empresas.\n5.Salir");
                            int opcion = int.Parse(Console.ReadLine());
                            switch (opcion)
                            {
                                case 1:
                                    PL.Empresa.Add();
                                    break;
                                case 2:
                                    PL.Empresa.Update();
                                    break;
                                case 3:
                                    PL.Empresa.Delete();
                                    break;
                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("¿Que quieres ver?\n1.Todo\n2.Empresa por Id");
                                    int opcionEmpresaGet = int.Parse(Console.ReadLine());
                                    switch (opcionEmpresaGet)
                                    {
                                        case 1:
                                            PL.Empresa.GetAll();
                                            break;
                                        case 2:
                                            PL.Empresa.GetById();
                                            break;
                                        default:
                                            Console.WriteLine("No es una opcion valida, regresando al menu principal");
                                            break;
                                    }

                                    break;
                                case 5:
                                    keyempresa = false;
                                    Console.WriteLine("Saliendo de empresas");
                                    Console.ReadKey();
                                    break;
                                default:
                                    Console.WriteLine("Eso no es una ocion valida");
                                    Console.ReadKey();
                                    break;
                            }
                        } while (keyempresa == true);
                        break;
                    case 3:
                        superkey = false;
                        Console.WriteLine("Cerrando por completo el programa");
                        Console.ReadKey();
                        break;
                    case 4:
                        PL.Estado.ColoniaGetByIdMunicipio();
                        break;
                    default:
                        Console.WriteLine("Eso no es una ocion valida");
                        Console.ReadKey();
                        break;
                }
                //Console.ReadKey();
            } while (superkey == true);
            
        }
    }
}
