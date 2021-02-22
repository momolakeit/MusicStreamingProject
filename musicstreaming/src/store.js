import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
      musiqueAJouer:[],
      compteurMusique:0,
      serverPathForImage:"http://localhost:50342/",
      serverPath:"http://localhost:50342/api/"
  },
  mutations: {

  },
  actions: {
        count:function(){
              
          this.compteurAlbum=this.compteurAlbum+1;
        
          
          return this.compteurAlbum;
        
          //afin de display tout les albums

      }

  }
})
