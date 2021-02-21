using MusicStreamingBackEnd.Models;
using MusicStreamingBackEnd.Models.DataModel;
using MusicStreamingBackEnd.Models.ViewModel;
using MusicStreamingBackEnd.Models.ViewModel.JsonAbbrege;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace MusicStreamingBackEnd.Utilitaire
{


    /// <summary>
    /// logique des controlleurs
    /// </summary>
    public static class AlbumUtilitaire
    {

    
       
        public static Album  deleteAlbum( int id)
        {
            MusiqueStreamingBackend db =new MusiqueStreamingBackend();
            Album album = db.Album.Find(id);
            if (album == null)
            {
                return album;
            }

            db.Album.Remove(album);
            
            Utilitaire.MusiqueUtilitaire.deleteAlbumMusic(id, db);
            db.SaveChanges();

            return album;
        }
        public static void deleteAlbumUtilisateur(int id, MusiqueStreamingBackend db)//recoit le id du user
        {
            var UsersAlbum = db.Album.Where(s => s.fkUtilisateurId == id).ToList();
            foreach (var x in UsersAlbum)
            {

                db.Album.Remove(x);
                Utilitaire.MusiqueUtilitaire.deleteAlbumMusic(x.id, db);
               
            }
            
         
            
        }
        public static void uploadImg(int albumId)
        {
            MusiqueStreamingBackend db = new MusiqueStreamingBackend();
           
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var url = "Fichier/AlbumPhoto/";
                    //permet de donner un nom unique et random au fichier
                    Guid g = Guid.NewGuid();
                    string GuidString = Convert.ToBase64String(g.ToByteArray());
                    GuidString = GuidString.Replace("=", "");
                    GuidString = GuidString.Replace("+", "");
                    GuidString = GuidString.Replace(@"\", "");
                    GuidString = GuidString.Replace(@"/", "");



                    var filePath = HttpContext.Current.Server.MapPath("~/" + url + GuidString + ".jpg");
                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);

                    ////on associe l'image a l'utlisateur creer
                    var album = db.Album.Where(s => s.id == albumId).FirstOrDefault();
                    album.albumImgPath = url + GuidString+".jpg";
                    db.SaveChanges();


                }

            }



        }

        public static Album postAlbum()
        {
            MusiqueStreamingBackend db = new MusiqueStreamingBackend();
            /////////comment faire pour se passer des chiffres pour ne pas a avoir predire la place des elements????????
            var data = HttpContext.Current.Request.Form[0];
            var userInfo= HttpContext.Current.Request.Form[1];
            var categorieName= HttpContext.Current.Request.Form[2];
            Album album = JsonConvert.DeserializeObject<Album>(data);
            int utilisateurId = Convert.ToInt32(userInfo);

            var utilisateur = db.Utilisateurs.Where(s => s.id ==utilisateurId).FirstOrDefault();
            var categorie = db.Categories.Where(s=>s.Nom==categorieName).FirstOrDefault();
            
            utilisateur.albums.Add(album);
            categorie.Albums.Add(album);
            db.Album.Add(album);
            db.SaveChanges();
            return album;


        }
        public static Album putAlbum(int id, AlbumUpdate album)
        {
            MusiqueStreamingBackend db = new MusiqueStreamingBackend();
            var albumToUpdate = db.Album.Where(s => s.id == id).FirstOrDefault();
            if (albumToUpdate==null)
            {
                return albumToUpdate;
            }
            albumToUpdate.nomAlbum = album.nomAlbum;
            albumToUpdate.albumImgPath = album.albumImgPath;

            db.SaveChanges();

            return albumToUpdate;
        }

        /// <summary>
        /// /////retourne des object json light pour sauter les complication de entity framework
        /// </summary>
        public static AlbumLight getAlbum(int id)
        {
            MusiqueStreamingBackend db = new MusiqueStreamingBackend();
            Album album = db.Album.Find(id);
           
            if (album == null)
            {
                return null;
            }
            var retour = Utilitaire.JsonConstruction.buildAlbumLight(album);
            return retour;
        }
        public static List<AlbumLight> getFeaturedAlbum()
        {
            MusiqueStreamingBackend db = new MusiqueStreamingBackend();

            List<Album> albumsChoisi = new List<Album>();
            List<AlbumLight> retour = new List<AlbumLight>();
            
            int i = 0;
            do
            {
                var idDeLalbum = new Random().Next(1, db.Album.Count() );
                //on trouve un album
                var featuredAlbum = db.Album.Where(x => x.id == idDeLalbum).FirstOrDefault();

                //on verifie si on a pas mis lalbum dans le retour
                if (albumsChoisi.Where(s => s.id == featuredAlbum.id).FirstOrDefault() == null)
                {
                    //albumsChoisi.Add(featuredAlbum);
                    retour.Add(Utilitaire.JsonConstruction.buildAlbumLight(featuredAlbum));
                    i++;
                }

            } while (i < 3);

            return retour;
        }
    }
}