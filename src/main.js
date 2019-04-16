import Vue from 'vue'
import router from './router'
import App from './App.vue'
import store from "./store.js";
import api from "./api";
import Antd from 'ant-design-vue'
import 'ant-design-vue/dist/antd.css'

Vue.config.productionTip = false
Vue.use(Antd)
Vue.use(router)

Vue.prototype.$api = api; 

new Vue({
  router,
  store,
  render: h => h(App),
}).$mount('#app')
