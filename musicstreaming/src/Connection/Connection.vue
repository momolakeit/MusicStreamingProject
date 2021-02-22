<template>
    <v-container>
        <v-layout>
            <v-flex>
                <v-card class="connectionVCard">
                    <v-container >
                        <v-layout  style="widht:100%;">
                            <v-flex align-center  class=" projectForm" >

                                <v-form fill-height >
                                    <v-text-field
                                        label="Adresse Courriel"
                                        v-model="email">
                                    </v-text-field>
                                    <v-text-field
                                        label="Password"
                                        type="password"
                                        v-model="password">
                                    </v-text-field>
                                    <h3 v-if="this.mauvaisUser" style="color:red;">Email ou mot de passe erroné</h3>
                                    <v-btn
                                        color="blue" 
                                        @click="handleSubmit">
                                        Se connecter
                                    </v-btn>
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
            email:"",
            password:"",
            mauvaisUser:false
        }
    },
    methods:{
        handleSubmit:function(){
            Axios.post(this.$store.state.serverPath+"Utilisateurs/Connection",{
                email:this.email,
                password:this.password
            })
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
        }
    }
}
</script>
<style>
    .projectForm{
        width: 40% ;
        height: 300px;
    }
    .connectionVCard{
        margin: 0 auto;
         width:60%;
    }
    @media screen and (max-width: 700px) {
    .connectionVCard {
       width: 100%;
    }
}
</style>
