using MusicStreamingBackEnd.Models.DataModel;
using MusicStreamingBackEnd.Models.ViewModel;
using MusicStreamingBackEnd.Models.ViewModel.JsonAbbrege;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStreamingBackEnd.Utilitaire
{
    public static class CategorieUtilitaire
    {
        public static List<CategorieLight> GetFeaturedCategorie()
        {


            List<Categorie> categorieChoisi = new List<Categorie>();
            List<CategorieLight> categorieLightsChoisi = new List<CategorieLight>();
            MusiqueStreamingBackend db = new MusiqueStreamingBackend();
            int i = 0;
            do
            {
                var idDeLaCategorie = new Random().Next(1, db.Categories.Count() - 1);
                var featuredCategorie = db.Categories.Where(x => x.id == idDeLaCategorie).FirstOrDefault();

                if (categorieChoisi.Where(s => s.id == featuredCategorie.id).FirstOrDefault() == null)
                {
                    categorieChoisi.Add(featuredCategorie);
                    categorieLightsChoisi.Add(Utilitaire.JsonConstruction.buildCategorieLight(featuredCategorie));
                    i++;
                }

            } while (i < 2);
            return categorieLightsChoisi;
        }

        public static CategorieLight GetCategorie(int id)
        {
            MusiqueStreamingBackend db = new MusiqueStreamingBackend();
            var categorie = Utilitaire.JsonConstruction.buildCategorieLight(db.Categories.Find(id));
           
            return categorie;
        }

        public static List<string> allCategorieName()
        {
            MusiqueStreamingBackend db = new MusiqueStreamingBackend();
            List<string> categorieNames = new List<string>();
            List<Categorie> categories = db.Categories.ToList();
            foreach (var x in categories)
            {
                categorieNames.Add(x.Nom);
            }
            return categorieNames;
        }

        public static Categorie PutCategorie(int id, CategorieUpdate categorie)
        {
            MusiqueStreamingBackend db = new MusiqueStreamingBackend();

            var categorieUpdated = db.Categories.Where(s => s.id == id).FirstOrDefault();
            if (categorieUpdated != null)
            {
                categorieUpdated.Nom = categorie.nom;
                db.SaveChanges();
            }
          

            return categorieUpdated;
        }
        public static void PostCategorie(Categorie categorie)
        {
            MusiqueStreamingBackend db = new MusiqueStreamingBackend();
            db.Categories.Add(categorie);
            db.SaveChanges();
            var ii = db.Categories.ToList();
           
        }

        public static Categorie DeleteCategorie(int id)
        {
            MusiqueStreamingBackend db = new MusiqueStreamingBackend();
            Categorie categorie = db.Categories.Find(id);
            if (categorie != null)
            {
                db.Categories.Remove(categorie);
                var albumCategorie = db.Album.Where(s => s.fkCategorieId == id);

                foreach (var x in albumCategorie)
                {
                    Utilitaire.AlbumUtilitaire.deleteAlbum(x.id);

                };


                db.SaveChanges();

            }


            return categorie;
        }

    }
}