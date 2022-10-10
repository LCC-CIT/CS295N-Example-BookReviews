using System;

namespace BookReviews.Models
{
    public class Review
    {
        public Book Book { get; set; }
        public AppUser Reviewer { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
