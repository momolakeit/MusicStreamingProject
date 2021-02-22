<template>
    <div>
        
        <v-carousel height="auto"  >
            <v-carousel-item  v-for="albumParent in this.mainAlbums" v-bind:key="albumParent.id+2" >
                <albumPreview  v-bind:album="albumParent"/>
            </v-carousel-item>  
        </v-carousel>
        
         <v-content v-for="laCategorie in this.Categorie" v-bind:key="laCategorie.id+3">
            <CategorieContainer v-bind:categorie="laCategorie"/>
        </v-content>

    </div>
    
    
</template>
<script>
import albumPreview from '../Album/AlbumPreview.vue'
import CategorieContainer from '../Categorie/CategorieContainer.vue'
import Axios from 'axios'
export default {
    methods:{
        alert:function(){
            alert("oui");
        }
    },
    components:{
            albumPreview,
            CategorieContainer
    },
    data(){
        return{
           Categorie:null,
            mainAlbums:null
        }
        
    }
    
    ,mounted(){
         Axios.get(this.$store.state.serverPath+"Albums/GetFeaturedAlbum").then(response=>(this.mainAlbums=response.data));
        Axios.get(this.$store.state.serverPath+"Categories/GetFeaturedCategorie").then(response=>(this.Categorie=response.data));
        
    }
    
}
</script>
<style>

</style>
