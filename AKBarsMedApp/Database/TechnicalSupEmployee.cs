//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AKBarsMedApp.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class TechnicalSupEmployee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TechnicalSupEmployee()
        {
            this.JournalECP = new HashSet<JournalECP>();
        }
    
        public int id_tecsupemp { get; set; }
        public string FullName { get; set; }
        public string TelephNumber { get; set; }
        public string Email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JournalECP> JournalECP { get; set; }
    }
}
