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
      <a>
        <a-icon type="question-circle"/>View
      </a>
      <a-popconfirm
        title="Are you sure you want to add this to your cart?"
        @confirm="addToCart"
        okText="Yes"
        cancelText="No"
      >
        <a-icon slot="icon" type="exclamation-circle" theme="twoTone"/>
        <a-icon type="shopping-cart"/>
        Add to cart
      </a-popconfirm>
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
import { mapActions } from "vuex";
import { actions } from '../../store';

export default {
  props: {
    item: Object
  },
  data: function() {
    return {
      loaded: false
    };
  },
  methods: {
    ...mapActions([
      actions.Add_ToCart
    ]),
    onGotoClick: function() {
      // Go to page with product
    },
    onImageLoaded: function() {
      this.loaded = true;
    }
  }
};
</script>
