using MusicStreamingBackEnd.Models;
using MusicStreamingBackEnd.Models.DataModel;
using MusicStreamingBackEnd.Models.ViewModel.JsonAbbrege;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStreamingBackEnd.Utilitaire
{
    /// <summary>
    /// ///Permet de construire les objects json simplifie
    /// </summary>
    public static class JsonConstruction
    {
        public static AlbumLight buildAlbumLight(Album album)
        {
            AlbumLight albumLight = Utilitaire.JsonSimplification.albumToAlbumLight(album);
            albumLight.Musiques = new List<MusiqueLight>();
            albumLight.Utilisateur = new UtilisateurLight();
            foreach (var musique in album.Musiques)
            {
                albumLight.Musiques.Add(Utilitaire.JsonConstruction.buildMusiqueLight(musique));
            }
            albumLight.Utilisateur = Utilitaire.JsonSimplification.utilisateurToUtilisateurLight(album.Utilisateur);
            albumLight.Categorie = Utilitaire.JsonSimplification.categorieToCategorieLight(album.Categorie);
            return albumLight;
        }
        public static CategorieLight buildCategorieLight(Categorie categorie)
        {
            CategorieLight categorieLight = new CategorieLight();
            categorieLight = JsonSimplification.categorieToCategorieLight(categorie);
            categorieLight.Albums = new List<AlbumLight>();
            categorieLight.Musiques = new List<MusiqueLight>();
            foreach (var album in categorie.Albums)
            {
                categorieLight.Albums.Add(Utilitaire.JsonSimplification.albumToAlbumLight(album));
               
            }
            
            foreach (var musique in categorie.Musiques)
            {
                
                categorieLight.Musiques.Add(Utilitaire.JsonSimplification.musiqueToMusiqueLight(musique));
            }

            return categorieLight;
        }
        public static MusiqueLight buildMusiqueLight(Musique musique)
        {
            MusiqueLight musiqueLight = new MusiqueLight();
            musiqueLight = JsonSimplification.musiqueToMusiqueLight(musique);
            musiqueLight.album = Utilitaire.JsonSimplification.albumToAlbumLight(musique.album);
            musiqueLight.Categorie = Utilitaire.JsonSimplification.categorieToCategorieLight(musique.Categorie);
            return musiqueLight;
        }
        public static UtilisateurLight buildUtilisateurLight(Utilisateur utilisateur)
        {
            UtilisateurLight utilisateurLight = new UtilisateurLight();

            utilisateurLight = JsonSimplification.utilisateurToUtilisateurLight(utilisateur);
            utilisateurLight.albums = new List<AlbumLight>();
           

            utilisateurLight.musiques = new List<MusiqueLight>();

            foreach (var album in utilisateur.albums)
            {
                utilisateurLight.albums.Add(Utilitaire.JsonSimplification.albumToAlbumLight(album));


                foreach (var mumu in album.Musiques)
                {
                    var laMumu = Utilitaire.JsonConstruction.buildMusiqueLight(mumu);
                    laMumu.album = Utilitaire.JsonSimplification.albumToAlbumLight(album);
                    utilisateurLight.musiques.Add(laMumu);
                }
                
            }
            return utilisateurLight;
           
        }
        
    }
}