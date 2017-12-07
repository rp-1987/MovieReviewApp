namespace MovieReviews.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Critic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Critic()
        {
            CriticsPhotos = new HashSet<CriticsPhoto>();
            MovieReviews = new HashSet<MovieReview>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string CriticName { get; set; }

        [StringLength(100)]
        public string Publication { get; set; }

        public bool IsTopCritic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CriticsPhoto> CriticsPhotos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieReview> MovieReviews { get; set; }
    }
}
