using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Municipio
    {
        public int? IdMunicipio { get; set; }
        public string NombreMunicipio {  set; get; }
        [DisplayName("Estado:")]
        public ML.Estado Estado { get; set; }
        public List<object> Municipios { get; set;}
    }
}
