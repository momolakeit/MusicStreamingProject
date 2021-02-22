import Vue from 'vue'
import Router from 'vue-router'
import Body from './Home/Body.vue'
import Connection from './Connection/Connection.vue'
import Inscription from './Inscription/Inscription.vue'
import Artist from './Artist/Artist.vue'
import Album from './Album/Album.vue'
import Search from './Search/Search.vue'
import Upload from './Upload/Upload.vue'


Vue.use(Router)

const router= new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'Body',
      component: Body,
      props:true
    },
    {
      path: '/about',
      name: 'about',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/* webpackChunkName: "about" */ './views/About.vue')
    },
    {
      path: '/Connection',
      name: 'Connection',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component:Connection,
      props:true,
      meta:{
        guest:true
      }
    }
    ,
    {
      path: '/Inscription',
      name: 'Inscription',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component:Inscription,
      props:true,
      meta:{
        guest:true
      }
    },
    {
      path: '/Artist',
      name: 'Artist',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component:Artist,
      props:true,
      meta:{
        guest:true
      }
    }
    ,
    {
      path: '/Album',
      name: 'Album',
      props:true,
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component:Album,
      meta:{
        guest:true
      }
     
    }
    ,
    {
      path: '/Search',
      name: 'Search',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component:Search,
      props:true,
      meta:{
        guest:true
      }
    }
    ,
    {
      path: '/Upload',
      name: 'Upload',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component:Upload,
      props:true,
      meta:{
        requiresAuth:true
      }
    }
  ]
})
router.beforeEach((to, from, next) => {
  if(to.matched.some(record => record.meta.requiresAuth)) {
      if (localStorage.getItem('user') == null) {
          next({
              path: '/Connection'
          })
      } else {
          let user = JSON.parse(localStorage.getItem('user'))
          if(to.matched.some(record => record.meta.is_admin)) {
              if(user.is_admin == 1){
                  next()
              }
              else{
                  next({ name: 'Utilisateur'})
              }
          }else {
              next()
          }
      }
  } else if(to.matched.some(record => record.meta.guest)) {
      if(localStorage.getItem('jwt') == null){
          next()
      }
      else{
          next({ name: 'userboard'})
      }
  }else {
      next() 
  }
})
export default router