using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Services
{
    public class ReviewService
    {
        private ReviewRepository _reviewRepo;

        public ReviewService(ReviewRepository reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }
        public IEnumerable<Review> GetAllReviews()
        {
            return _reviewRepo.GetAll();
        }

        public IEnumerable<Review> GetAllReviewsForAlbum(int albumId)
        {
            var reviews =  _reviewRepo.GetAll().Where(r => r.album_id == albumId);

            return reviews;
        }

        public Review GetReviewById(int id)
        {
            return _reviewRepo.GetById(id);
        }

        public void EditReview(int id, Review review)
        {
            _reviewRepo.EditReview(id, review);
        }

        public void AddReview(Review review)
        {
            _reviewRepo.AddReview(review);

        }

        public void DeleteReview(int id)
        {
            _reviewRepo.DeleteReview(id);

        }
    }
}
