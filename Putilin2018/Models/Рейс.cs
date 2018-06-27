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
    
    public partial class Рейс
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Рейс()
        {
            this.Пункты_рейса = new HashSet<Пункты_рейса>();
        }
    
        public int Id { get; set; }
        public string Номер_путевого_листа { get; set; }
        public System.DateTime Дата_рейса { get; set; }
        public int Остаток_ГСМ_на_въезде { get; set; }
        public int Выдано_ГСМ { get; set; }
        public int Нач_спидометр { get; set; }
        public int Норма { get; set; }
        public int Пробег { get; set; }
        public int Расход_ГСМ { get; set; }
        public int ВодительID { get; set; }
        public int ЗадачаID { get; set; }
        public int АвтомобильID { get; set; }
        public string Примечание { get; set; }
    
        public virtual Voditel Voditel { get; set; }
        public virtual Автомобиль Автомобиль { get; set; }
        public virtual Задача Задача { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Пункты_рейса> Пункты_рейса { get; set; }
    }
}
