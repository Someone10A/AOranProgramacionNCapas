using BL;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {
        public static void Add()
        {
            Console.Clear();
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            bool keySexo = true;
            bool keyRol = true;

            Console.WriteLine("Ingresa un USERNAME para el nuevo usuario, por favor");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Ingresa el nombre para el nuevo usuario, por favor");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingresa el primer apellido para el nuevo usuario, por favor");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Ingresa el segundo apellido para el nuevo usuario, por favor");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Ingresa el correo electronico para el nuevo usuario, por favor");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Crea una nueva CONTRASEÑA");
            usuario.Password = Console.ReadLine();
            do
            {
                Console.WriteLine("Ingresa Si es M para masculino o F para femenino, por favor");
                usuario.Sexo = Console.ReadLine();
                switch (usuario.Sexo)
                {
                    case "M":
                    case "F":
                        keySexo=false;
                        break;
                    default:
                        Console.WriteLine("No es un valor válido, por favor usa M o F");
                        break;
                }
            } while (keySexo==true);
            
            Console.WriteLine("Ingresa el telefono fijo del usuario, por favor");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Ingresa el numero celular del usuario, por favor");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("Ingresa la fecha de nacimiento del nuevo usuario, por favor");
            usuario.FechaNacimiento = Console.ReadLine();
            Console.WriteLine("Ingresa el CURP del nuevo usuario, por favor");
            usuario.CURP = Console.ReadLine();
            do
            {
                Console.WriteLine("Ingresa 1 si eres administrador o 2 si eres usuario");
                int testRol = int.Parse(Console.ReadLine());
                switch (testRol)
                {
                    case 1:
                    case 2:
                        usuario.Rol.IdRol = testRol;
                        keyRol = false;
                        break;
                    default:
                        Console.WriteLine("No es una opcion valida, pon algo valido");
                        break;
                }
    
            } while (keyRol==true);



            //ML.Result result = BL.Usuario.Add(usuario, rol);
            //ML.Result result = BL.Usuario.AddSP(usuario, rol);
            ML.Result result = BL.Usuario.AddEF(usuario);
            //ML.Result result = BL.Usuario.AddLINQ(usuario, rol);

            if (result.Correct ) 
            {
                Console.WriteLine("El usuario ha sido agregado de manera correcta.");
            }
            else
            {
                Console.WriteLine("Ocurrio..." + result.ErrorMessage);
            }
            Console.ReadKey ();

        }

        public static void Update()
        {
            Console.Clear();
            ML.Usuario usuario = new ML.Usuario();
            ML.Rol rol = new ML.Rol();
            bool keySexo = true;
            bool keyRol = true;

            Console.WriteLine("Ingresa el Id del usuario para actualizar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());             

            Console.WriteLine("Ingresa el nuevo USERNAME para el usuario con id: {0}, por favor", usuario.IdUsuario);
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Ingresa el nuevo nombre para el usuario con id: {0}, por favor", usuario.IdUsuario);
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingresa el nuevo primer apellido para el  usuario con id: {0}, por favor", usuario.IdUsuario);
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Ingresa el nuevo segundo apellido para el usuario con id: {0}, por favor", usuario.IdUsuario);
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Ingresa el correo electronico para el usuario con id: {0}, por favor", usuario.IdUsuario);
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Ingresa Nueva contraseña para el usuario con id: {0}, por favor", usuario.IdUsuario);
            usuario.Password = Console.ReadLine();
            
            do
            {
                Console.WriteLine("Ingresa Si es M para masculino o F para femenino para el usuario con id: {0}, por favor", usuario.IdUsuario);
                usuario.Sexo = Console.ReadLine();
                switch (usuario.Sexo)
                {
                    case "M":
                    case "F":
                        keySexo = false;
                        break;
                    default:
                        Console.WriteLine("No es un valor válido, por favor usa M o F");
                        break;
                }
            } while (keySexo == true);
            Console.WriteLine("Ingresa el telefono fijo para el usuario con id: {0}, por favor", usuario.IdUsuario);
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Ingresa el numero celular para el usuario con id: {0}, por favor", usuario.IdUsuario);
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("Ingresa la fecha de nacimiento para el usuario con id: {0}o, por favor", usuario.IdUsuario);
            usuario.FechaNacimiento = Console.ReadLine();
            Console.WriteLine("Ingresa el CURP para el usuario con id: {0}, por favor", usuario.IdUsuario);
            usuario.CURP = Console.ReadLine();
            do
            {
                Console.WriteLine("Ingresa 1 si eres administrador o 2 si eres usuario");
                int testRol = int.Parse(Console.ReadLine());
                switch (testRol)
                {
                    case 1:
                    case 2:
                        rol.IdRol = testRol;
                        keyRol = false;
                        break;
                    default:
                        Console.WriteLine("No es una opcion valida, pon algo valido");
                        break;
                }

            } while (keyRol == true);

            //ML.Result result = BL.Usuario.Update(usuario);
            //ML.Result result = BL.Usuario.UpdateST(usuario, rol);
            //ML.Result result = BL.Usuario.UpdateEF(usuario, rol);
            ML.Result result = BL.Usuario.UpdateLINQ(usuario);

            if (result.Correct)
            {
                Console.WriteLine("El usuario ha sido actualizado de manera correcta.");
            }
            else
            {
                Console.WriteLine("Ocurrio..." + result.ErrorMessage);
            }
            Console.ReadKey();
        }

        public static void Remove() 
        {
            Console.Clear();
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Dame el Id del usuario a eliminar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Usuario.Remove(usuario);
            //ML.Result result = BL.Usuario.RemoveST(usuario);
            //ML.Result result = BL.Usuario.RemoveEF(usuario);
            ML.Result result = BL.Usuario.RemoveLINQ(usuario);

            if (result.Correct)
            {
                Console.WriteLine("El usuario ha sido eliminado de manera correcta.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ocurrio..." + result.ErrorMessage);
                Console.ReadKey();
            }
            
        }

        public static void GetAll()
        {
            Console.Clear();
            //ML.Result result = BL.Usuario.GetAll();
            //ML.Result result = BL.Usuario.GetAllEF();

            ML.Result result = BL.Usuario.GetAllLINQ();

            if (result.Correct)
            {
                //Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------");
                //Console.WriteLine("| Id |   Username   |  Nombre  | A. Paterno | A. Materno |      Email       | Password |Sexo|  Telefono  |  Celular   |  F. nac. |       CURP       |IdRol|");
                //Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------");

                //foreach (ML.Usuario usuario in result.Objects)
                //{
                //    string fechaX = usuario.FechaNacimiento.ToString("dd/MM/yyyy");
                //    Console.WriteLine("|{0,4}|{1,14}|{2,10}|{3,12}|{4,12}|{5,18}|{6,10}|{7,4}|{8,12}|{9,12}|{10,10}|{11,18}|{12,5}|",
                //    usuario.IdUsuario, usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.Password,usuario.Sexo, usuario.Telefono, usuario.Celular, fechaX, usuario.CURP,usuario.Rol.IdRol);
                //    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------");
                //}
                foreach (ML.Usuario usuario in result.Objects)
                { 
                Console.WriteLine("__________________________________________________________________________");
                Console.WriteLine("El id del usuario es: " + usuario.IdUsuario);
                Console.WriteLine("El USERNAME es: " + usuario.UserName);
                Console.WriteLine("El nombre del usuario es: " + usuario.Nombre);
                Console.WriteLine("El primer apellido del usuario es: " + usuario.ApellidoPaterno);
                Console.WriteLine("El segundo apellido del usuario es: " + usuario.ApellidoMaterno);
                Console.WriteLine("El correo del usuario es: " + usuario.Email);
                Console.WriteLine("El password es: " + usuario.Password);
                Console.WriteLine("El sexo es: " + usuario.Sexo);
                Console.WriteLine("Numero Telefonico es: " + usuario.Telefono);
                Console.WriteLine("Numero Celular es: " + usuario.Celular);
                Console.WriteLine("Fecha de nacimiento es: " + usuario.FechaNacimiento);
                Console.WriteLine("El CURP es: " + usuario.CURP);
                Console.WriteLine("El id del rol es:" + usuario.Rol.IdRol);
                Console.WriteLine("El rol es:" + usuario.Rol.Nombre);
                }
            }
            else 
            { 
                Console.WriteLine("No hay resultados");
                Console.ReadKey();
            }

            Console.ReadKey();
        }

        public static void GetById()
        {
            Console.Clear();
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Dame el Id del usuario a consultar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Usuario.GetById(usuario);
            //ML.Result result = BL.Usuario.GetByIdEF(usuario);
            ML.Result result = BL.Usuario.GetByIdLINQ(usuario);
            if (result.Correct)
            {
                Console.WriteLine("**************************");
                Console.WriteLine("El id del usuario es: " + usuario.IdUsuario);
                Console.WriteLine("El USERNAME es: " + usuario.UserName);
                Console.WriteLine("El nombre del usuario es: " + usuario.Nombre);
                Console.WriteLine("El primer apellido del usuario es: " + usuario.ApellidoPaterno);
                Console.WriteLine("El segundo apellido del usuario es: " + usuario.ApellidoMaterno);
                Console.WriteLine("El correo del usuario es: " + usuario.Email);
                Console.WriteLine("El password es: " + usuario.Password);
                Console.WriteLine("El sexo es: " + usuario.Sexo);
                Console.WriteLine("Numero Telefonico es: " + usuario.Telefono);
                Console.WriteLine("Numero Celular es: " + usuario.Celular);
                Console.WriteLine("Fecha de nacimiento es: " + usuario.FechaNacimiento);
                Console.WriteLine("El CURP es: " + usuario.CURP);
                Console.WriteLine("El id del rol es:" + usuario.Rol.IdRol);
                Console.WriteLine("El rol es:" + usuario.Rol.Nombre);
            }
            else
            {
                Console.WriteLine("No hay resultados");
                Console.ReadKey();
            }

            Console.ReadKey();
        }
    }
}
