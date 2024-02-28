using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Direccion
    {
        public int? IdDireccion { get; set; }
        [DisplayName("Colonia:")]
        public ML.Colonia Colonia { get; set; }
        [Required][DisplayName("Calle:")]
        public string Calle { get; set; }
        [Required][DisplayName("Numero Externo:")]
        public string NumeroExterno { get; set; }
        [DisplayName("Numero Interno:")]
        public string NumeroInterno { get; set; }
        

    }
}
