<template>
    <v-card class="CategorieContainerVCard">
        <v-container>
            <v-layout  text-xs-center>
                <v-flex>
                    <div>
                        <p align-content-start class="subheading">
                            {{this.categorie.Nom}}
                        </p>
                    </div>
                    
                    <v-flex>
                        <v-container>
                            <v-content>
                                <AlbumCarousel v-bind:Albums="this.categorie.Albums"/>
                            </v-content>
                            
                        </v-container>

                    </v-flex>
                    
                </v-flex>
                
            </v-layout>    
        </v-container>

    </v-card>
</template>
<script>

import AlbumCarousel from '../Album/AlbumCarousel.vue'

export default {
    components:{
       
        AlbumCarousel
    },
    props:["categorie"],
    data(){
        return{
            
        }
        
    }
    ,mounted(){
        console.log(this.categorie)
    }
    
    
}
</script>
<style>
    .CategorieAlbumPreview{
        width: 100% ;
        height:250PX;
        margin: 0 !important;
        
    }
    #categorieCarousel{
        width: 100%;
    }
</style>
