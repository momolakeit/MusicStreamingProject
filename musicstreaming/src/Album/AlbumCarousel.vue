<template>
    <div>
        <v-carousel height="auto" v-if="!smallerVersion"  v-bind:hide-delimiters="true" interval="60000000" id="categorieCarousel" >
            <v-carousel-item v-for="n in nombreDeCarouselItem" v-bind:key="n">  
                <v-layout class=" justify-space-between " >
                    <v-flex v-for="x in nombreDAlbum"  v-bind:key="x">
                        <albumPreview v-bind:album="Albums[x*n-1]"  class="CategorieAlbumPreview" />
                         
                    </v-flex>
                    
                </v-layout>
            </v-carousel-item>
        </v-carousel>
         <v-carousel height="auto" v-if="smallerVersion"  v-bind:hide-delimiters="true" interval="60000000" id="categorieCarousel" >
            <v-carousel-item v-for="n in Albums" v-bind:key="n.id">  
                <albumPreview v-bind:album="n"  class="CategorieAlbumPreview" />
            </v-carousel-item>
        </v-carousel>
    </div>
        
    
                            
</template>
<script>
import albumPreview from './AlbumPreview.vue'
import state from '../store'

export default {
    props:["Albums"],
    state:{
        compteurAlbum:-1
    },
    components:{
        albumPreview
    },
    data(){
        return{
            nombreDAlbum:3,//represente le nombre d'albums dans un slide du carousel
            nombreDeCarouselItem:0,
            ///nous permet de savoir si nous allons mettre un ou plusieurs album dans le carousel(pour que sa resize)
            smallerVersion:false,
            categorieAlbums:
                    [
                        {
                            id:1,
                            nom:"dsadasdasdas1",
                            link:"https://lasueur.com/wp-content/uploads/2019/04/Koba-LaD-L-Affranchi.jpg"
                        },
                        {
                            id:2,
                            nom:"dsadasdasdas2",
                            link:"https://lasueur.com/wp-content/uploads/2019/04/Koba-LaD-L-Affranchi.jpg"
                        },
                        {
                            id:3,
                            nom:"dsadasdasdas3",
                            link:"https://lasueur.com/wp-content/uploads/2019/04/Koba-LaD-L-Affranchi.jpg"
                        },
                        {
                            id:4,
                            nom:"dsadasdasdas4",
                            link:"https://lasueur.com/wp-content/uploads/2019/04/Koba-LaD-L-Affranchi.jpg"
                        },
                        
                        {
                            id:5,
                            nom:"dsadasdasdas5",
                            link:"https://lasueur.com/wp-content/uploads/2019/04/Koba-LaD-L-Affranchi.jpg"
                        },
                        
                        {
                            id:6,
                            nom:"dsadasdasdas6",
                            link:"https://lasueur.com/wp-content/uploads/2019/04/Koba-LaD-L-Affranchi.jpg"
                        }
                    ]
            
        }
    }
    ,
    mounted(){
            //represente le nombre de carousel items, 
            this.nombreDeCarouselItem= Math.ceil(this.Albums.length/this.nombreDAlbum);
            //math.ceil pour sassurer davoir 1 carousel de plus que this.Albums.length/this.nombreDAlbum  


            ///on prend la taille du window pour savoir quel tyoe de carousel render
            if(window.innerWidth>800){
                this.smallerVersion=false;
               
            }
            else{
                this.smallerVersion=true;
                
            }
          
            
    },
    methods:{
        count:function(){
           
            console.log(state._actions);
            state.state.compteurAlbum=state.state.compteurAlbum+1;
            return 0;
           
            //afin de display tout les albums

        }
    }

}
</script>
<style>

</style>
