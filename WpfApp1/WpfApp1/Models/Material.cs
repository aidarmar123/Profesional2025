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

    public partial class Material
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Material()
        {
            this.Comments = new HashSet<Comments>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime DateCreate { get; set; }
        public System.DateTime DateUpdate { get; set; }
        public int StatusMaterialId { get; set; }
        public int TypeMaterialId { get; set; }
        [JsonIgnore]
        public virtual TypeMaterial TypeMaterial
        {
            get
            {
            return DbContext.TypeMaterials.FirstOrDefault(x=>x.Id == TypeMaterialId);
            }
            set
            {
                TypeMaterialId = value.Id;
            }
    
        }
        
        public int PositionMaterialId { get; set; }
        [JsonIgnore]
        public virtual PositionMaterial PositionMaterial
        {
            get
            {
            return DbContext.PositionMaterials.FirstOrDefault(x=>x.Id == PositionMaterialId);
            }
            set
            {
                PositionMaterialId = value.Id;
            }
    
        }
        
        public int AuthorId { get; set; }
        [JsonIgnore]
        public virtual Employee Author
        {
            get
            {
            return DbContext.Employees.FirstOrDefault(x=>x.Id == AuthorId);
            }
            set
            {
                AuthorId = value.Id;
            }
    
        }
        
    
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual Employee Employee { get; set; }
        
        public virtual StatusMaterial StatusMaterial { get; set; }
        
    }
}