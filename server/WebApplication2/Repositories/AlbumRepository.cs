using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Repositories
{
    public class AlbumRepository
    {
        public IEnumerable<Album> GetAll()
        {
            using (var dbContext = new AppContext())
            {
                return dbContext.Albums.Include(a => a.songs).Include(a => a.reviews).ThenInclude(r => r.user).ToList(); //then include
            }

        }

        public Album GetById(int id)
        {
            using (var dbContext = new AppContext())
            {
                var query = dbContext.Albums.Include(a => a.songs).Include(a => a.reviews).Where(t => t.id == id);

                return query.FirstOrDefault<Album>();
            }
        }

        public void AddAlbum(Album value)
        {
            using (var dbContext = new AppContext())
            {
                dbContext.Albums.Add(value);

                dbContext.SaveChanges();
            }
        }

        public void EditAlbum(int id, Album album)
        {
            using (var dbContext = new AppContext())
            {
                var query = dbContext.Albums.Where(a => a.id == id).FirstOrDefault<Album>();

                if (query != null)
                {
                    query.title = album.title;
                    query.year = album.year;
                    query.songs = album.songs;
                    query.image = album.image;

                    dbContext.SaveChanges();
                }
            }
        }

        public void DeleteAlbum(int id)
        {
            using (var dbContext = new AppContext())
            {
                var query = dbContext.Albums.Where(a => a.id == id).FirstOrDefault<Album>();

                if (query != null)
                {
                    var songs = dbContext.Songs.Where(s => s.album_id == id);
                    var reviews = dbContext.Reviews.Where(s => s.album_id == id);

                    dbContext.Songs.RemoveRange(songs);
                    dbContext.SaveChanges();

                    dbContext.Reviews.RemoveRange(reviews);
                    dbContext.SaveChanges();

                    dbContext.Albums.Remove(query);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
