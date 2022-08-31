using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Data
{
    public interface IAlbumData
    {
        List<Album> GetAlbums();

        Album GetAlbum(int id);

        void AddAlbum(Album album);

        Album EditAlbum(int id, Album album);

        void DeleteAlbum(Album album);
    }
}
