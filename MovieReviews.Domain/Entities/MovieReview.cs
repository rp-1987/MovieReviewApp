namespace MovieReviews.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MovieReview
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public int CriticId { get; set; }

        [Required]
        [StringLength(5000)]
        public string ReviewSynopsis { get; set; }

        public bool IsGood { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ReviewRatingNum { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ReviewRatingDen { get; set; }

        [StringLength(500)]
        public string ReviewUrl { get; set; }

        public virtual Critic Critic { get; set; }

        public virtual Movy Movy { get; set; }
    }
}
