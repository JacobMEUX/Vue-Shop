<template>
  <a-card>
    <a-card-meta :title="item.title" :description="item.description">
      <a-avatar slot="avatar" :src="imageUrl"/>
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
  computed: {
    imageUrl: function () {
      return (this.item.image.url.includes("Images/")) ? "/" + this.item.image.url : this.item.image.url
    }
  },
  methods: {
    removeFromCart: function() {
      this.$store.dispatch(actions.removeFromCart, this.index);
    }
  }
};
</script>
