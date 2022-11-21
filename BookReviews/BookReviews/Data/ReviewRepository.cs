using BookReviews.Models;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace BookReviews.Data
{
    public class ReviewRepository : IReviewRepository
    {
        private ApplicationDbContext context;

        public ReviewRepository(ApplicationDbContext appDbContext)
        {
            context = appDbContext;
        }

        public Review GetReviewById(int id)
        {
            var review = context.Reviews
              .Include(review => review.Reviewer) // returns Reivew.AppUser object
              .Include(review => review.Book) // returns Review.Book object
              .Where(review => review.ReviewId == id)
              .SingleOrDefault();
            return review;
        }

        public int StoreReview(Review model)
        {
            model.ReviewDate = DateTime.Now;
            context.Reviews.Add(model);
            return context.SaveChanges();
            // returns a positive value if succussful
        }
    }
}
