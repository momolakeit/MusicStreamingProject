using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
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
   
    public class UtilisateursController : ApiController
    {
        private MusiqueStreamingBackend db = new MusiqueStreamingBackend();

        // GET: api/Utilisateurs
        public IQueryable<Utilisateur> GetUtilisateurs()
        {
            return db.Utilisateurs;
        }

        // GET: api/Utilisateurs/5
        [ResponseType(typeof(UtilisateurLight))]
        public IHttpActionResult GetUtilisateur(int id)
        {
            var utilisateur = Utilitaire.UtilisateurUtilitaire.getUtilisateur(id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            return Ok(utilisateur);
        }

        [Route("api/Utilisateurs/getUtilisateurByAlbumId/{id}")]
        [HttpGet]
        public IHttpActionResult getUtilisateurByAlbumId(int id)
        {
            var utilisateur = Utilitaire.UtilisateurUtilitaire.getUtilisateurByAlbumId(id);
            return Ok( utilisateur);

        }
        // PUT: api/Utilisateurs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUtilisateur(int id, UtilisateurUpdate utilisateur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = Utilitaire.UtilisateurUtilitaire.putUtilisateur(id, utilisateur);
            if (user==null)
            {
                return NotFound();
            }

            return Ok();
        }

        // POST: api/Utilisateurs
        [ResponseType(typeof(Utilisateur))]
        public IHttpActionResult PostUtilisateur()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           

            var user = Utilitaire.UtilisateurUtilitaire.postUtilisateur();


            if (user != null)
            {
                Utilitaire.UtilisateurUtilitaire.uploadImg(user.id);
                
            }
            else
            {
                return BadRequest("L'utilisateur existe déja");
            }
            
            return  Ok(user);
                
            

        }
        [Route("api/Utilisateurs/UploadUserImg/{id}")]
        [HttpPost]
        public IHttpActionResult PostImgUtilisateur(int id)
        {
            Utilitaire.UtilisateurUtilitaire.uploadImg(id);

            return Ok(Utilitaire.UtilisateurUtilitaire.getUtilisateur(id));
        }


        [Route("api/Utilisateurs/Connection")]
        [HttpPost]
        public IHttpActionResult Connection(Connection connection)
            {
            
            var utilisateur = Utilitaire.UtilisateurUtilitaire.Connection(connection);
            if (utilisateur==null)
            {
                return BadRequest("Utilisateur non trouvé");
            }
            else
            {
                return Ok(utilisateur);
            }
            
        }
        // DELETE: api/Utilisateurs/5
        [ResponseType(typeof(Utilisateur))]
        public IHttpActionResult DeleteUtilisateur(int id)
        {
            var user = Utilitaire.UtilisateurUtilitaire.deleteUtilisateur(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UtilisateurExists(int id)
        {
            return db.Utilisateurs.Count(e => e.id == id) > 0;
        }
    }
}