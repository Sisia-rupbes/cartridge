//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cartridge
{
    using System;
    using System.Collections.Generic;
    
    public partial class p000052
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public p000052()
        {
            this.p000053 = new HashSet<p000053>();
            this.p000054 = new HashSet<p000054>();
        }
    
        public int kod { get; set; }
        public int kod_p000049 { get; set; }
        public Nullable<int> kod_p000051 { get; set; }
    
        public virtual p000049 p000049 { get; set; }
        public virtual p000051 p000051 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<p000053> p000053 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<p000054> p000054 { get; set; }
    }
}
