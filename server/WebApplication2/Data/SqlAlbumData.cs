using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Data
{
    public class SqlAlbumData : IAlbumData
    {
        private AppContext _appContext;

        public SqlAlbumData(AppContext appContext)
        {
            _appContext = appContext;
        }

        void IAlbumData.AddAlbum(Album album)
        {
            _appContext.Albums.Add(album);
            _appContext.SaveChanges();
        }

        void IAlbumData.DeleteAlbum(Album album)
        {
            _appContext.Albums.Remove(album);
            _appContext.SaveChanges();
        }

        Album IAlbumData.EditAlbum(int id, Album album)
        {
            var query = _appContext.Albums.Where(a => a.id == id).FirstOrDefault<Album>();
            
            if(query != null)
            {
                query.title = album.title;
                //query = album;
                //_appContext.Albums.Update(album);
                _appContext.SaveChanges();
            }
            query = _appContext.Albums.Where(a => a.id == id).FirstOrDefault<Album>();
            return album;
        }

        Album IAlbumData.GetAlbum(int id)
        {
            return _appContext.Albums.Find(id);
        }

        List<Album> IAlbumData.GetAlbums()
        {
            return _appContext.Albums.ToList();
        }
    }
}
