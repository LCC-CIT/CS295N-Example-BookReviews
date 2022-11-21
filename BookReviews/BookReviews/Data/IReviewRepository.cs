using BookReviews.Models;
using System.Linq;

namespace BookReviews.Data
{
    public interface IReviewRepository
    {
        public Review GetReviewById(int id);
        public int StoreReview(Review model);
        IQueryable<Review> Reviews { get; }  // Read (or retrieve) reviews
    }
}
