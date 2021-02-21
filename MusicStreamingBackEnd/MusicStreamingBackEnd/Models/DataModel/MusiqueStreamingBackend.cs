using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MusicStreamingBackEnd.Models.DataModel
{
    public class MusiqueStreamingBackend:DbContext
    {
        public DbSet<Musique> Musiques { get; set; }
        public DbSet<Album> Album{ get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Categorie> Categories{ get; set; }



        public MusiqueStreamingBackend() : base("MusiqueStreamingBackEnd")
        {
            Database.SetInitializer(new MusiqueStreamingBackendInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
    public class MusiqueStreamingBackendInitializer : DropCreateDatabaseIfModelChanges<MusiqueStreamingBackend>
    {
        protected override void Seed(MusiqueStreamingBackend context)
        {
            base.Seed(context);
                       
            //////////////////////////////musique boucle initialisation
            
            var utilisateur = new Utilisateur
            {
                Email = "momo@gmail.com",
                Password = "momo1234",
                photoProfil = "Fichier/UtilisateurPhotoProfil/firstUserPic.jpg"

            };
            utilisateur.albums = new List<Album>();
            context.Utilisateurs.Add(utilisateur);

            context.SaveChanges();

            Categorie categorieRap = new Categorie
            {
                Nom = "Rap",

            };
            context.Categories.Add(categorieRap);
            context.SaveChanges();
            Categorie categorieRock = new Categorie
            {
                Nom = "Rock",

            };
            context.Categories.Add(categorieRock);
            context.SaveChanges();
            Categorie categoriePop = new Categorie
            {
                Nom = "Pop",

            };
            context.Categories.Add(categoriePop);
            context.SaveChanges();
            Categorie categorieClassique = new Categorie
            {
                Nom = "Classique",

            };
            context.Categories.Add(categorieClassique);
            context.SaveChanges();




            //pour chaque categorie nous creeons des albums et pour chaque album nous creeons des musiques, 
            //le tout sera la propriété d'utilisateur

            categorieRap.Albums = new List<Album>();
            categorieRap.Musiques = new List<Musique>();
            
            var i = 0;
            do
            {
                var album = new Album
                {
                    id = 0,
                    nomAlbum = "Le monde chicoRap"+i,
                    albumImgPath = "Fichier/AlbumPhoto/mainPic.jpg",



                };

                context.Album.Add(album);                
                categorieRap.Albums.Add(album);
                utilisateur.albums.Add(album);
                album.Utilisateur = utilisateur;
                context.SaveChanges();

                album.Musiques = new List<Musique>();
                
                var ii = 0;
                do
                {
                 
                    var musique = new Musique
                    {
                        NomMusique = "momoMusiqueRap"+ii,
                        musicPath = "Fichier/Musique/mainSong.mp3"
                    };
                    context.Musiques.Add(musique);
                    album.Musiques.Add(musique);
                    musique.album = album;

                    categorieRap.Musiques.Add(musique);
                    musique.Categorie = categorieRap;
                    context.SaveChanges();



                    ii++;
                } while (ii<5);
                i++;
            } while (i < 3);

            categoriePop.Albums = new List<Album>();
            categoriePop.Musiques = new List<Musique>();

            i = 0;
            do
            {
                var album = new Album
                {
                    id = 0,
                    nomAlbum = "Le monde chicoRap" + i,
                    albumImgPath = "Fichier/AlbumPhoto/mainPic.jpg",



                };


                context.Album.Add(album);
                categoriePop.Albums.Add(album);
                utilisateur.albums.Add(album);
                album.Utilisateur = utilisateur;
                context.SaveChanges();

                
                album.Musiques = new List<Musique>();
              
                var ii = 0;
                do
                {
                  
                    var musique = new Musique
                    {
                        NomMusique = "momoMusique Pop" + ii,
                        musicPath = "Fichier/Musique/mainSong.mp3"
                    };
                    context.Musiques.Add(musique);
                    album.Musiques.Add(musique);
                    musique.album = album;

                    categoriePop.Musiques.Add(musique);
                    musique.Categorie = categoriePop;
                    context.SaveChanges();



                    ii++;
                } while (ii < 5);
                i++;
            } while (i < 3);
            categorieClassique.Albums = new List<Album>();
            categorieClassique.Musiques = new List<Musique>();

            i = 0;
            do
            {
                var album = new Album
                {
                    id = 0,
                    nomAlbum = "Le monde chicoPop" + i,
                    albumImgPath = "Fichier/AlbumPhoto/mainPic.jpg",



                };

                context.Album.Add(album);
                categorieClassique.Albums.Add(album);
                utilisateur.albums.Add(album);
                album.Utilisateur = utilisateur;
                context.SaveChanges();


                album.Musiques = new List<Musique>();
                
                var ii = 0;
                do
                {

                    var musique = new Musique
                    {
                        NomMusique = "momoMusique Pop" + ii,
                        musicPath = "Fichier/Musique/mainSong.mp3"
                    };
                    context.Musiques.Add(musique);
                    album.Musiques.Add(musique);
                    musique.album = album;

                    categorieClassique.Musiques.Add(musique);
                    musique.Categorie = categorieClassique;
                    context.SaveChanges();



                    ii++;
                } while (ii < 5);
                i++;
            } while (i < 3);


            categorieRock.Albums = new List<Album>();
            categorieRock.Musiques = new List<Musique>();
            i = 0;
            do
            {
                var album = new Album
                {
                    id = 0,
                    nomAlbum = "Le monde chicoRock" + i,
                    albumImgPath = "Fichier/AlbumPhoto/mainPic.jpg",



                };

                context.Album.Add(album);
                categorieRock.Albums.Add(album);
                utilisateur.albums.Add(album);
                album.Utilisateur = utilisateur;
                context.SaveChanges();


                album.Musiques = new List<Musique>();
               
                var ii = 0;
                do
                {

                    var musique = new Musique
                    {
                        NomMusique = "momoMusique Rock" + ii,
                        musicPath = "Fichier/Musique/mainSong.mp3"
                    };
                    context.Musiques.Add(musique);
                    album.Musiques.Add(musique);
                    musique.album = album;

                    categorieRock.Musiques.Add(musique);
                    musique.Categorie = categorieRock;
                    context.SaveChanges();



                    ii++;
                } while (ii < 5);
                i++;
            } while (i < 3);


















    










            int iii = context.Categories.Count();
            var a = context.Album.ToList();
            context.SaveChanges();

        }
    }
}