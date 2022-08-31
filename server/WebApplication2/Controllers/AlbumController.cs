using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private AlbumService _albumService;

        public AlbumController(AlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAllAlbums()
        {
            return Ok(_albumService.GetAllAlbums());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetAlbumById(int id)
        {
            var album = _albumService.GetAlbumById(id);

            if (album != null)
            {
                return Ok(album);
            }

            return NotFound("Album not found!");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddAlbum(Album album)
        {
            _albumService.AddAlbum(album);

            return Ok();
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditAlbum(int id, Album album)
        {
            _albumService.EditAlbum(id, album);

            return Ok(album);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteAlbum(int id)
        {
            _albumService.DeleteAlbum(id);

            return Ok();
        }
    }
}
