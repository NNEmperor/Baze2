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
    
    public partial class Pripada
    {
        public int SastavID_SS { get; set; }
        public int IgracID_IG { get; set; }
    
        public virtual Sastav Sastav { get; set; }
        public virtual Igrac Igrac { get; set; }
    }
}