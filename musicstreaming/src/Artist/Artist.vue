<template>
<div>

    <v-img :src="this.$store.state.serverPathForImage+this.artist.photoProfil" height="500"></v-img>
    <v-container>
            
        <v-layout>
            <v-flex v-if="!smallerVersion">
                    <v-layout>
                        <v-flex class="categorieName" >
                            All songs
                            <v-spacer></v-spacer>
                        </v-flex>
                    </v-layout>
                    <v-layout>
                        <v-flex v-for="songProp in this.songsFirstRow" v-bind:key="songProp.Noms">
                            <Song v-bind:song="songProp" v-bind:album="songProp.album" class="song"/>
                            
                        </v-flex>
                        

                    </v-layout>
                    <v-layout>
                        <v-flex v-for="songProp in this.songsSecondRow" v-bind:key="songProp.Noms">
                            <Song v-bind:song="songProp" v-bind:album="songProp.album" class="song"/>
                            
                        </v-flex>
                        
                    </v-layout>
            </v-flex>
           
        </v-layout>
         <v-flex v-if="smallerVersion">
             <v-flex class="categorieName" >
                All songs
                <v-spacer></v-spacer>
            </v-flex>
            <v-layout v-for="songProp in this.songsSecondRow"  v-bind:key="songProp.Noms"> 
                <v-flex >
                    <Song v-bind:song="songProp" style="margin-bottom:10px;" v-bind:album="songProp.album" class="song"/>
                </v-flex>
            </v-layout>
            <v-layout v-for="songProp in this.songsFirstRow"  v-bind:key="songProp.Noms"> 
                    <v-flex >
                        <Song v-bind:song="songProp" style="margin-bottom:10px;" v-bind:album="songProp.album" class="song"/>
                        
                    </v-flex>
                    

            </v-layout>
        </v-flex>
        <v-layout>
            <v-content>
                <AlbumCarousel v-bind:Albums="this.artist.albums"/>
            </v-content>
            
        </v-layout>
        
    </v-container>
</div>
</template>
<script>
import Song from '../Songs/Song.vue'
import AlbumCarousel from '../Album/AlbumCarousel.vue'
import Axios from 'axios'
export default {
    components:{
        Song,
        AlbumCarousel
       
    },
    props:["userId"]
    ,
    data(){
        return{
             serverImgPath:"http://localhost:50342/",
            songsFirstRow:[],
            songsSecondRow:[],
            smallerVersion:false,
            artist :null,
                Songs:[
                        {
                            Nom:"Guedro",
                            Artist:"Koba",
                            link:"https://lasueur.com/wp-content/uploads/2019/04/Koba-LaD-L-Affranchi.jpg"

                        },
                        {
                            Nom:"Guedro",
                            Artist:"Koba",
                            link:"https://lasueur.com/wp-content/uploads/2019/04/Koba-LaD-L-Affranchi.jpg"

                        },
                        {
                            Nom:"Guedro",
                            Artist:"Koba",
                            link:"https://lasueur.com/wp-content/uploads/2019/04/Koba-LaD-L-Affranchi.jpg"

                        },
                        {
                            Nom:"Guedro",
                            Artist:"Koba",
                            link:"https://lasueur.com/wp-content/uploads/2019/04/Koba-LaD-L-Affranchi.jpg"

                        },
                        {
                            Nom:"Guedro",
                            Artist:"Koba",
                            link:"https://lasueur.com/wp-content/uploads/2019/04/Koba-LaD-L-Affranchi.jpg"

                        },
                        {
                            Nom:"Guedro",
                            Artist:"Koba",
                            link:"https://lasueur.com/wp-content/uploads/2019/04/Koba-LaD-L-Affranchi.jpg"

                        }
                 ]

            
        }
    },
    mounted(){

       

        Axios.get(this.$store.state.serverPath+"Utilisateurs/getUtilisateurByAlbumId/"+this.userId).then(response=>(this.artist=response.data,this.songInit()));
        if(window.innerWidth>800){
                this.smallerVersion=false;
               
            }
            else{
                this.smallerVersion=true;
                
            }
        
        
        
    },
    methods:{
        songInit: function () {
        //var separateur =this.artist.musiques.length/2;
       
        
        
        var i;
        for(i=0;i<6;i++){
                if(i<3){
                    this.songsFirstRow.push(this.artist.musiques[i]);
                
                }
                else{
                    this.songsSecondRow.push(this.artist.musiques[i]);
                }
            }
        } 
    }
}
</script>
<style>
    .song{
        width: 300px;
        margin:0 auto;
    }
</style>
