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
    
    public partial class Автомобиль
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Автомобиль()
        {
            this.Рейс = new HashSet<Рейс>();
            this.Ремонт = new HashSet<Ремонт>();
        }
    
        public int Id { get; set; }
        public string Название_автомобиля { get; set; }
        public string Госномер { get; set; }
        public string Примечание { get; set; }
        public int Тип_ТСID { get; set; }
    
        public virtual Тип_ТС Тип_ТС { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Рейс> Рейс { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ремонт> Ремонт { get; set; }
    }
}
