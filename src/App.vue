<template>
  <div id="app">
    <ItemCards :items="items"/>
  </div>
</template>

<script>
import store from "./store/store.js"
import { mapState } from 'vuex'
import ItemCards from "./components/webshop/ItemCards";

export default {
  name: "app",
  store,
  components: {
    ItemCards
  },
  computed: mapState([
    'items'
  ])
};
</script>