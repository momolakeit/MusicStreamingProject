<template>
  <v-app>
    <v-container >
      <v-content id="headerVContent" >
        <v-toolbar  id="toolbar" height="79" app dark style="height=100%">
            <v-toolbar-title class="makeInvisibleOnMobile">
                Momo Music Streaming
            </v-toolbar-title>
            
            <v-spacer class="makeInvisibleOnMobile" >
            </v-spacer>
            <v-form  id="searchForm">
              <v-container>
                <v-layout>
                  <v-flex>
                        <v-text-field style="width:100%;" flat placeholder="Search" v-model="searchQuery"> </v-text-field>
                  </v-flex>
                  <v-flex>
                      <v-btn style="margin-top:20px;" @click="handleSearch" color="blue"> Go</v-btn>
                  </v-flex>
                </v-layout>
              </v-container>
                    
                    
              
            </v-form>
            <v-toolbar-side-icon v-on:click="showSideBar =!showSideBar">
            </v-toolbar-side-icon>
            
        </v-toolbar>

        </v-content>
        <v-navigation-drawer class="sideNav"
                v-model="showSideBar"
                absolute
                dark
                right>
                <v-list>
                  <v-list-tile>
                    <v-list-tile-action>
                      <v-icon v-on:click="showSideBar=!showSideBar">chevron_right</v-icon>
                    </v-list-tile-action>
                  </v-list-tile>
                  <v-list-tile  :to="{name:'Body'}">
                    <v-list-tile-content>
                      <v-list-tile-title class="navigationItem" >Home</v-list-tile-title>
                    </v-list-tile-content>
                  </v-list-tile>
                  <v-list-tile v-if="!userConnected" :to="{name:'Connection'}">
                    <v-list-tile-content>
                      <v-list-tile-title class="navigationItem" >Connection</v-list-tile-title>
                    </v-list-tile-content>
                  </v-list-tile>
                  <v-list-tile v-if="!userConnected" :to="{name:'Inscription'}">
                    <v-list-tile-content>
                      <v-list-tile-title class="navigationItem" >Inscription</v-list-tile-title>
                    </v-list-tile-content>
                  </v-list-tile>
                  <v-list-tile v-if="userConnected" :to="{name:'Upload'}">
                    <v-list-tile-content>
                      <v-list-tile-title class="navigationItem" >Upload</v-list-tile-title>
                    </v-list-tile-content>
                  </v-list-tile>
                  <button style="width:100%">
                  <v-list-tile @click="deconnecterUser" v-if="userConnected">
                    <v-list-tile-content>
                      <v-list-tile-title  class="navigationItem" >Deconnexion</v-list-tile-title>
                    </v-list-tile-content>
                  </v-list-tile>
                  </button>
                </v-list>

          </v-navigation-drawer>
        <v-content  style="padding-top:0px">
          
              <transition name="custom-classes-transition" 
                  enter-active-class="animated bounceInRight"
                  leave-active-class="animated bounceOutLeft">
                    <router-view id="routerView"/>
              </transition>
          
            
          </v-content>

      
      <v-footer  dark app  height="45">

          <Player/>
      </v-footer>
    </v-container>
  </v-app>
 
</template>

<script>
import Player from'./Player/Player.vue'
import Axios from 'axios'
export default {
  name: 'App',
  components: {
    Player
  },
  data () {
    return {
      showSideBar:false,
      userConnected:false,//a faire dans le store
      searchQuery:null
     
    }
  },
   mounted(){
      
      if(window.innerWidth<=700){
        var makeInvisibleOnMobile=document.getElementsByClassName("makeInvisibleOnMobile");
        console.log(makeInvisibleOnMobile);
        
        //afin de transformer le htmlElementEnClassName
        var makeInvisibleOnMobileArray=Array.prototype.slice.call(makeInvisibleOnMobile);
        

        makeInvisibleOnMobileArray.forEach(element => {
          element.classList.add("d-none");
         
        });
          
      }
       if (localStorage.getItem('user') != null){
            this.userConnected=true;
        }
        else{
            this.userConnected=false;
        }

   },
   updated(){
       if (localStorage.getItem('user') != null){
            this.userConnected=true;
        }
        else{
            this.userConnected=false;
        }
   },
   methods:{
          deconnecterUser:function(){
            this.userConnected=false;
           localStorage.removeItem('user');
            this.$router.push({ path: '/' })
          },
          handleSearch:function(){
            Axios.post("http://localhost:50342/api/Musiques/SearchMusique",{
                searchQuery:this.searchQuery
            })
            .then(response=>{
                        //alert(response.data);
                        this.$router.push({ name: 'Search' ,params:{songs:response.data}})
                            
                            //this.$router.push({ path: '/' })
            }).catch(error=>{
              console.log(error);
                this.mauvaisUser=true;//permet d'afficher le message d'erreur si L'utilisateur ne peut pas se connecter
                
            })
        }
  }
}
</script>
<style>
    .navigationItem{
      margin-left: 8%;
      margin-bottom: 10%;
      font-size: 15px;
    }
    #routerView{
      position: absolute;
      width: 100%;
      
      justify-content: center;
      margin: 0 auto;
      margin-top: 78px;
    }
    #headerVContent{
      position: absolute;
      
    }
    #searchForm{
      width: 50%;
    }
    
</style>

