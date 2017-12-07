namespace MovieReviews.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CriticsPhotos")]
    public partial class CriticsPhoto
    {
        public int Id { get; set; }

        public int CriticId { get; set; }

        public virtual Critic Critic { get; set; }
    }
}
