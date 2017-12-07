namespace MovieReviews.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Movy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Movy()
        {
            MoviePosters = new HashSet<MoviePoster>();
            MovieReviews = new HashSet<MovieReview>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string MovieName { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [StringLength(10)]
        public string Rating { get; set; }

        [StringLength(200)]
        public string Director { get; set; }

        [StringLength(200)]
        public string Studio { get; set; }

        [StringLength(5000)]
        public string Synopsis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MoviePoster> MoviePosters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieReview> MovieReviews { get; set; }

       
    }
}
