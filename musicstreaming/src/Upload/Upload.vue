<template>
    <v-container id="albumUploadMainContainer">
        <v-layout>
            <v-flex><h1>Ajouter Musiques</h1></v-flex>
        </v-layout>
        <v-layout>
            <v-container style="width:100%;">
                <v-layout>
                    <v-flex>
                        <v-container class="sm6" :width="cardWidth">
                            <v-layout>
                                <v-flex>
                                    <v-img id="albumUploadImage"
                                        src="data:image/png;base64,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"
                                    />
                                </v-flex>
                            </v-layout>
                            <v-layout>
                                <v-flex>
                                 <v-btn color="blue" >
                                    <input class="fileUpload "  id="albumImgUpload"  type="file" ref="image" accept="image/*">
                                    Upload Cover                                
                                </v-btn>
                                </v-flex>
                                <v-flex>
                                    <v-select :items="categorie" v-model="categorieChoisi" label="Selectionner genre" outlined></v-select>
                                </v-flex>
                                <v-flex>
                                    <v-text-field v-model="nomAlbum" style="margin-left:35px;" label="Nom Album"/>
                        
                                </v-flex>
                            </v-layout>
                        </v-container>
                        
                    </v-flex>
                    
                </v-layout>
            </v-container>
            
        </v-layout>
        <v-layout>
            <v-container style="padding-left:4%;">
                <v-layout v-for="(item, index) in songs" v-bind:key="item.id">
                    <v-flex style="width:25%">
                        <v-btn color="blue" >
                            <input  class="songUpload" type="file" ref="image" accept="audio/*">
                            <!--<input class="songUpload"  type="file" ref="image" >-->
                            Upload song                                   
                        </v-btn>
                        

                    </v-flex>
                  
                    <v-flex>
                         <v-text-field v-model="songs[index].NomMusique" class="songName" label="Nom Musique"/>
                         <!--<v-text-field  @input="$evt => songs[index].NomMusique = $evt.target.value" class="songName" label="Nom Musique"/>-->
                    </v-flex>

                </v-layout>
                <v-layout>
                    <v-flex>
                        <v-btn color="blue" @click="uploadOtherSong">Nouvelle musique</v-btn>
                        <v-btn color="blue" @click="uploadAlbum">Submit</v-btn>
                    </v-flex>
                </v-layout>
            </v-container>
        </v-layout>
    </v-container>
</template>
<script>
import Axios from 'axios'
export default {
    
    data(){
        return{
            songs:[
                {
                    id:0,
                    NomMusique:""
              
                }
               
            ],
            categorie:[]
            ,
            compteurSongs:0,
            nomAlbum:"",
            categorieChoisi:"",
            albumId:0,
            goSongs:false//afin d'eviter que la method sececute automatiquement a chaque fois que'elle est assignee a une variable
            
        }
    },
    mounted(){
        Axios.get(this.$store.state.serverPath+"Categories/geAllGategorieName").then(response=>(this.categorie=response.data));
      
    },
    updated(){
        
    }
    ,
    methods:{
            //dans le array categorie, on met les categories names 
        setCategorieName:function(){
            var categorieName=[];
            this.categorie.forEach(function(element){
                categorieName.push(element.name);
            });

            this.categorie=categorieName;

        },
        //ajoute des musiques dans le array de musiques
        uploadOtherSong:function(){
            this.songs.push({NomMusique:"",id:this.compteurSongs})
        
            this.compteurSongs=this.compteurSongs+1;
            console.log(this.songs)
           
        },
        uploadAlbum:function(id){
            const obj={
                nomAlbum:this.nomAlbum
            
            }
            const json = JSON.stringify(obj);
            
            this.file=document.getElementById("albumImgUpload");
            
            const formData = new FormData();
            formData.append("data",json);
            formData.append("utilisateurId",localStorage.getItem('user'));
            formData.append("categorie",this.categorieChoisi)
            formData.append("file",this.file.files[0]);
           
           var self=this.uploadSongs();
           
            Axios.post(this.$store.state.serverPath+"Albums", 
               
                formData, {
                    headers: {
                    'Content-Type': 'multipart/form-data'   
                    }
                }
               
            )
            .then(response=>{
                       //this.uploadSongs(response.data);
                      
                      this.goSongs=true;
                      this.uploadSongs(response.data);
                       //self(response.data);
                      
            })
            .catch(error=>{
                alert(error);
                console.log(error);
              
                
            })
        },
        uploadSongs:function(id){
            if(this.goSongs){

                this.goSongs=false;
                const json = JSON.stringify(this.songs);
                
                this.file=document.getElementsByClassName("songUpload");
                
                
                const formData = new FormData();
                formData.append("data", json);
                //on va chercher le id de lutili dans local storage
                formData.append("albumInfo",id);

             var filesArray=Array.prototype.slice.call(this.file);
                console.log(this.file)

             filesArray.forEach(function(element){
                 formData.append("file[]",element.files[0]);
                
             })
                
                
                Axios.post(this.$store.state.serverPath+"Musiques", 
                
                    formData, {
                        headers: {
                        'Content-Type': 'multipart/form-data'   
                        }
                    }
                
                )
                .then(response=>{
                            this.$router.push({ path: '/'})
                            
                }).catch(error=>{
                    console.log(error);
                    
                    
                })

            }
            

        }
    }
    
}
</script>
<style  scoped>
    #albumUploadImage{
        height: 250px;
        width: 250px;

    }
    .fileUpload, .songUpload{
        position: absolute;
        opacity: 0;
        width: 100px;
    }
    #albumUploadMainContainer{
        margin-top: 50px;
       
    }
    @media screen and (max-width: 700px) {
        .songName{
           
            width: 120px;
            margin-left: 5px;
        }
        .fileUpload, .songUpload{
       
        width: 30px;
    }
        
    }

</style>