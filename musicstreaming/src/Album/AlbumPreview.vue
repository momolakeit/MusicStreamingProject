<template>


    
        <v-card  >
            <router-link :to="{ name: 'Album', params: {album }}" >
                <v-img   :src="this.$store.state.serverPathForImage+album.albumImgPath" class="AlbumPreviewIMG">
                    <h2 class="albumTitle subheading">{{this.album.nomAlbum}}</h2>
                </v-img>
             </router-link>
        </v-card>
   
    
        
</template>
<script>
export default {
    props:["album"],
    data(){
        return{
            
        }
    },
    mounted(){
       
    }
    
}
</script>
<style>
    .albumTitle{
        margin-top: 05%;
        margin-left:05%;
        color:white;
        
    }
    .AlbumPreviewIMG{
            height: 100%;
            width: 100%;
    }
    
</style>
