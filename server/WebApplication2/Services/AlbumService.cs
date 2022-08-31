using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Repositories;

namespace WebApplication2.Services
{
    public class AlbumService
    {
        private AlbumRepository _albumRepo;

        public AlbumService(AlbumRepository albumRepo)
        {
            _albumRepo = albumRepo;
        }
        public IEnumerable<Album> GetAllAlbums()
        {
            return _albumRepo.GetAll();
        }

        public Album GetAlbumById(int id)
        {
            return _albumRepo.GetById(id);
        }

        public void EditAlbum(int id, Album album)
        {
            _albumRepo.EditAlbum(id, album);
        }

        public void AddAlbum(Album album)
        {
            _albumRepo.AddAlbum(album);

        }

        public void DeleteAlbum(int id)
        {
            _albumRepo.DeleteAlbum(id);

        }
    }
}
