//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MovieReviews.AdminUI
{
    using System;
    using System.Collections.Generic;
    
    public partial class Critic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Critic()
        {
            this.CriticsPhotos = new HashSet<CriticsPhoto>();
            this.MovieReviews = new HashSet<MovieReview>();
        }
    
        public int Id { get; set; }
        public string CriticName { get; set; }
        public string Publication { get; set; }
        public bool IsTopCritic { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CriticsPhoto> CriticsPhotos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieReview> MovieReviews { get; set; }
    }
}
