<template>
  <a-card hoverable>
    <img
      v-show="loaded"
      alt="example"
      :src="item.image"
      slot="cover"
      @load="onImageLoaded"
      class="card-img"
    >
    <a-spin>
      <a-icon v-show="!loaded" slot="indicator" type="loading" class="loader" spin/>
    </a-spin>
    <template class="ant-card-actions" slot="actions">
      <a>
        <a-icon type="question-circle"/>View
      </a>
      <a>
        <a-icon type="shopping"/>Buy
      </a>
    </template>
    <a-card-meta :title="item.name" :description="description">
      <a-divider orientation="right">Price</a-divider>
      <h5>{{item.price}}</h5>
    </a-card-meta>
    <a-divider />
    <h4 class="text-center">{{item.price}} DKK</h4>
  </a-card>
</template>

<script>
export default {
  data: function() {
    return {
      loaded: false
    };
  },
  props: {
    item: Object
  },
  computed: {
    description: function() {
      return (
        this.item.description.substring(0, 95) +
        (this.item.description.length > 95 ? "..." : "")
      );
    }
  },
  methods: {
    onBuyClick: function() {
      // Add to cart directly
      // Kast https://vue.ant.design/components/message/  eksempel "Display a sequence of messages" -> Lav en loading, og bagefter en success hvis den er tilføjet til kurven.
    },
    onGotoClick: function() {
      // Go to page with product
    },
    onImageLoaded: function() {
      this.loaded = true;
    }
  }
};
</script>
