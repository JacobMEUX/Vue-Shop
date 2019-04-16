<template>
  <div id="app">
    <Navbar/>
    <router-view class="content"/>
  </div>
</template>

<script>
import Navbar from "./components/Navbar";

export default {
  name: "app",
  components: {
    Navbar
  }
};
</script>

<style scoped>
.content {
  padding: 30px;
}
</style>
