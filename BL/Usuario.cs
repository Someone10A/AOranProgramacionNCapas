using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ML;
using System.Runtime.InteropServices;
using System.Globalization;

namespace BL
{
    public class Usuario
    {
        //CRUD QUERY NORMAL
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {

                using (SqlConnection context = new SqlConnection())
                {
                    context.ConnectionString = DL.Conexion.GetConnectionString();
                    context.Open();
                    string querry = "INSERT INTO [Usuario]([Nombre],[ApellidoPaterno],[ApellidoMaterno],[NumeroTelefonico],[CorreoElectronico]) VALUES (@Nombre, @ApellidoUno,@ApellidoDos,@NumeroTelefonico,@CorreoElectronico)";

                    using (SqlCommand cmd = new SqlCommand(querry, context))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@ApellidoUno", usuario.ApellidoPaterno);
                        cmd.Parameters.AddWithValue("@ApellidoDos", usuario.ApellidoMaterno);
                        cmd.Parameters.AddWithValue("@Email", usuario.Email);
                        cmd.Parameters.AddWithValue("@Password", usuario.Password);
                        cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                        cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                        cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@CURP", usuario.CURP);

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "El usuario no se pudo agregar correctamente";
                        }
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
        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {

                using (SqlConnection context = new SqlConnection())
                {
                    context.ConnectionString = DL.Conexion.GetConnectionString();
                    context.Open();
                    string querry = "UPDATE Usuario SET Nombre = @Nombre, ApellidoUno = @ApellidoUno, ApellidoDos = @ApellidoDos, NumeroTelefonico = @NumeroTelefonico, CorreoElectronico = @CorreoElectronico WHERE IdUsuario = @IdUsuario;";

                    using (SqlCommand cmd = new SqlCommand(querry, context))
                    {
                        cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                        cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                        cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                        cmd.Parameters.AddWithValue("@Email", usuario.Email);
                        cmd.Parameters.AddWithValue("@Password", usuario.Password);
                        cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                        cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                        cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@CURP", usuario.CURP);

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "El usuario no se pudo actualizar correctamente";
                        }
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
        public static ML.Result Remove(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection())
                {
                    context.ConnectionString = DL.Conexion.GetConnectionString();
                    context.Open();
                    string querryDos = "DELETE FROM Usuario WHERE IdUsuario = @IdUsuario;";

                    using (SqlCommand cmd = new SqlCommand(querryDos, context))
                    {
                        cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "El usuario no se pudo eliminar correctamente";
                        }
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

        //CRUD STORAGE PROCEDURE
        public static ML.Result AddST(ML.Usuario usuario, ML.Rol rol)
        {
            ML.Result result = new ML.Result(); 

            try
            {
                
                using (SqlConnection context = new SqlConnection())
                {
                    context.ConnectionString = DL.Conexion.GetConnectionString();
                    context.Open();
                    string querry = "UsuarioAdd";

                    using (SqlCommand cmd = new SqlCommand(querry, context)) 
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                        cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                        cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                        cmd.Parameters.AddWithValue("@Email", usuario.Email);
                        cmd.Parameters.AddWithValue("@Password", usuario.Password);
                        cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                        cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                        cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@CURP", usuario.CURP);
                        cmd.Parameters.AddWithValue("@IdRol", rol.IdRol);
                            
                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0) 
                        {
                            result.Correct = true;
                            
                        }
                        else 
                        {
                            result.Correct= false;
                            result.ErrorMessage = "El usuario no se pudo agregar correctamente";
                        }
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
        public static ML.Result UpdateST(ML.Usuario usuario, ML.Rol rol)
        {
            ML.Result result = new ML.Result();

            try
            {

                using (SqlConnection context = new SqlConnection())
                {
                    context.ConnectionString = DL.Conexion.GetConnectionString();
                    context.Open();
                    string querry = "UsuarioUpdate";

                    using (SqlCommand cmd = new SqlCommand(querry, context))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                        cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                        cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                        cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                        cmd.Parameters.AddWithValue("@Email", usuario.Email);
                        cmd.Parameters.AddWithValue("@Password", usuario.Password);
                        cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                        cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                        cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@CURP", usuario.CURP);
                        cmd.Parameters.AddWithValue("@IdRol", rol.IdRol);

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "El usuario no se pudo actualizar correctamente";
                        }
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
        public static ML.Result RemoveST(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection())
                {
                    context.ConnectionString = DL.Conexion.GetConnectionString();
                    context.Open();
                    string querry = "UsuarioDelete";

                    using (SqlCommand cmd = new SqlCommand(querry, context))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "El usuario no se pudo eliminar correctamente";
                        }
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
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {

                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "UsuarioGetAll";
                    using (SqlCommand cmd = new SqlCommand(query, context)) { 
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable UsuarioGetAll = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    sqlDataAdapter.Fill(UsuarioGetAll);
                        if (UsuarioGetAll.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow item in UsuarioGetAll.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();
                                usuario.IdUsuario = int.Parse(item[0].ToString());
                                usuario.UserName = item[1].ToString();
                                usuario.Nombre = item[2].ToString();
                                usuario.ApellidoPaterno = item[3].ToString();
                                usuario.ApellidoMaterno = item[4].ToString();
                                usuario.Email = item[5].ToString();
                                usuario.Password = item[6].ToString();
                                usuario.Sexo = item[7].ToString();
                                usuario.Telefono = item[8].ToString();
                                usuario.Celular = item[9].ToString();
                                usuario.FechaNacimiento = item[10].ToString();
                                usuario.CURP = item[11].ToString();


                                // ML.Rol rol = new ML.Rol();
                                //usuario.Rol = new Rol();
                                usuario.Rol.IdRol = int.Parse(item[12].ToString());
                                

                                result.Objects.Add(usuario);
                            }
                            
                            
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
            }
            return result;
        }
        public static ML.Result GetById(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "UsuarioGetById";
                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                        DataTable UsuarioGetById = new DataTable();
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        sqlDataAdapter.Fill(UsuarioGetById);
                        if (UsuarioGetById.Rows.Count > 0)
                        {
                            DataRow item = UsuarioGetById.Rows[0];
                            usuario.IdUsuario = int.Parse(item[0].ToString());
                            usuario.UserName = item[1].ToString();
                            usuario.Nombre = item[2].ToString();
                            usuario.ApellidoPaterno = item[3].ToString();
                            usuario.ApellidoMaterno = item[4].ToString();
                            usuario.Email = item[5].ToString();
                            usuario.Password = item[6].ToString();
                            usuario.Sexo = item[7].ToString();
                            usuario.Telefono = item[8].ToString();
                            usuario.Celular = item[9].ToString();
                            usuario.FechaNacimiento = item[10].ToString();
                            usuario.CURP = item[11].ToString();

                            //usuario.Rol = new Rol();
                            usuario.Rol.IdRol = int.Parse(item[12].ToString());

                            result.Object = usuario;
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
            }
            return result;
        }

        //CRUD Entity Framework
        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            //usuario.Rol = new ML.Rol();
            try
            {
                using (DL_EF.AOranProgramacionNCapasEntities context = new DL_EF.AOranProgramacionNCapasEntities())
                {
                    var query = context.UsuarioAdd(usuario.UserName,usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email,usuario.Password,usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.FechaNacimiento, usuario.CURP, usuario.Rol.IdRol, usuario.Imagen, usuario.Direccion.Calle, usuario.Direccion.NumeroExterno, usuario.Direccion.NumeroInterno,usuario.Direccion.Colonia.IdColonia);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo insertar el registro";
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
        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AOranProgramacionNCapasEntities context = new DL_EF.AOranProgramacionNCapasEntities())
                {
                    int query = context.UsuarioUpdate(usuario.IdUsuario,usuario.UserName,usuario.Nombre,usuario.ApellidoPaterno,usuario.ApellidoMaterno,usuario.Email,usuario.Password,usuario.Sexo,usuario.Telefono,usuario.Celular,usuario.FechaNacimiento,usuario.CURP,usuario.Rol.IdRol,usuario.Imagen,usuario.Accion,usuario.Direccion.IdDireccion,usuario.Direccion.Calle,usuario.Direccion.NumeroExterno,usuario.Direccion.NumeroInterno,usuario.Direccion.Colonia.IdColonia);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar el registro";
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
        public static ML.Result RemoveEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AOranProgramacionNCapasEntities context = new DL_EF.AOranProgramacionNCapasEntities())
                {
                    int query = context.UsuarioDelete(usuario.IdUsuario);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar el registro";
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
        public static ML.Result GetAllEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.AOranProgramacionNCapasEntities context = new DL_EF.AOranProgramacionNCapasEntities())
                {
                    usuario.Nombre = (usuario.Nombre == null) ? "" : usuario.Nombre;
                    usuario.ApellidoPaterno = (usuario.ApellidoPaterno == null) ? "" : usuario.ApellidoPaterno;
                    usuario.ApellidoMaterno = (usuario.ApellidoMaterno == null) ? "" : usuario.ApellidoMaterno;


                    var query = context.UsuarioGetAll(usuario.Nombre,usuario.ApellidoPaterno,usuario.ApellidoMaterno,usuario.Rol.IdRol);
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            usuario = new ML.Usuario();
                            usuario.IdUsuario = item.IdUsuario;
                            usuario.UserName = item.Username;
                            usuario.Nombre = item.Nombre;
                            usuario.ApellidoPaterno = item.ApellidoPaterno;
                            usuario.ApellidoMaterno = item.ApellidoMaterno;
                            usuario.Email = item.Email;
                            usuario.Password = item.Password;
                            usuario.Sexo = item.Sexo;
                            usuario.Telefono = item.Telefono;
                            usuario.Celular = item.Celular;
                            usuario.FechaNacimiento = item.FechaNacimiento.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                            usuario.CURP = item.CURP;

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = item.IdRol;
                            usuario.Rol.Nombre = item.RolNombre;

                            usuario.Imagen = item.Imagen;

                            usuario.Estatus = (bool)item.Estatus;

                            
                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.IdDireccion = item.IdDireccion;
                            usuario.Direccion.Calle = item.Calle;
                            usuario.Direccion.NumeroExterno = item.NumeroExterno;
                            usuario.Direccion.NumeroInterno = item.NumeroInterno;
                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.IdColonia = item.IdColonia;
                            usuario.Direccion.Colonia.NombreColonia = item.NombreColonia;
                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.IdMunicipio = item.IdMunicipio;
                            usuario.Direccion.Colonia.Municipio.NombreMunicipio = item.NombreMunicipio;
                            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuario.Direccion.Colonia.Municipio.Estado.IdEstado = item.IdEstado;
                            usuario.Direccion.Colonia.Municipio.Estado.NombreEstado = item.NombreEstado;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = item.IdPais;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.NombrePais = item.NombrePais;

                            result.Correct = true;
                            result.Objects.Add(usuario);
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
        public static ML.Result GetByIdEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AOranProgramacionNCapasEntities context = new DL_EF.AOranProgramacionNCapasEntities())
                {
                    var query = context.UsuarioGetById(usuario.IdUsuario);
                    if (query != null)
                    {
                        var item = query.FirstOrDefault();
                            
                            usuario.IdUsuario = item.IdUsuario;
                            usuario.UserName = item.UserName;
                            usuario.Nombre = item.Nombre;
                            usuario.ApellidoPaterno = item.ApellidoPaterno;
                            usuario.ApellidoMaterno = item.ApellidoMaterno;
                            usuario.Email = item.Email;
                            usuario.Password = item.Password;
                            usuario.Sexo = item.Sexo;
                            usuario.Telefono = item.Telefono;
                            usuario.Celular = item.Celular;

                            usuario.FechaNacimiento = item.FechaNacimiento.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                            usuario.CURP = item.CURP;

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = item.IdRol;
                            usuario.Rol.Nombre = item.RolNombre;
                            
                            usuario.Imagen = item.Imagen;

                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.IdDireccion = item.IdDireccion;
                            usuario.Direccion.Calle = item.Calle;
                            usuario.Direccion.NumeroExterno = item.NumeroExterno;
                            usuario.Direccion.NumeroInterno = item.NumeroInterno;
                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.IdColonia = item.IdColonia;
                            usuario.Direccion.Colonia.NombreColonia = item.NombreColonia;
                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.IdMunicipio = item.IdMunicipio;
                            usuario.Direccion.Colonia.Municipio.NombreMunicipio = item.NombreMunicipio;
                            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuario.Direccion.Colonia.Municipio.Estado.IdEstado = item.IdEstado;
                            usuario.Direccion.Colonia.Municipio.Estado.NombreEstado = item.NombreEstado;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = item.IdPais;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.NombrePais = item.NombrePais;



                        result.Correct = true;
                            result.Object = usuario;
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

        public static ML.Result ChangeStatus(int idUsuario, bool estatus)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.AOranProgramacionNCapasEntities context = new DL_EF.AOranProgramacionNCapasEntities())
                {
                    int query = context.EstatusUsuario(idUsuario, estatus);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
                    }


                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        //CRUD LINQ
        public static ML.Result AddLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AOranProgramacionNCapasEntities context = new DL_EF.AOranProgramacionNCapasEntities())
                {
                    DL_EF.Usuario usuarioLINQ = new DL_EF.Usuario();
                    usuarioLINQ.UserName = usuario.UserName;
                    usuarioLINQ.Nombre = usuario.Nombre;
                    usuarioLINQ.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioLINQ.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioLINQ.Email = usuario.Email;
                    usuarioLINQ.Password = usuario.Password;
                    usuarioLINQ.Sexo = usuario.Sexo;
                    usuarioLINQ.Telefono = usuario.Telefono;
                    usuarioLINQ.Celular = usuario.Celular;
                    usuarioLINQ.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento);
                    usuarioLINQ.IdRol = usuario.Rol.IdRol;

                    context.Usuarios.Add(usuarioLINQ);
                    int RowsAffected = context.SaveChanges();
                    if (RowsAffected > 0)
                    {
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
        public static ML.Result UpdateLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.AOranProgramacionNCapasEntities context = new DL_EF.AOranProgramacionNCapasEntities()) 
                {
                    var usuarioLINQ = (from queryLINQ in context.Usuarios
                                       where queryLINQ.IdUsuario == usuario.IdUsuario
                                       select queryLINQ).SingleOrDefault();
                    if (usuarioLINQ != null)
                    {
                        usuarioLINQ.UserName = usuario.UserName;
                        usuarioLINQ.Nombre = usuario.Nombre;
                        usuarioLINQ.ApellidoPaterno = usuario.ApellidoPaterno;
                        usuarioLINQ.ApellidoMaterno = usuario.ApellidoMaterno;
                        usuarioLINQ.Email = usuario.Email;
                        usuarioLINQ.Password = usuario.Password;
                        usuarioLINQ.Sexo = usuario.Sexo;
                        usuarioLINQ.Telefono = usuario.Telefono;
                        usuarioLINQ.Celular = usuario.Celular;
                        usuarioLINQ.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento);
                        usuarioLINQ.IdRol = usuario.Rol.IdRol;

                        context.SaveChanges();
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage= ex.Message;

                // throw;
            }
            return result;
        }
        public static ML.Result RemoveLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.AOranProgramacionNCapasEntities context = new DL_EF.AOranProgramacionNCapasEntities())
                {
                    var usuarioLINQ = (from queryLINQ in context.Usuarios
                                       where queryLINQ.IdUsuario == usuario.IdUsuario
                                       select queryLINQ).First();
                    if (usuarioLINQ != null)
                    {
                        context.Usuarios.Remove(usuarioLINQ);
                        context.SaveChanges();
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex= ex;
                result.ErrorMessage= ex.Message;
                //throw;
            }
            return result;
        }
        public static ML.Result GetAllLINQ()
        {
            ML.Result result= new ML.Result();
            try
            {
                using (DL_EF.AOranProgramacionNCapasEntities context = new DL_EF.AOranProgramacionNCapasEntities())
                {
                    var query = (from usuarioLINQ in context.Usuarios
                                 join rolLINQ in context.Rols on usuarioLINQ.IdRol equals rolLINQ.IdRol
                                 select new
                                 {
                                     IdUsuario = usuarioLINQ.IdUsuario,
                                     UserName = usuarioLINQ.UserName,
                                     Nombre = usuarioLINQ.Nombre,
                                     ApellidoPaterno = usuarioLINQ.ApellidoPaterno,
                                     ApellidoMaterno = usuarioLINQ.ApellidoMaterno,
                                     Email = usuarioLINQ.Email,
                                     Password = usuarioLINQ.Password,
                                     Sexo = usuarioLINQ.Sexo,
                                     Telefono = usuarioLINQ.Telefono,
                                     Celular = usuarioLINQ.Celular,
                                     FechaNacimiento = usuarioLINQ.FechaNacimiento,
                                     CURP = usuarioLINQ.CURP,
                                     IdRol = usuarioLINQ.IdRol,
                                     RolNombre = rolLINQ.Nombre
                                 });

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {

                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = item.IdUsuario;
                            usuario.UserName = item.UserName;
                            usuario.Nombre = item.Nombre;
                            usuario.ApellidoPaterno = item.ApellidoPaterno;
                            usuario.ApellidoMaterno = item.ApellidoMaterno;
                            usuario.Email = item.Email;
                            usuario.Password = item.Password;
                            usuario.Sexo = item.Sexo;
                            usuario.Telefono = item.Telefono;
                            usuario.Celular = item.Celular;
                            usuario.FechaNacimiento = item.FechaNacimiento.ToString();
                            usuario.CURP = item.CURP;

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = (int)item.IdRol;
                            usuario.Rol.Nombre = item.RolNombre;


                            result.Correct = true;
                            result.Objects.Add(usuario);
                        }
                    }
                }
            }
            catch (Exception  ex)
            {
                result.Correct = false;
                result.Ex =ex;
                result.ErrorMessage = ex.Message;
               // throw;
            }
            return result;
        }
        public static ML.Result GetByIdLINQ(ML.Usuario usuario)
        {
            Result result = new ML.Result();
            try
            {
                using (DL_EF.AOranProgramacionNCapasEntities context = new DL_EF.AOranProgramacionNCapasEntities())
                {
                    var query = (from usuarioLINQ in context.Usuarios
                                 join rolLINQ in context.Rols on usuarioLINQ.Rol.IdRol equals rolLINQ.IdRol
                                 where usuarioLINQ.IdUsuario == usuario.IdUsuario
                                 select new
                                 {
                                     IdUsuario = usuarioLINQ.IdUsuario,
                                     UserName = usuarioLINQ.UserName,
                                     Nombre = usuarioLINQ.Nombre,
                                     ApellidoPaterno = usuarioLINQ.ApellidoPaterno,
                                     ApellidoMaterno = usuarioLINQ.ApellidoMaterno,
                                     Email = usuarioLINQ.Email,
                                     Password = usuarioLINQ.Password,
                                     Sexo = usuarioLINQ.Sexo,
                                     Telefono = usuarioLINQ.Telefono,
                                     Celular = usuarioLINQ.Celular,
                                     FechaNacimiento = usuarioLINQ.FechaNacimiento,
                                     CURP = usuarioLINQ.CURP,
                                     IdRol = usuarioLINQ.IdRol,
                                     RolNombre = rolLINQ.Nombre
                                 });

                    if (query != null)
                    {
                        //result.Objects = new List<object>();
                        //foreach (var item in query)
                        //{
                        var item = query.FirstOrDefault();
                            usuario.IdUsuario = item.IdUsuario;
                            usuario.UserName = item.UserName;
                            usuario.Nombre = item.Nombre;
                            usuario.ApellidoPaterno = item.ApellidoPaterno;
                            usuario.ApellidoMaterno = item.ApellidoMaterno;
                            usuario.Email = item.Email;
                            usuario.Password = item.Password;
                            usuario.Sexo = item.Sexo;
                            usuario.Telefono = item.Telefono;
                            usuario.Celular = item.Celular;
                            usuario.FechaNacimiento = item.FechaNacimiento.ToString();
                            usuario.CURP = item.CURP;

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = (int)item.IdRol;
                            usuario.Rol.Nombre = item.RolNombre;


                            result.Correct = true;
                            result.Object = usuario;
                            //result.Objects.Add(usuario);
                        //}
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
