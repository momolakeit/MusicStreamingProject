<template>
    <v-container style="margin-left:5%;" >
        <v-layout>
            <div class="SearchTxtDiv">
                <v-flex>
                    <h4 class="display-1" style="margin-top:50px;">Search results</h4>
                </v-flex>
            </div>
        </v-layout>
        <v-layout style="margin-top:50px;"  v-for="songProp in this.songs" v-bind:key="songProp.nom">
            <v-flex>
                <Song v-bind:song="songProp"/>
            </v-flex>
        </v-layout>
        
    </v-container>
</template>
<script>
import Song from '../Songs/Song.vue'
import Axios from'axios'
export default {
    components:{
        Song
    },
    props:["songs"]
    ,mounted( ){
        
    }
    
}
</script>
<style>
    .SearchTxtDiv{
        border-style: solid;
        width: 100%;
        border-top:none;
        border-left:none;
        border-right: none;
        border-width: 1px;
    }
</style>
