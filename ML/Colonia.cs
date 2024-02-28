using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    
    public class Colonia
    {
        [Required]
        [DisplayName("Colonia:")]
        public int? IdColonia { get; set; }

        public string NombreColonia { get; set;}
        public string CodigoPostal { get; set;}
        [DisplayName("Municipio:")]
        public ML.Municipio Municipio { get; set; }
        public List<object> Colonias { get; set; }
    }
}
