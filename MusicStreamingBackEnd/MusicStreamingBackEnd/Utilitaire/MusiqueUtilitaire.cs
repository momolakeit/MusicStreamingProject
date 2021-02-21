using MusicStreamingBackEnd.Models;
using MusicStreamingBackEnd.Models.DataModel;
using MusicStreamingBackEnd.Models.ViewModel;
using MusicStreamingBackEnd.Models.ViewModel.JsonAbbrege;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStreamingBackEnd.Utilitaire
{
    public static class MusiqueUtilitaire
    {

        public  static List<MusiqueLight>  searchMusique(string query)
        {
            MusiqueStreamingBackend db = new MusiqueStreamingBackend();
            List<MusiqueLight> musiqueRetour = new List<MusiqueLight>();
            //les musiques correspondant au searchquery par le nom
            List<Musique> musiqueSearched = new List<Musique>();
            //les musiques des album correspondant au searchquery par le nom
            List<Musique> musiqueSearchedByAlbum = new List<Musique>();
            //Liste des album correspondant au searchquery par le nom
            List<Album> AlbumSearch = new List<Album>();
            musiqueSearched = db.Musiques.Where(s=>s.NomMusique==query).ToList();

            AlbumSearch = db.Album.Where(s=>s.nomAlbum==query).ToList();

            foreach (Album album in AlbumSearch )
            {
                foreach (Musique mumu in album.Musiques)
                {
                    musiqueSearchedByAlbum.Add(mumu);
                }
            }
            //on elemine les doublons avec union
            musiqueSearched=musiqueSearched.Union(musiqueSearchedByAlbum).ToList();

            ///on simplifie les musiques
            foreach (Musique mumu in musiqueSearched)
            {
                musiqueRetour.Add(Utilitaire.JsonConstruction.buildMusiqueLight(mumu));
            }

            return musiqueRetour;

        }
        //enleve toute les musique de cet album
        public static void deleteAlbumMusic(int id, MusiqueStreamingBackend db)//recoit le id de l'album
        {
            var AlbumSongs = db.Musiques.Where(s => s.fkAlbumId == id);
            foreach (var x in AlbumSongs)
            {
             
                db.Musiques.Remove(x);
            }
           
        }
        public static MusiqueLight getMusique(int id)
        {
            MusiqueStreamingBackend db = new MusiqueStreamingBackend();
            var  musique =Utilitaire.JsonConstruction.buildMusiqueLight( db.Musiques.Find(id));
           
            return musique;
        }
        public static Musique putMusique(int id , MusiqueUpdate musique)
        {
            MusiqueStreamingBackend db = new MusiqueStreamingBackend();
            var musiqueUpdated = db.Musiques.Where(s=>s.id==id).FirstOrDefault();
            if (musiqueUpdated==null)
            {
                return musiqueUpdated;
            }
            musiqueUpdated.musicPath = musique.musicPath;
            musiqueUpdated.NomMusique = musique.nomMusique;
            db.SaveChanges();
            return musiqueUpdated;


        }
        public static   List< Musique> postMusique()
        {
            MusiqueStreamingBackend db = new MusiqueStreamingBackend();
            var data = HttpContext.Current.Request.Form[0];
            var albumInfo = HttpContext.Current.Request.Form[1];
            int albumId = Convert.ToInt32(albumInfo);
            List<Musique> musiques = JsonConvert.DeserializeObject<List<Musique>>(data);
            var album = db.Album.Where(s => s.id == albumId).FirstOrDefault();


            foreach (var musique in musiques)
            {
                album.Musiques.Add(musique);
                musique.Categorie = album.Categorie;
                db.Musiques.Add(musique);
            }
            db.SaveChanges();
            return musiques;
          
        }
        public static void uploadAudio(List<Musique> musiques)
        {
            MusiqueStreamingBackend db = new MusiqueStreamingBackend();
            int compteur = 0;//permet de savoir ou on est rendu dans musiques
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var url = "Fichier/Musique/";
                    //permet de donner un nom unique et random au fichier
                    Guid g = Guid.NewGuid();
                    string GuidString = Convert.ToBase64String(g.ToByteArray());
                    GuidString = GuidString.Replace("=", "");
                    GuidString = GuidString.Replace("+", "");
                    GuidString = GuidString.Replace(@"\", "");
                    GuidString = GuidString.Replace(@"/", "");


                  
                    var filePath = HttpContext.Current.Server.MapPath("~/" + url + GuidString + ".mp3");
                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);

                    ////on associe le son a la musique creer
                    var musiqueId = musiques[compteur].id;
                    var musique = db.Musiques.Where(s => s.id == musiqueId).FirstOrDefault();
                    musique.musicPath = url + GuidString+".mp3";
               
                    db.SaveChanges();
                    compteur = compteur + 1;

                }

            }



        }
        public static Musique deleteMusique(int id)
        {
            MusiqueStreamingBackend db = new MusiqueStreamingBackend();
            Musique musique = db.Musiques.Find(id);
            if (musique == null)
            {
                return musique;
            }

            db.Musiques.Remove(musique);
            db.SaveChanges();
            return musique;
        }
    }
}