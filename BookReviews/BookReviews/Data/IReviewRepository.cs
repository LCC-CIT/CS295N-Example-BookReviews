using BookReviews.Models;

namespace BookReviews.Data
{
    public interface IReviewRepository
    {
        public Review GetReviewById(int id);
    }
}
