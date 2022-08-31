using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class ReviewRepository
    {
        public IEnumerable<Review> GetAll()
        {
            using (var dbContext = new AppContext())
            {
                return dbContext.Reviews.Include(r => r.album).Include(r => r.user).ToList();
            }

        }

        public Review GetById(int id)
        {
            using (var dbContext = new AppContext())
            {
                var query = dbContext.Reviews.Include(a => a.album).Include(r => r.user).Where(t => t.id == id);

                return query.FirstOrDefault<Review>();
            }
        }

        public void AddReview(Review value)
        {
            using (var dbContext = new AppContext())
            {
                dbContext.Reviews.Add(value);

                dbContext.SaveChanges();
            }
        }

        public void EditReview(int id, Review review)
        {
            using (var dbContext = new AppContext())
            {
                var query = dbContext.Reviews.Where(r => r.id == id).FirstOrDefault<Review>();

                if (query != null)
                {
                    query.title = review.title;
                    query.description = review.description;
                    query.rating = review.rating; //nu poti schimba albumul pentru care faci review
                    query.album = review.album; //si nici userul care a facut review
                    query.user = review.user;

                    dbContext.SaveChanges();
                }
            }
        }

        public void DeleteReview(int id)
        {
            using (var dbContext = new AppContext())
            {
                var query = dbContext.Reviews.Where(r => r.id == id).FirstOrDefault<Review>();

                if (query != null)
                {
                    dbContext.Reviews.Remove(query);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}

