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
using MusicStreamingBackEnd.Models.DataModel;
using MusicStreamingBackEnd.Models.ViewModel;
using System.Web.Http.Cors;
using MusicStreamingBackEnd.Models.ViewModel.JsonAbbrege;

namespace MusicStreamingBackEnd.Controllers
{
    
    public class CategoriesController : ApiController
    {
        private MusiqueStreamingBackend db = new MusiqueStreamingBackend();

        // GET: api/Categories
        public IQueryable<Categorie> GetCategories()
        {
            return db.Categories;
        }

        [Route("api/Categories/GetFeaturedCategorie")]
        [HttpGet]
        public IHttpActionResult GetFeaturedCategorie()
        {
            
            return Ok(Utilitaire.CategorieUtilitaire.GetFeaturedCategorie());
        }

        // GET: api/Categories/5
        [ResponseType(typeof(CategorieLight))]
        public IHttpActionResult GetCategorie(int id)
        {
            var  categorie = Utilitaire.CategorieUtilitaire.GetCategorie(id);
            if (categorie == null)
            {
                return NotFound();
            }

            return Ok(categorie);
        }
        [Route("api/Categories/geAllGategorieName/")]
        [HttpGet]
        public IHttpActionResult allCategorieName()
        {
            return Ok(Utilitaire.CategorieUtilitaire.allCategorieName());
        }
        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategorie(int id, CategorieUpdate categorie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categorieUpdated = Utilitaire.CategorieUtilitaire.PutCategorie(id, categorie);
            if (categorieUpdated==null)
            {
                return NotFound();
            }
           

            return Ok();
        }

        // POST: api/Categories
        [ResponseType(typeof(Categorie))]
        public IHttpActionResult PostCategorie(Categorie categorie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Utilitaire.CategorieUtilitaire.PostCategorie(categorie);
            return Ok();
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Categorie))]
        public IHttpActionResult DeleteCategorie(int id)
        {
            return Ok(Utilitaire.CategorieUtilitaire.DeleteCategorie(id));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategorieExists(int id)
        {
            return db.Categories.Count(e => e.id == id) > 0;
        }
    }
}