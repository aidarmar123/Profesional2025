//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoatOfRussiaWebApp.Models
{
    using System;
	using Newtonsoft.Json;
    using System.Collections.Generic;
    
    public partial class WorkingCalendar
    {
        public long Id { get; set; }
        public System.DateTime ExceptionDate { get; set; }
        public bool IsWorkingDay { get; set; }
    }
}