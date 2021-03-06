import Vue from "vue";
import Router from "vue-router";

import Store from "./components/pages/Store.vue";
import Details from "./components/pages/Details.vue";

Vue.use(Router);

export default new Router({
  mode: "history",
  routes: [
    {
      name: "store",
      path: "/",
      component: Store
    },
    {
      name: "details",
      path: "/details/:id",
      component: Details,
      props: true
    }
  ]
});
