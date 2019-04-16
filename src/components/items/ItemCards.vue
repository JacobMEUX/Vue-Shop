<template>
  <div>
    <a-row :gutter="40">
      <a-col v-for="(item) in items" :key="item.clothingId" class="col-margin" :span="6">
        <ItemCard :item="item"/>
      </a-col>
    </a-row>
  </div>
</template>

<script>
import ItemCard from "./ItemCard";

export default {
  components: {
    ItemCard
  },
  props: {
    items: Array
  },
  computed: {
    count: function() {
      return this.items ? this.items.length : 0;
    }
  }
};
</script>
