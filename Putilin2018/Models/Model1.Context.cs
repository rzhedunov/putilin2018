﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MyDatabaseEntities : DbContext
    {
        public MyDatabaseEntities()
            : base("name=MyDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Voditel> Voditel { get; set; }
        public virtual DbSet<Группы_задач> Группы_задач { get; set; }
        public virtual DbSet<Получатель> Получатель { get; set; }
        public virtual DbSet<Пункт_доставки> Пункт_доставки { get; set; }
        public virtual DbSet<Тип_ТС> Тип_ТС { get; set; }
        public virtual DbSet<Задача> Задача { get; set; }
        public virtual DbSet<Автомобиль> Автомобиль { get; set; }
        public virtual DbSet<Маршрут> Маршрут { get; set; }
        public virtual DbSet<Пункты_регулярного_маршрута> Пункты_регулярного_маршрута { get; set; }
        public virtual DbSet<Рейс> Рейс { get; set; }
        public virtual DbSet<Ремонт> Ремонт { get; set; }
        public virtual DbSet<Статус_заявки> Статус_заявки { get; set; }
    }
}
