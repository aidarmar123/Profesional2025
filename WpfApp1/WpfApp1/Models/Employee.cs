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

    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Comments = new HashSet<Comments>();
            this.Department = new HashSet<Department>();
            this.Department1 = new HashSet<Department>();
            this.Event = new HashSet<Event>();
            this.EventEmployee = new HashSet<EventEmployee>();
            this.Material = new HashSet<Material>();
            this.PrimaryPersonsEvent = new HashSet<PrimaryPersonsEvent>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronic { get; set; }
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
        
        public string WorkPhone { get; set; }
        public string HomePhone { get; set; }
        public int CabinetId { get; set; }
        public string Email { get; set; }
        public System.DateTime Birthday { get; set; }= DateTime.Now;
        public string AdditionalInformation { get; set; }
        public Nullable<System.DateTime> DateDismissal { get; set; }
        [JsonIgnore]
        public virtual Cabinet Cabinet
        {
            get
            {
                return DbContext.Cabinets.FirstOrDefault(x => x.Id == CabinetId);
            }
            set
            {
                CabinetId = value.Id;
            }

        }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comments> Comments { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Department> Department { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Department> Department1 { get; set; }
        
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Event { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventEmployee> EventEmployee { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Material> Material { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrimaryPersonsEvent> PrimaryPersonsEvent { get; set; }
    }
}