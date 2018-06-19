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
    using System.ComponentModel.DataAnnotations;

    public partial class Ремонт
    {
        public int Id { get; set; }

        [Display(Name = "Дата заявки")]
        [DataType(DataType.Date)]
        public System.DateTime Дата_заявки { get; set; }
        public int АвтомобильID { get; set; }
        public string Содержание { get; set; }

        [Display(Name = "Дата выполнения")]
        [DataType(DataType.Date)]
        public System.DateTime Дата_выполнения { get; set; }

        [Display(Name = "Статус заявки")]
        public int Статус_заявкиID { get; set; }

        [Display(Name = "Стоимость")]
        public int Стоимость_ремонта { get; set; }
        public string Примечание { get; set; }

        [Display(Name = "Автомобиль")]
        public virtual Автомобиль Автомобиль { get; set; }

        [Display(Name = "Статус заявки")]
        public virtual Статус_заявки Статус_заявки { get; set; }
    }
}
