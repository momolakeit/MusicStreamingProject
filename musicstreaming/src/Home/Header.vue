<template>
    <v-toolbar id="toolbar" height="79" app dark style="height=100%">
        <v-toolbar-title>
            Momo Music Streaming
        </v-toolbar-title>
        
        <v-spacer>
        </v-spacer>
        <v-form>
            <v-text-field flat placeholder="Search"> </v-text-field>
            <v-btn color="blue" @click="handleSubmit">Se connecter</v-btn>
        </v-form>
        
       
        <v-toolbar-items>
            <v-container>
                <v-layout>
                    <v-flex>
                        <p style="margin-right:10px">salut</p>
                    </v-flex>
                    <v-flex>
                        <p style="margin-right:10px">salut</p>
                    </v-flex>
                    <v-flex>
                        <p style="margin-right:10px">salut</p>
                    </v-flex>
                </v-layout>
              
            </v-container>

        </v-toolbar-items>
        
        <v-toolbar-side-icon v-on:click="showSideBar =!showSideBar">
        </v-toolbar-side-icon>
        <v-navigation-drawer class="sideNav"
            v-model="showSideBar"
            absolute
            dark
            right>

        </v-navigation-drawer>
    </v-toolbar>
</template>
<script>
export default {
   data(){
       return{
           showSideBar:false
       }
   }

}
</script>
<style>
    
</style>
