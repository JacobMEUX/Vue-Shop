<template>
  <a-drawer
    title="Cart"
    placement="right"
    :closable="false"
    @close="onCloseCart"
    :visible="showCart"
  >
    <p>Some contents...</p>
    <p>Some contents...</p>
    <p>Some contents...</p>
  </a-drawer>
</template>

<script>
import { mapState } from "vuex";

export default {
  data: function() {
    return {
      showCart: false
    };
  },
  computed: mapState(["cart"]),
  methods: {
    onShowCart() {
      this.showCart = true;
    },
    onCloseCart() {
      this.showCart = false;
    },
  }
};
</script>
