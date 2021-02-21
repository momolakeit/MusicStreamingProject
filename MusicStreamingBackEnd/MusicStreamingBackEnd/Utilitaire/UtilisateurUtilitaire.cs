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
    public static class UtilisateurUtilitaire
    {
        public static UtilisateurLight getUtilisateur(int id)
        {
            MusiqueStreamingBackend db = new MusiqueStreamingBackend();
            UtilisateurLight utilisateur = Utilitaire.JsonConstruction.buildUtilisateurLight( db.Utilisateurs.Find(id));
            return utilisateur;
        }
        public static UtilisateurLight getUtilisateurByAlbumId(int id)
        {
            MusiqueStreamingBackend db = new MusiqueStreamingBackend();
            var utilisateur = Utilitaire.JsonConstruction.buildUtilisateurLight( db.Album.Where(s => s.fkUtilisateurId == id).FirstOrDefault().Utilisateur);
            return utilisateur;

        }
        public static Utilisateur putUtilisateur(int id, UtilisateurUpdate utilisateur)
        {
            MusiqueStreamingBackend db = new MusiqueStreamingBackend();

            var user = db.Utilisateurs.Where(s => s.id == id).FirstOrDefault();

            if (user == null)
            {
                return user;
            }
            user.Email = utilisateur.email;
            user.Password = utilisateur.password;
            user.photoProfil = utilisateur.photoProfil;

            db.SaveChanges();
            return user;
        }


        public static void uploadImg(int userId)
        {
            MusiqueStreamingBackend db = new MusiqueStreamingBackend();
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var url = "Fichier/UtilisateurPhotoProfil/";
                    //permet de donner un nom unique et random au fichier
                    Guid g = Guid.NewGuid();
                    string GuidString = Convert.ToBase64String(g.ToByteArray());
                    GuidString = GuidString.Replace("=", "");
                    GuidString = GuidString.Replace("+", "");
                    GuidString = GuidString.Replace(@"\", "");
                    GuidString = GuidString.Replace(@"/", "");



                    var filePath = HttpContext.Current.Server.MapPath("~/" +url+ GuidString+".jpg");
                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);

                    ////on associe l'image a l'utlisateur creer
                    var user = db.Utilisateurs.Where(s=>s.id==userId).FirstOrDefault();
                    user.photoProfil = url + GuidString+".jpg";
                    db.SaveChanges();
                   

                }

            }
           
            

        }
        public static Utilisateur postUtilisateur()
        {

            MusiqueStreamingBackend db = new MusiqueStreamingBackend();
            var data = HttpContext.Current.Request.Form[0];
            Inscription inscription = JsonConvert.DeserializeObject<Inscription>(data);
            var user = db.Utilisateurs.Where(s => s.Email == inscription.Email).FirstOrDefault();
            if ( user!= null)
            {
                return null;
            }

            user= new Utilisateur
            {
                Email = inscription.Email,
                Password = inscription.Password,
                photoProfil = inscription.PhotoProfil
            };

            db.Utilisateurs.Add(user);
            db.SaveChanges();
            return user;
        }
        public static Utilisateur Connection(Connection connection)
        {
            MusiqueStreamingBackend db = new MusiqueStreamingBackend();
            var utilisateur = db.Utilisateurs.Where(s => s.Email == connection.Email).FirstOrDefault();
            if (utilisateur != null)
            {
                if (utilisateur.Password == connection.Password)
                {
                    return utilisateur;
                }

            }
            return null;
        }
        public static Utilisateur deleteUtilisateur(int id)
        {
            MusiqueStreamingBackend db = new MusiqueStreamingBackend();
            Utilisateur utilisateur = db.Utilisateurs.Find(id);
            if (utilisateur == null)
            {
                return utilisateur;
            }

            db.Utilisateurs.Remove(utilisateur);
            Utilitaire.AlbumUtilitaire.deleteAlbumUtilisateur(id, db);

            db.SaveChanges();

            return utilisateur;
        }
    }
}