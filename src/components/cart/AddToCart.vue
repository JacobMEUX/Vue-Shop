<template>
  <a-popconfirm
    title="Are you sure you want to add this to your cart?"
    @confirm="onAddToCartClick"
    okText="Yes"
    cancelText="No"
  >
    <slot/>
  </a-popconfirm>
</template>

<script>
import { actions } from "../../store";

export default {
  props: {
    item: Object
  },
  methods: {
    onAddToCartClick: function() {
      this.$store.dispatch(actions.addToCart, this.item);
    }
  }
};
</script>
