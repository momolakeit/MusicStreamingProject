<template >
    <div style="width:100%;">

        <VuetifyAudio   :albumImgPath="this.$store.state.musiqueAJouer[this.$store.state.compteurMusique].albumImgPath"  
            :songName="this.$store.state.musiqueAJouer[this.compteurMusique].NomMusique" 
            :file="serverAudioPath+this.$store.state.musiqueAJouer[this.compteurMusique].musicPath" 
            :ended="newSong" id="vuetifyAudio"/>

    </div>
        
</template>
<script>
import VuetifyAudio from 'vuetify-audio'
export default {
    components:{
        VuetifyAudio
    }
    ,
    computed: {
        // a computed getter
        doIRender: function () {
        // `this` points to the vm instance   
        return this.musiquePresent;
        }
    }
    ,
    data(){
        return{
            musiquePresent:false,
            file:null,
            compteurMusique:0,
            musiques:null,
            serverAudioPath:"http://localhost:50342/",
            
        }
    },
    methods:{
        newSong:function(){
                this.$store.state.musiqueAJouer[this.$store.state.compteurMusique]=null;
                this.$store.state.compteurMusique=this.$store.state.compteurMusique+1;
                
        },
        checkMusiquePresent:function(){
               
                if(this.$store.state.musiqueAJouer.length>0){
                    this.musiquePresent=true;
                }
                else{
                    this.musiquePresent=false
                }
               
        }
    }
    
    ,
    mounted(){
        
       this.checkMusiquePresent();
       
    }
    ,
    updated(){
        this.checkMusiquePresent();
        
    }
}
</script>
<style  scoped>
    audio{
        width: 100%;
    }
    #vuetifyAudio{
        width: 100%;
        height: 110px;
        background-color: #212121;
    }
    
   

</style>