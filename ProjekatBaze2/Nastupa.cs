//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjekatBaze2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Nastupa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nastupa()
        {
            this.Nosnje = new HashSet<Nosnja>();
        }
    
        public int IgracID_IG { get; set; }
        public int KoncertID_KC { get; set; }
    
        public virtual Igrac Igrac { get; set; }
        public virtual Koncert Koncert { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nosnja> Nosnje { get; set; }

        public override string ToString()
        {
            return IgracID_IG.ToString() + "-" + KoncertID_KC.ToString();
        }
    }
}
