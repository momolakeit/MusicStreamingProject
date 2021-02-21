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
using Newtonsoft.Json.Linq;

namespace MusicStreamingBackEnd.Controllers
{
   
    public class MusiquesController : ApiController
    {
        private MusiqueStreamingBackend db = new MusiqueStreamingBackend();

        // GET: api/Musiques
        public IQueryable<Musique> GetMusiques()
        {
            return db.Musiques;
        }

        

        // GET: api/Musiques/5
        [ResponseType(typeof(MusiqueLight))]
        public IHttpActionResult GetMusique(int id)
        {
            var musique = Utilitaire.MusiqueUtilitaire.getMusique(id);
            if (musique == null)
            {
                return NotFound();
            }

            return Ok(musique);
        }

        // PUT: api/Musiques/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMusique(int id, MusiqueUpdate musique)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var musiqueUpdated = Utilitaire.MusiqueUtilitaire.putMusique( id,  musique);
            if (musiqueUpdated==null)
            {
                return NotFound();
            }
           

            return Ok();
        }

        [Route("api/Musiques/SearchMusique/")]
        [HttpPost]
        public IHttpActionResult SearchMusique(HttpRequestMessage searchQuery)
        {
            JObject jObj = JObject.Parse(searchQuery.Content.ReadAsStringAsync().Result);               
            string copyRef = jObj["searchQuery"].ToString();
            var musique = Utilitaire.MusiqueUtilitaire.searchMusique(copyRef);
            if (musique == null)
            {
                return NotFound();
            }
            
            return Ok(musique);
        }


        [Route("api/Musiques/UploadAlbumListe/{id}")]
        [HttpPost]
        public IHttpActionResult UploadAlbumImg(int id)
        {
            Utilitaire.AlbumUtilitaire.uploadImg(id);

            return Ok(Utilitaire.AlbumUtilitaire.getAlbum(id));
        }

        // POST: api/Musiques
        [ResponseType(typeof(Musique))]
        public IHttpActionResult PostMusique()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var musiques=Utilitaire.MusiqueUtilitaire.postMusique();
            Utilitaire.MusiqueUtilitaire.uploadAudio(musiques);
            return Ok(musiques[0].fkAlbumId);
        }

        


        // DELETE: api/Musiques/5
        [ResponseType(typeof(Musique))]
        public IHttpActionResult DeleteMusique(int id)
        {
            var musique = Utilitaire.MusiqueUtilitaire.deleteMusique(id);
            if (musique==null)
            {
                return NotFound();
            }
            return Ok(musique);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MusiqueExists(int id)
        {
            return db.Musiques.Count(e => e.id == id) > 0;
        }
    }
}