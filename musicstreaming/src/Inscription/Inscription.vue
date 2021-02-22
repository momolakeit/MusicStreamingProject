<template>
    <v-container>
        <v-layout>
            <v-flex>
                <v-card class="InscriptionVCard" >
                    <v-container >
                        <v-layout  style="widht:100%;">
                            <v-flex align-center  class=" projectForm" >

                                <v-form  fill-height >
                                    <v-text-field v-model="email"
                                        label="Adresse Courriel">
                                    </v-text-field>
                                    <v-text-field v-model="surnomArtiste"
                                        label="Surnom (Nom d'artiste    )">
                                    </v-text-field>
                                    <v-text-field v-model="password"
                                        label="Password"
                                        type="password">
                                    </v-text-field>
                                    <v-text-field v-model="passwordConfirmation"
                                        label="Confirmer Password"
                                        type="password">
                                    </v-text-field>
                                    <v-btn color="blue" class="inscriptionBtn" >
                                        <input id="fileUpload"  type="file" 
                                       
                                        ref="image"
                                        accept="image/*"
                                        
                                         >
                                                 Photo                                   
                                    </v-btn>
                                    <v-btn class="inscriptionBtn" color="blue" @click="handleInscription">
                                        S'inscrire
                                    </v-btn>
                                    <!--@change="submitFile" -->
                                    
                                </v-form>
                            </v-flex>
                        </v-layout>
                    </v-container>
                </v-card>
            </v-flex>
        </v-layout>

    </v-container>
    
</template>
<script>
import Axios from 'axios'
export default {

    data(){
        return{
            email:null,
            password:null,
            passwordConfirmation:null,
            surnomArtiste:null,
            artistImg:null
        }
    },
    methods:{
         handleInscription:function(){
                //on set up la requete afin de pouvoir envoyer un file
            
            
            
            
            
            const obj={
                email:this.email,
                password:this.password,
                passwordConfirmation:this.passwordConfirmation,
                surnomArtiste:this.surnomArtiste,
            
            }
            const json = JSON.stringify(obj);
            
            this.file=document.getElementById("fileUpload");
            const formData = new FormData();
            formData.append("data", json);
            formData.append("file",this.file.files[0]);
           
            
            Axios.post(this.$store.state.serverPath+"Utilisateurs", 
               
                formData, {
                    headers: {
                    'Content-Type': 'multipart/form-data'   
                    }
                }
               
            )
            .then(response=>{
                        
                         localStorage.setItem('user',JSON.stringify(response.data.id))
                        //alert(response.data.id);

                        if (localStorage.getItem('user') != null){
                            
                            this.$router.push({ path: '/' })
                        }
            }).catch(error=>{
                console.log(error);
                this.mauvaisUser=true;//permet d'afficher le message d'erreur si L'utilisateur ne peut pas se connecter
                
            })
        },
        submitFile:function(userId){


            alert(userId);
            let formData = new FormData(); 
           this.file=document.getElementById("fileUpload");
            formData.append('file', this.file.files[0]);
            formData.append('file', this.file);
            console.log('>> formData >> ', formData);

            // You should have a server side REST API 
            Axios.post('http://localhost:50342/api/Utilisateurs/UploadUserImg/'+userId,
                formData, {
                    headers: {
                    'Content-Type': 'multipart/form-data'   
                    }
                }
                ).then(response=> {
                        localStorage.setItem('user',JSON.stringify(response.data.id))
                        //alert(response.data.id);

                        if (localStorage.getItem('user') != null){
                            
                            this.$router.push({ path: '/' })
                        }
                })
                .catch(function () {
                console.log('FAILURE!!');
                });
                
        }
    }
}
</script>
<style>
    .projectForm{
        width: 40% ;
        height: 300px;
    }
    .InscriptionVCard{
        margin: 0 auto;
        width:60%;
    }
    #fileUpload{
        position: absolute;
        opacity: 0;
        width: 100px;
    }
    #fileUpload p{
       position: absolute;
       left: 10px;
    }
    @media screen and (max-width: 700px) {
        .InscriptionVCard {
            width: 100%;
        }
        .inscriptionBtn{
            width: 100px;
        }
    }
    
</style>
