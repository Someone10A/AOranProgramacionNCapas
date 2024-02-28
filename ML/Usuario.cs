using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace ML
{
    public class Usuario
    {  
        public int IdUsuario { get; set; }

        [Required]
        [DisplayName("UserName:")]


        [RegularExpression(@"^[a-zA-Z0-9_.-]*$", ErrorMessage = "En este campo solo se aceptan Letras y numeros")]
        [StringLength(30,ErrorMessage ="Solo se aceptan menos de 30 caracteres")]
        public string UserName { get; set; }


        [Required]
        [DisplayName("Nombre:")]
        [RegularExpression(@"^([a-zA-ZáéíóúüÁÉÍÓÚÜñÑ]{2,60}[\,\-\.]{0,1}[\s]{0,1}){1,3}$", ErrorMessage = "En este campo solo se aceptan Letras")]
        [StringLength(30, ErrorMessage = "Solo se aceptan menos de 30 caracteres")]
        public string Nombre { get; set; }

        [Required]
        [DisplayName("Apellido Paterno:")]
        [RegularExpression(@"^([a-zA-ZáéíóúüÁÉÍÓÚÜñÑ]{1,60}[\,\-\.]{0,1}[\s]{0,1}){1,3}$", ErrorMessage = "En este campo solo se aceptan Letras")]
        [StringLength(30, ErrorMessage = "Solo se aceptan menos de 30 caracteres")]
        public string ApellidoPaterno { get; set; }

        [Required]
        [DisplayName("Apellido Materno:")]
        [RegularExpression(@"^([a-zA-ZáéíóúüÁÉÍÓÚÜñÑ]{1,60}[\,\-\.]{0,1}[\s]{0,1}){1,3}$", ErrorMessage = "En este campo solo se aceptan Letras")]
        [StringLength(30, ErrorMessage = "Solo se aceptan menos de 30 caracteres")]
        public string ApellidoMaterno { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Correo Electronico:")]

        [RegularExpression(@"/^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/", ErrorMessage ="Formato de correo no valido")]
        [StringLength(30, ErrorMessage = "Solo se aceptan menos de 30 caracteres")]
        public string Email { get; set; }


        [Required]
        [DisplayName("Contraseña:")]
        [RegularExpression(@"^.*(?=.{8,})(?=.*[a-zA-Z])(?=.*\d)(?=.*[!#$%&?]).*$",ErrorMessage ="Contraseña de 8-16 caracteres")]
        [PasswordPropertyText]
        public string Password { get;  set; }


        [Required]
        [DisplayName("Sexo:")]
        [RegularExpression(@"^[MF]+$",ErrorMessage ="Solo se acepta F o M")]
        [StringLength(1, ErrorMessage = "Solo se acepta 1 caracter")]
        public string Sexo {  get; set; }


        [Required]
        [DisplayName("Numero telefonico:")]
        [RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$",ErrorMessage ="Necesitas proporcionar un formato válido")]
        [MinLength(10,ErrorMessage ="No menos de 10 numeros"), MaxLength(13,ErrorMessage ="No más de 13 numeros")]
        public string Telefono {  get; set; }


        [Required]
        [DisplayName("Numero celular:")]
        [RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$", ErrorMessage = "Necesitas proporcionar un formato válido")]
        [MinLength(10, ErrorMessage = "No menos de 10 numeros"), MaxLength(13, ErrorMessage = "No más de 13 numeros")]
        public string Celular { get; set; }


        [Required]
        [DisplayName("Fecha de nacimiento:")]
        [RegularExpression(@"^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$", ErrorMessage ="Formato de fecha no valido")]
        public string FechaNacimiento { get; set; }


        [Required]
        [DisplayName("CURP:")]
        [RegularExpression(@"/^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$/",ErrorMessage ="Formato de CURP No VALIDO")]
        public string CURP { get; set; }

        public ML.Rol Rol {  get; set; }

        [DisplayName("Imagen:")]
        public byte[] Imagen {  get; set; }

        public bool Estatus {  get; set; }
        public int Accion {  get; set; }
       
        public List<object> Usuarios { get; set; }  

        public ML.Direccion Direccion { get; set; }
    }
}
