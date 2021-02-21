using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MusicStreamingBackEnd.Models;
using MusicStreamingBackEnd.Models.DataModel;
using MusicStreamingBackEnd.Models.ViewModel;
using System.Web.Http.Cors;
using MusicStreamingBackEnd.Models.ViewModel.JsonAbbrege;
using System.Web;
using Newtonsoft.Json;

namespace MusicStreamingBackEnd.Controllers
{
    
    public class AlbumsController : ApiController
    {
        private MusiqueStreamingBackend db = new MusiqueStreamingBackend();

        // GET: api/Albums
        public IQueryable<Album> GetAlbum()
        {
            return db.Album;
        }





        [Route("api/Albums/GetFeaturedAlbum")]
        [HttpGet]
        
        //permet de remplir le carousel principale de la premiere page
        public List<AlbumLight> GetFeaturedAlbum()
        {
            
            return Utilitaire.AlbumUtilitaire.getFeaturedAlbum();
        }

        // GET: api/Albums/5
        [ResponseType(typeof(Album))]
        public IHttpActionResult GetAlbum(int id)
        {
            var album = Utilitaire.AlbumUtilitaire.getAlbum(id);
            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
        }

        // PUT: api/Albums/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAlbum(int id, AlbumUpdate album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var albumUdpated = Utilitaire.AlbumUtilitaire.putAlbum(id, album);
            if (albumUdpated==null)
            {
                return NotFound();
            }
            return Ok();
        }

        // POST: api/Albums
        [ResponseType(typeof(Album))]
        [HttpPost]
        //on recupere le utilisateur id afin de pouvoir associer lalbum a lutilisateur
        public IHttpActionResult PostAlbum()
        {
           
            var album=Utilitaire.AlbumUtilitaire.postAlbum();
            Utilitaire.AlbumUtilitaire.uploadImg(album.id);

            return Ok(album.id);
        }
        [Route("api/Albums/UploadAlbumImg/{id}")]
        [HttpPost]
        public IHttpActionResult UploadAlbumImg(int id)
        {
            Utilitaire.AlbumUtilitaire.uploadImg(id);

            return Ok(Utilitaire.AlbumUtilitaire.getAlbum(id));
        }
        // DELETE: api/Albums/5
        [ResponseType(typeof(Album))]
        public IHttpActionResult DeleteAlbum(int id)
        {
            var album = Utilitaire.AlbumUtilitaire.deleteAlbum(id);
            if (album == null)
            {
                return NotFound();
            }
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlbumExists(int id)
        {
            return db.Album.Count(e => e.id == id) > 0;
        }
    }
}