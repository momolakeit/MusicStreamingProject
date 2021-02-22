<template>
    <a>
        <v-card @click.native="playSong">
            <v-container class="songContainer">
                <v-layout>
                    <v-flex>
                        <v-img :src="this.$store.state.serverPathForImage+this.song.albumImgPath" class="songAlbumImg"></v-img>
                    </v-flex>
                    <v-flex>
                        <v-container>
                            <v-layout >
                                <v-flex class="SongName">
                                    {{song.NomMusique}}
                                </v-flex>
                               
                                 <v-spacer></v-spacer>
                                <v-btn v-if="small" color="blue" class="playListBtn" @click="addSongToPlayer">Ajouter a la playlist</v-btn>
                            </v-layout>
                        </v-container>  
                    </v-flex>
                </v-layout>
            </v-container>
        </v-card>
    </a>
</template>
<script>
import Axios from'axios';
export default {
    props:["song"],
    
    
    data(){
        return{
             serverImgPath:"http://localhost:50342/",
             album:null,
             //nous permet de savoir si on utlisera une version plus petite du component
             //cest a dire sans btn ajout playlist
             small:false
        }
    },
    mounted(){
        Axios.get(this.$store.state.serverPath+"Albums/"+this.song.fkAlbumId).then(response=>(this.album=response.data));
       

       //on ne veut pas le btn ajout playlist sur le router album
        if(this.$router.currentRoute.path=="/Album"){
            this.small=true;
        }
        console.log(this.song.albumImgPath);
    },
    methods:{
        addSongToPlayer:function(){
            this.$store.state.musiqueAJouer.push(this.song);
            //console.log(this.$store.state.musiqueAJouer);
           
        },
         playSong:function(){
             //permet de faire jouer la musique des qu'on la selectionne
             //on remplace la musique qui joue par celle qu'on a selectionner
            
            if(this.$store.state.musiqueAJouer.length>0){
                this.$store.state.musiqueAJouer.splice(this.$store.state.compteurMusique-1,1,this.song);
            }
            else{
                this.$store.state.musiqueAJouer.push(this.song);
            }
         
           
        }
    }
    
}
</script>
<style>
    .songAlbumImg{
        height: 90px;
        width: 90px;
        margin:0;
    }
    
    .songContainer{
        padding: 0.5%;
    }
    @media screen and (max-width: 700px) {
        .playListBtn {
            display:none;
        }
        
    }
</style>
