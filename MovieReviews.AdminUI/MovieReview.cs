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
    
    public partial class MovieReview
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int CriticId { get; set; }
        public string ReviewSynopsis { get; set; }
        public bool IsGood { get; set; }
        public decimal ReviewRatingNum { get; set; }
        public decimal ReviewRatingDen { get; set; }
        public string ReviewUrl { get; set; }
    
        public virtual Critic Critic { get; set; }
        public virtual Movy Movy { get; set; }
    }
}
