<template>
  <div id="app">
    <Navbar/>
    <ItemCards :items="clothes"/>
  </div>
</template>

<script>
import store, { actions } from "./store.js";
import { mapState } from "vuex";
import ItemCards from "./components/webshop/ItemCards";
import Navbar from "./components/Navbar";

export default {
  name: "app",
  store,
  components: {
    ItemCards,
    Navbar
  },
  computed: mapState(["brands", "clothes"]),
  created: function() {
    this.$store.dispatch(actions.Fecth_Data);
  }
};
</script>