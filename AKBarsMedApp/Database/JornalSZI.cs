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
    
    public partial class JornalSZI
    {
        public int id_szi { get; set; }
        public string Name { get; set; }
        public int id_typeszi { get; set; }
        public string Number { get; set; }
        public string Serificate { get; set; }
        public string HardwareNum { get; set; }
        public Nullable<System.DateTime> DateConnect { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }
        public int id_employee { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual TypeSZI TypeSZI { get; set; }
    }
}
