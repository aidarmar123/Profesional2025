using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Services;

namespace WpfApp1.Models.MetaData
{
    public partial class MetaEmployee
    {
       

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Patronic { get; set; }
        public int PositionId { get; set; }
        [JsonIgnore]
        [Required]
        public virtual Position Position
        {
            get
            {
                return DbContext.Positions.FirstOrDefault(x => x.Id == PositionId);
            }
            set
            {
                PositionId = value.Id;
            }

        }

        [Required]
        public string WorkPhone { get; set; }
        [Required]
        public string HomePhone { get; set; }
        public int CabinetId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public System.DateTime Birthday { get; set; } 
        public string AdditionalInformation { get; set; }
        public Nullable<System.DateTime> DateDismissal { get; set; }
        [JsonIgnore]
        [Required]
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
