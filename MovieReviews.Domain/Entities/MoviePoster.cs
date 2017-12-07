namespace MovieReviews.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MoviePoster
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public virtual Movy Movy { get; set; }
    }
}
