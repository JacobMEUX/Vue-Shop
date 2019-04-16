<template>
  <a-card>
    <a-card-meta :title="item.title" :description="item.description">
      <a-avatar slot="avatar" :src="item.image.url"/>
    </a-card-meta>
    <a-divider orientation="right">
      <a-button type="danger" shape="circle" icon="minus" @click="removeFromCart" />
    </a-divider>
  </a-card>
</template>

<script>
import { actions } from "../../store.js"

export default {
  props: {
    item: Object,
    index: Number
  },
  methods: {
    removeFromCart: function() {
      this.$store.dispatch(actions.removeFromCart, this.index);
    }
  }
};
</script>
