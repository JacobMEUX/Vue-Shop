<template>
  <a-card hoverable style="min-height: 100%">
    <img
      v-show="loaded"
      :alt="item.image.altText"
      :src="item.image.url"
      slot="cover"
      @load="onImageLoaded"
    >
    <a-spin class="loader">
      <a-icon v-show="!loaded" slot="indicator" type="loading" spin/>
    </a-spin>
    <template class="ant-card-actions" slot="actions">
      <router-link :to="{ name: 'details', params: { id: item.clothingId, sentItem: item } }">
        <a-icon type="question-circle"/> View
      </router-link>
        <AddToCart :item="item">
          <a-icon type="shopping-cart"/> Add to cart
        </AddToCart>
    </template>
    <a-card-meta :title="item.name" :description="item.description">
      <a-divider orientation="right">Price</a-divider>
      <h5>{{item.price}}</h5>
    </a-card-meta>
    <a-divider/>
    <h4 class="text-center">{{item.price}} DKK</h4>
  </a-card>
</template>

<script>
import AddToCart from "../cart/AddToCart"

export default {
  components: {
    AddToCart
  },
  props: {
    item: Object
  },
  data: function() {
    return {
      loaded: false
    };
  },
  methods: {
    onGotoClick: function() {
      // Go to page with product
    },
    onImageLoaded: function() {
      this.loaded = true;
    }
  }
};
</script>
