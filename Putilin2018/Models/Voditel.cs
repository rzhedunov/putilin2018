//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Putilin2018.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Voditel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Voditel()
        {
            this.Рейс = new HashSet<Рейс>();
        }
    
        public int Id { get; set; }
        public string fio { get; set; }
        public System.DateTime license_expire { get; set; }
        public string categories { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Рейс> Рейс { get; set; }
    }
}
