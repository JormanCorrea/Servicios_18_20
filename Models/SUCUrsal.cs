//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Servicios_18_20.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class SUCUrsal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SUCUrsal()
        {
            this.EMpleadoCArgoes = new HashSet<EMpleadoCArgo>();
        }
    
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string NitSupermercado { get; set; }
        public int CodigoCiudad { get; set; }

        [JsonIgnore]
        public virtual CIUDad CIUDad { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMpleadoCArgo> EMpleadoCArgoes { get; set; }
        [JsonIgnore]
        public virtual SUPErmercado SUPErmercado { get; set; }
    }
}
