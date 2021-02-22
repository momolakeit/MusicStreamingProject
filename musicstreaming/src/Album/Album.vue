<template>
    <v-card style="margin-top:40px;">
        <v-container>
            <v-layout style="border-bottom:1px;">
                <v-flex>
                    <v-img  :src="this.$store.state.serverPathForImage+this.album.albumImgPath" class="albumImg"> </v-img>
                </v-flex>
                <v-flex>
                    <v-container>
                        <v-layout>
                            <v-flex>
                                <v-container>
                                    <v-layout style="height:100%;">
                                        <v-flex>
                                            <p class="headline">{{album.nomAlbum}}</p>
                                        </v-flex>
                                    </v-layout>
                                    
                                    <v-layout>
                                        <router-link :to="{ name: 'Artist', params: { userId }}" >
                                            <v-flex class="headline"> 
                                                <p>Voir l'artiste</p>
                                            </v-flex>
                                        </router-link>
                                    </v-layout>
                                </v-container>
                            </v-flex>
                            
                        </v-layout>
                        <v-container style="padding-top:0;">
                            <v-layout>
                                <v-flex>
                                    <v-icon class="Icon" >play_circle_outline</v-icon>
                                </v-flex>
                            </v-layout>
                        
                        </v-container>
                        
                                               
                    </v-container>
                </v-flex>
                
            </v-layout>
            
            
            <v-layout class="songPreviewContainer" v-for="songProp in this.album.Musiques" v-bind:key="songProp.Nom">
                <v-flex>
                    <Song v-bind:song="songProp" />
                </v-flex>
            </v-layout>
            <!--
            <v-layout class="songPreviewContainer">
                <v-flex>
                    <Song/>
                </v-flex>
            </v-layout>
            <v-layout class="songPreviewContainer">
                <v-flex>
                    <Song/>
                </v-flex>
            </v-layout>
            <v-layout class="songPreviewContainer">
                <v-flex>
                    <Song/>
                </v-flex>
            </v-layout>
            <v-layout class="songPreviewContainer">
                <v-flex>
                    <Song/>
                </v-flex>
            </v-layout>
            <v-layout class="songPreviewContainer">
                <v-flex>
                    <Song/>
                </v-flex>
            </v-layout>
            <v-layout class="songPreviewContainer">
                <v-flex>
                    <Song/>
                </v-flex>
            </v-layout>
            <v-layout class="songPreviewContainer">
                <v-flex>
                    <Song/>
                </v-flex>
            </v-layout>
            <v-layout class="songPreviewContainer">
                <v-flex>
                    <Song/>
                </v-flex>
            </v-layout>
                    
            -->
                
        </v-container>
    </v-card>
</template>
<script>
import Song from '../Songs/Song.vue'
export default {
    components:{
        Song
       
    },
     props:["album"],
    data(){
        return{
            serverImgPath:"http://localhost:50342/",
            userId:0,
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
      this.userId=this.album.fkUtilisateurId;
     
      
    }
    
}
</script>
<style>
    .albumImg{
        height: 200px;
        width: 200px;
        margin:0 auto;
    }
    .songPreviewContainer{
        width: 70%;
        margin: 0 auto;
        margin-top:20px;

    }
    .Icon{
        font-size: 40px;
    }
    @media screen and (max-width: 700px) {
        .songPreviewContainer {
            width: 100%;
        }
        
    }
    
</style>
