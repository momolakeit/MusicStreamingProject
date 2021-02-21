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
    /// Permet de simplifier le json des different modele afin d'éviter que entity framework rendent le json trop lourd
    /// </summary>
    public static class JsonSimplification
    {

        public static AlbumLight albumToAlbumLight(Album  album)
        {
            AlbumLight albumLight = new AlbumLight();
            albumLight.id = album.id;
            albumLight.nomAlbum = album.nomAlbum;
            albumLight.albumImgPath = album.albumImgPath;
            albumLight.albumPath = album.albumPath;
            albumLight.fkCategorieId = album.fkCategorieId;
            albumLight.fkUtilisateurId = album.fkUtilisateurId;
            albumLight.Musiques = new List<MusiqueLight>();
            
            return albumLight;
        }
        public static CategorieLight categorieToCategorieLight(Categorie categorie)
        {
            CategorieLight categorieLight = new CategorieLight();
            categorieLight.id = categorie.id;
            categorieLight.Nom = categorie.Nom;
            
            return categorieLight;
        }
        public static MusiqueLight musiqueToMusiqueLight(Musique musique)
        {
            MusiqueLight musiqueLight = new MusiqueLight();
            musiqueLight.id = musique.id;
            musiqueLight.musicPath = musique.musicPath;
            musiqueLight.fkAlbumId = musique.fkAlbumId;
            musiqueLight.fkCategorieId = musique.fkCategorieId;
            musiqueLight.NomMusique = musique.NomMusique;
            musiqueLight.albumImgPath = musique.album.albumImgPath;
           
            return musiqueLight;
        }
        public static UtilisateurLight utilisateurToUtilisateurLight(Utilisateur utilisateur)
        {
            UtilisateurLight utilisateurLight = new UtilisateurLight();
            utilisateurLight.id = utilisateur.id;
            utilisateurLight.photoProfil = utilisateur.photoProfil;
            utilisateurLight.Email = utilisateur.Email;
            utilisateur.surnomArtiste = utilisateur.surnomArtiste;
            return utilisateurLight;
        }
    }
}