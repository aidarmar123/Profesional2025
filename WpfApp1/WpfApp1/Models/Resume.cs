//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1.Models
{
    using System;
 	 using Newtonsoft.Json; 
 	 using System.Linq;
    using System.Collections.Generic;
    using WpfApp1.Services;

    public partial class Resume
    {
        public int Id { get; set; }
        public int PositionId { get; set; }
        [JsonIgnore]
        public virtual Position Position
        {
            get
            {
            return DbContext.Positions.FirstOrDefault(x=>x.Id == PositionId);
            }
            set
            {
                PositionId = value.Id;
            }
    
        }
        
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateUpdate { get; set; }
        public byte[] ResumeDoc { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronic { get; set; }
    
        
    }
}
