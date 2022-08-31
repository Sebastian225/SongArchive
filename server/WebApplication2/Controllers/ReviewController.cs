using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private ReviewService _reviewService;

        public ReviewController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAllReviews()
        {
            return Ok(_reviewService.GetAllReviews());
        }

        [HttpGet]
        [Route("api/[controller]/album/{id}")]
        public IActionResult GetAllReviewsForAlbum(int id)
        {
            return Ok(_reviewService.GetAllReviewsForAlbum(id));
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetReviewById(int id)
        {
            var review = _reviewService.GetReviewById(id);

            if (review != null)
            {
                return Ok(review);
            }

            return NotFound("Review not found!");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddReview(Review review)
        {
            _reviewService.AddReview(review);

            return Ok();
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditReview(int id, Review review)
        {
            _reviewService.EditReview(id, review);

            return Ok(review);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteReview(int id)
        {
            _reviewService.DeleteReview(id);

            return Ok();
        }
    }
}

