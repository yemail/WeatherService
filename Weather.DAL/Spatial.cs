//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Weather.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Spatial
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Spatial()
        {
            this.Location_Aware_Message = new HashSet<Location_Aware_Message>();
            this.Weathers = new HashSet<Weather>();
        }
    
        public int Spatial_Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public System.Data.Entity.Spatial.DbGeography GeoLocation { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Location_Aware_Message> Location_Aware_Message { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Weather> Weathers { get; set; }
    }
}
