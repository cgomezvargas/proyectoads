//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Website.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            this.REQUISICIONs = new HashSet<REQUISICION>();
            this.REQUISICIONs1 = new HashSet<REQUISICION>();
            this.REQUISICIONs2 = new HashSet<REQUISICION>();
        }
    
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string CORREO { get; set; }
        public int ID_ROL { get; set; }
        public string USUARIO1 { get; set; }
        public string CONTRASENNA { get; set; }
        public Nullable<int> ID_JEFE_APROBADOR { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REQUISICION> REQUISICIONs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REQUISICION> REQUISICIONs1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REQUISICION> REQUISICIONs2 { get; set; }
        public virtual ROL ROL { get; set; }
    }
}